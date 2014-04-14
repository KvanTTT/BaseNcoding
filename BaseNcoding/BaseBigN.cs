using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BaseNcoding
{
	public class BaseBigN : Base
	{
		private BigInteger[] _powN;
		private static byte[] two_in_power_n;

		public bool ReverseOrder
		{
			get;
			private set;
		}

		public uint BlockMaxBitsCount
		{
			get;
			private set;
		}

		public override bool HaveSpecial
		{
			get { return false; }
		}

		static BaseBigN()
		{
			two_in_power_n = new byte[8];
			int a = 2;
			for (int i = 0; i < 8; i++)
			{
				two_in_power_n[i] = (byte)(a - 1);
				a *= 2;
			}
		}

		public BaseBigN(string alphabet, uint blockMaxBitsCount = 64,
			Encoding encoding = null, bool reverseOrder = false, bool parallel = false)
			: base((uint)alphabet.Length, alphabet, '\0', encoding, parallel)
		{
			BlockMaxBitsCount = blockMaxBitsCount;
			uint charsCountInBits;
			BlockBitsCount = GetOptimalBitsCount(CharsCount, out charsCountInBits, BlockMaxBitsCount, 2);
			BlockCharsCount = (int)charsCountInBits;
			_powN = new BigInteger[BlockCharsCount];
			BigInteger pow = 1;
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
			if (data == null)
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
			{
				EncodeBlock(data, result, 0, iterationCount);
			}
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
				BigInteger bits = GetBitsN(data, mainBitsLength, tailBitsLength);
				BitsToChars(result, mainCharsCount, tailCharsCount, bits);
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
			BigInteger tailBits = CharsToBits(data, mainCharsCount, tailCharsCount);
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
				BigInteger bits = CharsToBits(data, mainCharsCount, tailCharsCount);
				AddBitsN(result, bits, mainBitsLength, tailBitsLength);
			}
			
			return result;
		}

		private void EncodeBlock(byte[] src, char[] dst, int beginInd, int endInd)
		{
			for (int ind = beginInd; ind < endInd; ind++)
			{
				int charInd = ind * (int)BlockCharsCount;
				int bitInd = ind * BlockBitsCount;
				BigInteger bits = GetBitsN(src, bitInd, BlockBitsCount);
				BitsToChars(dst, charInd, (int)BlockCharsCount, bits);
			}
		}

		private void DecodeBlock(string src, byte[] dst, int beginInd, int endInd)
		{
			for (int ind = beginInd; ind < endInd; ind++)
			{
				int charInd = ind * (int)BlockCharsCount;
				int bitInd = ind * BlockBitsCount;
				BigInteger bits = CharsToBits(src, charInd, (int)BlockCharsCount);
				AddBitsN(dst, bits, bitInd, BlockBitsCount);
			}
		}

		private static BigInteger GetBitsN(byte[] data, int bitPos, int bitsCount)
		{
			BigInteger result = 0;

			int currentBitPos = bitPos;
			int currentBytePos = bitPos / 8;
			int currentBitInBytePos = bitPos % 8;
			int xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
			if (xLength != 0)
			{
				result = (((BigInteger)data[currentBytePos] >> 8 - xLength - currentBitInBytePos) & two_in_power_n[7 - currentBitInBytePos]) << bitsCount - xLength;

				currentBytePos += (currentBitInBytePos + xLength) / 8;
				currentBitInBytePos = (currentBitInBytePos + xLength) % 8;
				currentBitPos += xLength;

				int x2Length = bitsCount - xLength;
				if (x2Length > 8)
					x2Length = 8;

				while (x2Length > 0)
				{
					xLength += x2Length;
					result |= (BigInteger)(data[currentBytePos] >> 8 - x2Length) << bitsCount - xLength;

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

		private static void AddBitsN(byte[] data, BigInteger value, int bitPos, int bitsCount)
		{
			int currentBitPos = bitPos;
			int currentBytePos = bitPos / 8;
			int currentBitInBytePos = bitPos % 8;

			int xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
			if (xLength != 0)
			{
				byte x1 = (byte)((value >> bitsCount + currentBitInBytePos - 8) & two_in_power_n[7 - currentBitInBytePos]);
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
					byte x2 = (byte)((value >> bitsCount - xLength << 8 - x2Length) & 0xFF);
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

		private void BitsToChars(char[] chars, int ind, int count, BigInteger block)
		{
			for (int i = 0; i < count; i++)
			{
				chars[ind + (!ReverseOrder ? i : count - 1 - i)] = Alphabet[(int)(block % CharsCount)];
				block /= CharsCount;
			}
		}

		private BigInteger CharsToBits(string data, int ind, int count)
		{
			BigInteger result = 0;
			for (int i = 0; i < count; i++)
				result += InvAlphabet[data[ind + (!ReverseOrder ? i : count - 1 - i)]] * _powN[BlockCharsCount - 1 - i];
			return result;
		}
	}
}
