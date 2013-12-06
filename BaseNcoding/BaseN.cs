using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding
{
	public class BaseN : Base
	{
		private uint _minPowerOfTwo;
		private uint _maxPowerOfTwo;
		private int _minBitsCount;
		private int _maxBitsCount;

		public BaseN(uint charsCount, string alphabet, char special, Encoding encoding = null)
			: base(charsCount, alphabet, special, encoding)
		{
			if (IsPowerOfTwo(charsCount))
			{
				_maxPowerOfTwo = _minPowerOfTwo = charsCount;
				_maxBitsCount = _minBitsCount = LogBase2((uint)_minPowerOfTwo);
			}
			else
			{
				_maxPowerOfTwo = NextPowOf2(charsCount);
				_minPowerOfTwo = _maxPowerOfTwo / 2;
				_minBitsCount = LogBase2((uint)_minPowerOfTwo);
				_maxBitsCount = _minBitsCount + 1;
			}
		}

		public override bool HaveSpecial
		{
			get { return true; }
		}

		public override string Encode(byte[] data)
		{
			if (data.Length == 0)
				return string.Empty;

			var result = new StringBuilder((int)((double)(data.Length + (_maxBitsCount - 1)) / _maxBitsCount * 8 + 1));
			var bitsArray = new BitsArray(data, false);
			int bitsCount = data.Length * 8;

			short ind;
			while (bitsArray.CurrentBitPos + _maxBitsCount <= bitsCount)
			{
				ind = bitsArray.GetBits(_maxBitsCount);
				if (ind < CharsCount)
				{
					result.Append(Alphabet[ind]);
					bitsArray.CurrentBitPos += _maxBitsCount;
				}
				else
				{
					ind = bitsArray.GetBits(_minBitsCount);
					result.Append(Alphabet[ind]);
					bitsArray.CurrentBitPos += _minBitsCount;
				}
			}

			if (bitsArray.CurrentBitPos != bitsCount)
			{
				int excessBytesCount = ((_maxBitsCount - (8 - bitsArray.CurrentBitInBytePos)) + 7) / 8 + 1;
				byte[] excessBytes = new byte[excessBytesCount];
				excessBytes[0] = data[data.Length - 1];
				bitsArray = new BitsArray(excessBytes, false, bitsArray.CurrentBitInBytePos);
				
				ind = bitsArray.GetBits(_maxBitsCount);
				if (ind < CharsCount)
				{
					result.Append(Alphabet[ind]);
					bitsArray.CurrentBitPos += _maxBitsCount;
				}
				else
				{
					ind = bitsArray.GetBits(_minBitsCount);
					result.Append(Alphabet[ind]);
					bitsArray.CurrentBitPos += _minBitsCount;

					if (bitsArray.CurrentBitPos == 8)
						excessBytesCount--; // = 0
				}

				for (int i = 0; i < excessBytesCount - 1; i++)
					result.Append(Special);
			}

			return result.ToString();
		}

		public override byte[] Decode(string data)
		{
			if (string.IsNullOrEmpty(data))
				return new byte[0];
			int lastSpecialInd = data.Length;
			while (data[lastSpecialInd - 1] == Special)
				lastSpecialInd--;
			int tailLength = data.Length - lastSpecialInd;

			var bitsArray = new BitsArray((int)((double)(data.Length + 7) / 8 * _maxBitsCount), true);

			for (int i = 0; i < data.Length - 1 - tailLength; i++)
			{
				int ind1 = InvAlphabet[data[i]];
				int ind2 = InvAlphabet[data[i + 1]];

				/*if (ind1 >= _minPowerOfTwo)
					bitsArray.AddBits((short)ind1, _maxBitsCount);
				else
				{
				}*/
				if (ind1 > _minPowerOfTwo)
					bitsArray.AddBits((short)ind1, _minBitsCount);
				else
					bitsArray.AddBits((short)ind1, _maxBitsCount);
			}

			return bitsArray.ToBytesArray(bitsArray.BytesCount - tailLength);
		}
	}
}
