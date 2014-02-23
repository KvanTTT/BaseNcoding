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

		public double Ratio
		{
			get;
			private set;
		}

		public int CharsCountInBits
		{
			get;
			private set;
		}

		public BaseN(string alphabet, uint blockMaxBitsCount = 32,
			Encoding encoding = null, bool parallel = false)
			: base((uint)alphabet.Length, alphabet, '\0', encoding, parallel)
		{
			BlockMaxBitsCount = blockMaxBitsCount;
			int charsCountInBits;
			BlockBitsCount = GetOptimalBitsCount2(CharsCount, out charsCountInBits, blockMaxBitsCount);
			BitsPerChar = (double)BlockBitsCount / charsCountInBits;
			CharsCountInBits = charsCountInBits;
			_powN = new ulong[CharsCountInBits];
			ulong pow = 1;
			for (int i = 0; i < CharsCountInBits; i++)
			{
				_powN[CharsCountInBits - 1 - i] = pow;
				pow *= CharsCount;
			}
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
			int mainCharsCount = (int)(mainBitsLength / BitsPerChar);
			int tailCharsCount = (int)Math.Ceiling(tailBitsLength / BitsPerChar);
			int globalCharsCount = (int)(mainCharsCount + tailCharsCount);
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
				ulong bits = GetBits64(data, mainBitsLength, tailBitsLength);
				EncodeBlock(result, mainCharsCount, tailCharsCount, bits);
			}

			return new string(result);
		}

		public override byte[] Decode(string data)
		{
			if (string.IsNullOrEmpty(data))
				return new byte[0];

			int globalBitsLength = ((int)((data.Length - 1) * BitsPerChar) + 8) / 8 * 8;
			int mainBitsLength = globalBitsLength / BlockBitsCount * BlockBitsCount;
			int tailBitsLength = globalBitsLength - mainBitsLength;
			int mainCharsCount = (int)(mainBitsLength / BitsPerChar);
			int tailCharsCount = (int)Math.Ceiling(tailBitsLength / BitsPerChar);
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
				ulong bits = DecodeBlock(data, mainCharsCount, tailCharsCount);
				AddBits64(result, bits, mainBitsLength, tailBitsLength);
			}
			
			return result;
		}

		private void EncodeBlock(byte[] src, char[] dst, int ind)
		{
			int charInd = ind * CharsCountInBits;
			int bitInd = ind * BlockBitsCount;
			ulong bits = GetBits64(src, bitInd, BlockBitsCount);
			EncodeBlock(dst, charInd, CharsCountInBits, bits);
		}

		private void DecodeBlock(string src, byte[] dst, int ind)
		{
			int charInd = ind * CharsCountInBits;
			int bitInd = ind * BlockBitsCount;
			ulong bits = DecodeBlock(src, charInd, CharsCountInBits);
			AddBits64(dst, bits, bitInd, BlockBitsCount);
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
			int currentBitPos = bitPos;
			int currentBytePos = bitPos / 8;
			int currentBitInBytePos = bitPos % 8;

			int xLength = Math.Min(bitsCount, 8 - currentBitInBytePos);
			if (xLength != 0)
			{
				byte x1 = (byte)(value << 64 - bitsCount >> (56 + currentBitInBytePos));
				data[currentBytePos] |= x1;

				currentBytePos += (currentBitInBytePos + xLength) / 8;
				currentBitInBytePos = (currentBitInBytePos + xLength) % 8;
				currentBitPos += xLength;

				int x2Length = bitsCount - xLength;
				if (x2Length > 8)
					x2Length = 8;

				while (x2Length > 0)
				{
					byte x2 = (byte)(value << 64 - bitsCount + xLength >> 64 - x2Length << 8 - x2Length);
					data[currentBytePos] |= x2;

					currentBytePos += (currentBitInBytePos + x2Length) / 8;
					currentBitInBytePos = (currentBitInBytePos + x2Length) % 8;
					currentBitPos += x2Length;

					xLength += x2Length;
					x2Length = bitsCount - xLength;
					if (x2Length > 8)
						x2Length = 8;
				}
			}
		}

		private void EncodeBlock(char[] chars, int ind, int count, ulong block)
		{
			for (int i = 0; i < count; i++)
			{
				chars[ind + i] = Alphabet[(int)(block % CharsCount)];
				block /= CharsCount;
			}
		}

		private ulong DecodeBlock(string data, int ind, int count)
		{
			ulong result = 0;
			for (int i = 0; i < count; i++)
				result += (ulong)InvAlphabet[data[ind + i]] * _powN[CharsCountInBits - 1 - i];
			return result;
		}

		public static int GetOptimalBitsCount2(uint charsCount, out int charsCountInBits,
			uint maxBitsCount = 64, bool base2BitsCount = false)
		{
			int result = 0;
			charsCountInBits = 0;
			int n1 = Base.LogBase2(charsCount);
			ulong uCharsCount = (ulong)charsCount;
			double charsCountLog = Math.Log(2, charsCount);
			double maxRatio = 0;

			for (int n = n1; n <= maxBitsCount; n++)
			{
				if (base2BitsCount && n % 8 != 0)
					continue;

				int l1 = (int)Math.Ceiling(n * charsCountLog);
				double ratio = (double)n / l1;
				if (ratio > maxRatio)
				{
					maxRatio = ratio;
					result = n;
					charsCountInBits = l1;
				}
			}

			return result;
		}

		public static int GetOptimalBitsCount(uint charsCount, out int charsCountInBits,
			int maxBitsCount = 64, uint radix = 2)
		{
			int result = 0;
			charsCountInBits = 0;
			int n1 = Base.LogBaseN(charsCount, radix);
			double charsCountLog = Math.Log(radix, charsCount);
			double maxRatio = 0;

			for (int n = n1; n <= maxBitsCount; n++)
			{
				int l1 = (int)Math.Ceiling(n * charsCountLog);
				double ratio = (double)n / l1;
				if (ratio > maxRatio)
				{
					maxRatio = ratio;
					result = n;
					charsCountInBits = l1;
				}
			}

			return result;
		}
	}
}
