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
		private static byte[] two_in_power_n_minus_1;

		public int BlockBitsCount
		{
			get;
			private set;
		}

		public uint BlockMaxBitsCount
		{
			get;
			private set;
		}

		public int CharsCountInBits
		{
			get;
			private set;
		}

		static BaseBigN()
		{
			two_in_power_n_minus_1 = new byte[8];
			int a = 2;
			for (int i = 0; i < 8; i++)
			{
				two_in_power_n_minus_1[i] = (byte)(a - 1);
				a *= 2;
			}
		}

		public BaseBigN(string alphabet, uint blockMaxBitsCount = 64,
			Encoding encoding = null, bool parallel = false)
			: base((uint)alphabet.Length, alphabet, '\0', encoding, parallel)
		{
			BlockMaxBitsCount = blockMaxBitsCount;
			uint charsCountInBits;
			BlockBitsCount = GetOptimalBitsCount(CharsCount, out charsCountInBits, BlockMaxBitsCount, 2);
			BitsPerChar = (double)BlockBitsCount / charsCountInBits;
			CharsCountInBits = (int)charsCountInBits;
			_powN = new BigInteger[CharsCountInBits];
			BigInteger pow = 1;
			for (int i = 0; i < CharsCountInBits - 1; i++)
			{
				_powN[CharsCountInBits - 1 - i] = pow;
				pow *= CharsCount;
			}
			_powN[0] = pow;
		}

		public override bool HaveSpecial
		{
			get { return false; }
		}

		public override string Encode(byte[] data)
		{
			if (data == null || data.Length == 0)
				return "";

			int mainBitsLength = (data.Length * 8 / BlockBitsCount) * BlockBitsCount;
			int tailBitsLength = data.Length * 8 - mainBitsLength;
			int globalBitsLength = mainBitsLength + tailBitsLength;
			int mainCharsCount = mainBitsLength * CharsCountInBits / BlockBitsCount;
			int tailCharsCount = (tailBitsLength * CharsCountInBits + BlockBitsCount - 1) / BlockBitsCount;
			int globalCharsCount = mainCharsCount + tailCharsCount;
			int iterationCount = mainCharsCount / CharsCountInBits;

			var result = new char[globalCharsCount];

			if (!Parallel)
			{
				for (int i = 0; i < iterationCount; i++)
					EncodeBlock(data, result, i);
			}
			else
				System.Threading.Tasks.Parallel.For(0, iterationCount, i => EncodeBlock(data, result, i));
			if (tailBitsLength != 0)
			{
				BigInteger bits = GetBitsN(data, mainBitsLength, tailBitsLength);
				EncodeBlock(result, mainCharsCount, tailCharsCount, bits);
			}

			return new string(result);
		}

		public override byte[] Decode(string data)
		{
			if (string.IsNullOrEmpty(data))
				return new byte[0];

			int globalBitsLength = ((data.Length - 1) * BlockBitsCount / CharsCountInBits + 8) / 8 * 8;
			int mainBitsLength = globalBitsLength / BlockBitsCount * BlockBitsCount;
			int tailBitsLength = globalBitsLength - mainBitsLength;
			int mainCharsCount = mainBitsLength * CharsCountInBits / BlockBitsCount;
			int tailCharsCount = (tailBitsLength * CharsCountInBits + BlockBitsCount - 1) / BlockBitsCount;
			BigInteger tailBits = DecodeBlock(data, mainCharsCount, tailCharsCount);
			if (tailBits >> tailBitsLength != 0)
			{
				globalBitsLength += 8;
				mainBitsLength = globalBitsLength / BlockBitsCount * BlockBitsCount;
				tailBitsLength = globalBitsLength - mainBitsLength;
				mainCharsCount = mainBitsLength * CharsCountInBits / BlockBitsCount;
				tailCharsCount = (tailBitsLength * CharsCountInBits + BlockBitsCount - 1) / BlockBitsCount;
			}
			int iterationCount = mainCharsCount / CharsCountInBits;

			byte[] result = new byte[globalBitsLength / 8];

			if (!Parallel)
			{
				for (int i = 0; i < iterationCount; i++)
					DecodeBlock(data, result, i);
			}
			else
				System.Threading.Tasks.Parallel.For(0, iterationCount, i => DecodeBlock(data, result, i));

			if (tailCharsCount != 0)
			{
				BigInteger bits = DecodeBlock(data, mainCharsCount, tailCharsCount);
				AddBitsN(result, bits, mainBitsLength, tailBitsLength);
			}
			
			return result;
		}

		private void EncodeBlock(byte[] src, char[] dst, int ind)
		{
			int charInd = ind * CharsCountInBits;
			int bitInd = ind * BlockBitsCount;
			BigInteger bits = GetBitsN(src, bitInd, BlockBitsCount);
			EncodeBlock(dst, charInd, CharsCountInBits, bits);
		}

		private void DecodeBlock(string src, byte[] dst, int ind)
		{
			int charInd = ind * CharsCountInBits;
			int bitInd = ind * BlockBitsCount;
			BigInteger bits = DecodeBlock(src, charInd, CharsCountInBits);
			AddBitsN(dst, bits, bitInd, BlockBitsCount);
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
				result = (((BigInteger)data[currentBytePos] >> 8 - xLength - currentBitInBytePos) & two_in_power_n_minus_1[7 - currentBitInBytePos]) << bitsCount - xLength;

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
				byte x1 = (byte)((value >> bitsCount + currentBitInBytePos - 8) & two_in_power_n_minus_1[7 - currentBitInBytePos]);
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
					var b = value >> bitsCount - xLength;
					data[currentBytePos] |= x2;

					currentBytePos += (currentBitInBytePos + x2Length) / 8;
					currentBitInBytePos = (currentBitInBytePos + x2Length) % 8;
					currentBitPos += x2Length;

					x2Length = bitsCount - xLength;
					if (x2Length > 8)
						x2Length = 8;
				}
				var a = value >> bitsCount - xLength;
			}
		}

		private void EncodeBlock(char[] chars, int ind, int count, BigInteger block)
		{
			for (int i = 0; i < count; i++)
			{
				chars[ind + i] = Alphabet[(int)(block % CharsCount)];
				block /= CharsCount;
			}
		}

		private BigInteger DecodeBlock(string data, int ind, int count)
		{
			BigInteger result = 0;
			for (int i = 0; i < count; i++)
				result += InvAlphabet[data[ind + i]] * _powN[CharsCountInBits - 1 - i];
			return result;
		}
	}
}
