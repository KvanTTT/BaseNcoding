using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding
{
	public class BitsArray
	{
		private List<byte> _bytes;

		public BitsArray(int length, bool bitPosAutoChange = true, int currentBitPos = 0)
		{
			_bytes = new List<byte>(length);
			BitPosAutoChange = bitPosAutoChange;
			CurrentBitPos = currentBitPos;
		}

		public BitsArray(byte[] bytes, bool bitPosAutoChange = true, int currentBitPos = 0)
		{
			_bytes = bytes.ToList();
			BitPosAutoChange = bitPosAutoChange;
			CurrentBitPos = currentBitPos;
		}

		public bool BitPosAutoChange
		{
			get;
			set;
		}

		public int CurrentBitPos
		{
			get;
			set;
		}

		public int CurrentBytePos
		{
			get
			{
				return CurrentBitPos / 8;
			}
		}

		public int CurrentBitInBytePos
		{
			get
			{
				return CurrentBitPos % 8;
			}
		}

		public int BytesCount
		{
			get
			{
				return _bytes.Count;
			}
		}

		public void AddBits(short value, int bitsCount)
		{
			int x1_length = Math.Min(bitsCount, 8 - CurrentBitInBytePos);
			if (x1_length != 0)
			{
				int currentBitPos = CurrentBitPos;
				int currentBytePos = CurrentBytePos;
				int currentBitInBytePos = CurrentBitInBytePos;

				byte x1 = (byte)(value << 16 - bitsCount >> (8 + currentBitInBytePos));
				if (currentBytePos >= _bytes.Count)
					_bytes.Add(x1);
				else
					_bytes[currentBytePos] |= x1;

				currentBytePos += (currentBitInBytePos + x1_length) / 8;
				currentBitInBytePos = (currentBitInBytePos + x1_length) % 8;
				currentBitPos += x1_length;

				int x2_length = bitsCount - x1_length;
				if (x2_length < 0)
					x2_length = 0;
				else if (x2_length > 8)
					x2_length = 8;

				if (x2_length != 0)
				{
					byte x2 = (byte)(value << 16 - bitsCount + x1_length >> 16 - x2_length << 8 - x2_length);
					if (currentBytePos >= _bytes.Count)
						_bytes.Add(x2);
					else
						_bytes[currentBytePos] |= x2;

					currentBytePos += (currentBitInBytePos + x2_length) / 8;
					currentBitInBytePos = (currentBitInBytePos + x2_length) % 8;
					currentBitPos += x2_length;

					int x3_length = Math.Max(0, bitsCount - x1_length - x2_length);
					if (x3_length != 0)
					{
						byte x3 = (byte)(value << 16 - bitsCount + x1_length + x2_length >> 16 - x3_length << 8 - x3_length);
						if (currentBytePos >= _bytes.Count)
							_bytes.Add(x3);
						else
							_bytes[currentBytePos] |= x3;

						currentBytePos += (currentBitInBytePos + x3_length) / 8;
						currentBitInBytePos = (currentBitInBytePos + x3_length) % 8;
						currentBitPos += x3_length;
					}
				}
			}

			if (BitPosAutoChange)
				CurrentBitPos += bitsCount;
		}

		public short GetBits(int bitsCount)
		{
			int result = 0;

			int x1_length = Math.Min(bitsCount, 8 - CurrentBitInBytePos);
			if (x1_length != 0)
			{
				int currentBitPos = CurrentBitPos;
				int currentBytePos = CurrentBytePos;
				int currentBitInBytePos = CurrentBitInBytePos;

				result = ((_bytes[currentBytePos] << 8 + currentBitInBytePos) & 0xFFFF) >> 16 - x1_length << bitsCount - x1_length;

				currentBytePos += (currentBitInBytePos + x1_length) / 8;
				currentBitInBytePos = (currentBitInBytePos + x1_length) % 8;
				currentBitPos += x1_length;

				int x2_length = bitsCount - x1_length;
				if (x2_length < 0)
					x2_length = 0;
				else if (x2_length > 8)
					x2_length = 8;

				if (x2_length != 0)
				{
					result |= (int)_bytes[currentBytePos] >> 8 - x2_length << bitsCount - x1_length - x2_length;

					currentBytePos += (currentBitInBytePos + x2_length) / 8;
					currentBitInBytePos = (currentBitInBytePos + x2_length) % 8;
					currentBitPos += x2_length;

					int x3_length = Math.Max(0, bitsCount - x1_length - x2_length);
					if (x3_length != 0)
					{
						result |= (int)_bytes[currentBytePos] >> 8 - x3_length;

						currentBytePos += (currentBitInBytePos + x3_length) / 8;
						currentBitInBytePos = (currentBitInBytePos + x3_length) % 8;
						currentBitPos += x3_length;
					}
				}
			}

			if (BitPosAutoChange)
				CurrentBitPos += bitsCount;

			return (short)result;
		}

		public byte[] ToBytesArray()
		{
			return _bytes.ToArray();
		}

		public byte[] ToBytesArray(int count)
		{
			var result = new byte[Math.Min(_bytes.Count, count)];
			for (int i = 0; i < result.Length; i++)
				result[i] = _bytes[i];
			return result;
		}
	}
}
