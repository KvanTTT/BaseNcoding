using System;
using System.Collections.Generic;
using System.Text;

namespace BaseNcoding
{
	/// <summary>
	/// From: https://github.com/denxc/ZBase32Encoder/blob/master/ZBase32Encoder/ZBase32Encoder/ZBase32Encoder.cs
	/// </summary>
	public class ZBase32 : Base
	{
		public const string DefaultAlphabet = "ybndrfg8ejkmcpqxot1uwisza345h769";
		public const char DefaultSpecial = (char)0;

		public override bool HasSpecial => false;

		public ZBase32(string alphabet = DefaultAlphabet, char special = DefaultSpecial, Encoding textEncoding = null)
			: base(32, alphabet, special, textEncoding)
		{
		}

		public override string Encode(byte[] data)
		{
			unchecked
			{
				var encodedResult = new StringBuilder((int)Math.Ceiling(data.Length * 8.0 / 5.0));

				for (var i = 0; i < data.Length; i += 5)
				{
					var byteCount = Math.Min(5, data.Length - i);

					ulong buffer = 0;
					for (var j = 0; j < byteCount; ++j)
						buffer = (buffer << 8) | data[i + j];

					var bitCount = byteCount * 8;
					while (bitCount > 0)
					{
						var index = bitCount >= 5
									? (int)(buffer >> (bitCount - 5)) & 0x1f
									: (int)(buffer & (ulong)(0x1f >> (5 - bitCount))) << (5 - bitCount);

						encodedResult.Append(DefaultAlphabet[index]);
						bitCount -= 5;
					}
				}

				return encodedResult.ToString();
			}
		}

		public override byte[] Decode(string data)
		{
			if (string.IsNullOrEmpty(data))
				return new byte[0];

			var result = new List<byte>((int)Math.Ceiling(data.Length * 5.0 / 8.0));

			var index = new int[8];
			for (var i = 0; i < data.Length; )
			{
				i = CreateIndexByOctetAndMovePosition(ref data, i, ref index);

				var shortByteCount = 0;
				ulong buffer = 0;
				for (var j = 0; j < 8 && index[j] != -1; ++j)
				{
					buffer = (buffer << 5) | (ulong)(InvAlphabet[index[j]] & 0x1f);
					shortByteCount++;
				}

				var bitCount = shortByteCount * 5;
				while (bitCount >= 8)
				{
					result.Add((byte)((buffer >> (bitCount - 8)) & 0xff));
					bitCount -= 8;
				}
			}

			return result.ToArray();
		}

		private int CreateIndexByOctetAndMovePosition(ref string data, int currentPosition, ref int[] index)
		{
			var j = 0;
			while (j < 8)
			{
				if (currentPosition >= data.Length)
				{
					index[j++] = -1;
					continue;
				}

				if (InvAlphabet[data[currentPosition]] == -1)
				{
					currentPosition++;
					continue;
				}

				index[j] = data[currentPosition];
				j++;
				currentPosition++;
			}

			return currentPosition;
		}
	}
}
