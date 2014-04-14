using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BaseNcoding
{
	public class BaseN : Base
	{
		private ulong[] _powN;

		public uint BlockMaxBitsCount
		{
			get;
			private set;
		}

		public override bool HaveSpecial
		{
			get { return false; }
		}

		public bool ReverseOrder
		{
			get;
			private set;
		}

		public BaseN(string alphabet, uint blockMaxBitsCount = 32,
			Encoding encoding = null, bool reverseOrder = false, bool parallel = false)
			: base((uint)alphabet.Length, alphabet, '\0', encoding, parallel)
		{
			BlockMaxBitsCount = blockMaxBitsCount;
			uint charsCountInBits;
			BlockBitsCount = GetOptimalBitsCount(CharsCount, out charsCountInBits, blockMaxBitsCount);
			BlockCharsCount = (int)charsCountInBits;
			_powN = new ulong[BlockCharsCount];
			ulong pow = 1;
			for (int i = 0; i < BlockCharsCount - 1; i++)
			{
				_powN[BlockCharsCount - 1 - i] = pow;
				pow *= CharsCount;
			}
			_powN[0] = pow;
			ReverseOrder = reverseOrder;
		}

		public override string Encode(byte[] data)
		{
			if (data == null || data.Length == 0)
				return "";

			int mainBitsLength = (data.Length * 8 / BlockBitsCount) * BlockBitsCount;
			int tailBitsLength = data.Length * 8 - mainBitsLength;
			int globalBitsLength = mainBitsLength + tailBitsLength;
			int mainCharsCount = mainBitsLength * BlockCharsCount / BlockBitsCount;
			int tailCharsCount = (tailBitsLength * BlockCharsCount + BlockBitsCount - 1) / BlockBitsCount;
			int globalCharsCount = mainCharsCount + tailCharsCount;
			int iterationCount = mainCharsCount / BlockCharsCount;

			var result = new char[globalCharsCount];

			if (!Parallel)
				EncodeBlock(data, result, 0, iterationCount);
			else
			{
				int processorCount = Math.Min(iterationCount, Environment.ProcessorCount);
				System.Threading.Tasks.Parallel.For(0, processorCount, i =>
				{
					int beginInd = i * iterationCount / processorCount;
					int endInd = (i + 1) * iterationCount / processorCount;
					EncodeBlock(data, result, beginInd, endInd);
				});
			}

			if (tailBitsLength != 0)
			{
				ulong bits = GetBits64(data, mainBitsLength, tailBitsLength);
				EncodeBlock(result, mainCharsCount, tailCharsCount, bits);
			}

			return new string(result);
		}

		public override byte[] Decode(string data)
		{
			if (string.IsNullOrEmpty(data))
				return new byte[0];

			int globalBitsLength = ((data.Length - 1) * BlockBitsCount / BlockCharsCount + 8) / 8 * 8;
			int mainBitsLength = globalBitsLength / BlockBitsCount * BlockBitsCount;
			int tailBitsLength = globalBitsLength - mainBitsLength;
			int mainCharsCount = mainBitsLength * BlockCharsCount / BlockBitsCount;
			int tailCharsCount = (tailBitsLength * BlockCharsCount + BlockBitsCount - 1) / BlockBitsCount;
			ulong tailBits = DecodeBlock(data, mainCharsCount, tailCharsCount);
			if (tailBits >> tailBitsLength != 0)
			{
				globalBitsLength += 8;
				mainBitsLength = globalBitsLength / BlockBitsCount * BlockBitsCount;
				tailBitsLength = globalBitsLength - mainBitsLength;
				mainCharsCount = mainBitsLength * BlockCharsCount / BlockBitsCount;
				tailCharsCount = (tailBitsLength * BlockCharsCount + BlockBitsCount - 1) / BlockBitsCount;
			}
			int iterationCount = mainCharsCount / BlockCharsCount;

			byte[] result = new byte[globalBitsLength / 8];

			if (!Parallel)
			{
				DecodeBlock(data, result, 0, iterationCount);
			}
			else
			{
				int processorCount = Math.Min(iterationCount, Environment.ProcessorCount);
				System.Threading.Tasks.Parallel.For(0, processorCount, i =>
				{
					int beginInd = i * iterationCount / processorCount;
					int endInd = (i + 1) * iterationCount / processorCount;
					DecodeBlock(data, result, beginInd, endInd);
				});
			}

			if (tailCharsCount != 0)
			{
				ulong bits = DecodeBlock(data, mainCharsCount, tailCharsCount);
				AddBits64(result, bits, mainBitsLength, tailBitsLength);
			}
			
			return result;
		}

		private void EncodeBlock(byte[] src, char[] dst, int beginInd, int endInd)
		{
			for (int ind = beginInd; ind < endInd; ind++)
			{
				int charInd = ind * (int)BlockCharsCount;
				int bitInd = ind * BlockBitsCount;
				ulong bits = GetBits64(src, bitInd, BlockBitsCount);
				EncodeBlock(dst, charInd, (int)BlockCharsCount, bits);
			}
		}

		private void DecodeBlock(string src, byte[] dst, int beginInd, int endInd)
		{
			for (int ind = beginInd; ind < endInd; ind++)
			{
				int charInd = ind * (int)BlockCharsCount;
				int bitInd = ind * BlockBitsCount;
				ulong bits = DecodeBlock(src, charInd, (int)BlockCharsCount);
				AddBits64(dst, bits, bitInd, BlockBitsCount);
			}
		}

		private static ulong GetBits64(byte[] data, int bitPos, int bitsCount)
		{
			ulong result = 0;

			int currentBitPos = bitPos;
			int currentBytePos = bitPos / 8;
			int currentBitInBytePos = bitPos % 8;
			int xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
			if (xLength != 0)
			{
				result = ((ulong)data[currentBytePos] << 56 + currentBitInBytePos) >> 64 - xLength << bitsCount - xLength;

				currentBytePos += (currentBitInBytePos + xLength) / 8;
				currentBitInBytePos = (currentBitInBytePos + xLength) % 8;
				currentBitPos += xLength;

				int x2Length = bitsCount - xLength;
				if (x2Length > 8)
					x2Length = 8;

				while (x2Length > 0)
				{
					xLength += x2Length;
					result |= (ulong)data[currentBytePos] >> 8 - x2Length << bitsCount - xLength;

					currentBytePos += (currentBitInBytePos + x2Length) / 8;
					currentBitInBytePos = (currentBitInBytePos + x2Length) % 8;
					currentBitPos += x2Length;

					x2Length = bitsCount - xLength;
					if (x2Length > 8)
						x2Length = 8;
				}
			}

			return result;
		}

		private static void AddBits64(byte[] data, ulong value, int bitPos, int bitsCount)
		{
			unchecked
			{
				int currentBitPos = bitPos;
				int currentBytePos = bitPos / 8;
				int currentBitInBytePos = bitPos % 8;

				int xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
				if (xLength != 0)
				{
					byte x1 = (byte)(value << 64 - bitsCount >> 56 + currentBitInBytePos);
					data[currentBytePos] |= x1;

					currentBytePos += (currentBitInBytePos + xLength) / 8;
					currentBitInBytePos = (currentBitInBytePos + xLength) % 8;
					currentBitPos += xLength;

					int x2Length = bitsCount - xLength;
					if (x2Length > 8)
						x2Length = 8;

					while (x2Length > 0)
					{
						xLength += x2Length;
						byte x2 = (byte)(value >> bitsCount - xLength << 8 - x2Length);
						data[currentBytePos] |= x2;

						currentBytePos += (currentBitInBytePos + x2Length) / 8;
						currentBitInBytePos = (currentBitInBytePos + x2Length) % 8;
						currentBitPos += x2Length;

						x2Length = bitsCount - xLength;
						if (x2Length > 8)
							x2Length = 8;
					}
				}
			}
		}

		private void EncodeBlock(char[] chars, int ind, int count, ulong block)
		{
			for (int i = 0; i < count; i++)
			{
				chars[ind + (!ReverseOrder ? i : count - 1 - i)] = Alphabet[(int)(block % CharsCount)];
				block /= CharsCount;
			}
		}

		private ulong DecodeBlock(string data, int ind, int count)
		{
			ulong result = 0;
			for (int i = 0; i < count; i++)
				result += (ulong)InvAlphabet[data[ind + (!ReverseOrder ? i : count - 1 - i)]] * _powN[BlockCharsCount - 1 - i];
			return result;
		}
	}
}
