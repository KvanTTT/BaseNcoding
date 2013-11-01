using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding
{
	public class Base128 : BaseN
	{
		public const string DefaultAlphabet = "!#$%()*,.0123456789:;=@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«¬®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎ";
		public const char DefaultSpecial = '-';

		public Base128(string alphabet = DefaultAlphabet, char special = DefaultSpecial)
			: base(128, alphabet, special)
		{
		}

		public override string Encode(byte[] data)
		{
			StringBuilder result = new StringBuilder((data.Length + 6) / 7 * 8);

			byte x = 0;
			int old = 0;
			int i;
			for (i = 0; i < data.Length; i++)
			{
				x = data[i];
				switch (i % 7)
				{
					case 0:
						result.Append(Alphabet[x >> 1]);
						break;
					case 1:
						result.Append(Alphabet[((old << 6) & 0x40) | (x >> 2)]);
						break;
					case 2:
						result.Append(Alphabet[((old << 5) & 0x60) | (x >> 3)]);
						break;
					case 3:
						result.Append(Alphabet[((old << 4) & 0x70) | (x >> 4)]);
						break;
					case 4:
						result.Append(Alphabet[((old << 3) & 0x78) | (x >> 5)]);
						break;
					case 5:
						result.Append(Alphabet[((old << 2) & 0x7C) | (x >> 6)]);
						break;
					case 6:
						result.Append(Alphabet[((old << 1) & 0x7E) | (x >> 7)]);
						result.Append(Alphabet[x & 0x7F]);
						break;
				}
				old = x;
			}

			switch (i % 7)
			{
				case 1:
					result.Append(Alphabet[(old << 6) & 0x40]);
					result.Append(Special, 6);
					break;
				case 2:
					result.Append(Alphabet[((old << 5) & 0x60)]);
					result.Append(Special, 5);
					break;
				case 3:
					result.Append(Alphabet[((old << 4) & 0x70)]);
					result.Append(Special, 4);
					break;
				case 4:
					result.Append(Alphabet[((old << 3) & 0x78)]);
					result.Append(Special, 3);
					break;
				case 5:
					result.Append(Alphabet[((old << 2) & 0x7C)]);
					result.Append(Special, 2);
					break;
				case 6:
					result.Append(Alphabet[((old << 1) & 0x7E)]);
					result.Append(Special);
					break;
			}

			return result.ToString();
		}

		public override byte[] Decode(string data)
		{
			int lastSpecialInd = data.Length;
			while (data[lastSpecialInd - 1] == Special)
				lastSpecialInd--;

			int length = (data.Length + 7) / 8 * 7 - (data.Length - lastSpecialInd);
			byte[] result = new byte[length];
			int dst = 0;

			for (int i = 0; i < data.Length; i++)
			{
				int code = Alphabet.IndexOf(data[i]);
				if (code == -1)
					break;
				switch (i % 8)
				{
					case 0:
						result[dst] = (byte)(code << 1);
						break;
					case 1:
						result[dst++] |= (byte)((code >> 6) & 0x01);
						if (dst < length)
							result[dst] = (byte)(code << 2);
						break;
					case 2:
						result[dst++] |= (byte)((code >> 5) & 0x03);
						if (dst < length)
							result[dst] = (byte)(code << 3);
						break;
					case 3:
						result[dst++] |= (byte)((code >> 4) & 0x07);
						if (dst < length)
							result[dst] = (byte)(code << 4);
						break;
					case 4:
						result[dst++] |= (byte)((code >> 3) & 0x0F);
						if (dst < length)
							result[dst] = (byte)(code << 5);
						break;
					case 5:
						result[dst++] |= (byte)((code >> 2) & 0x1F);
						if (dst < length)
							result[dst] = (byte)(code << 6);
						break;
					case 6:
						result[dst++] |= (byte)((code >> 1) & 0x3F);
						if (dst < length)
							result[dst] = (byte)(code << 7);
						break;
					case 7:
						result[dst++] |= (byte)(code & 0x7f);
						break;
				}
			}

			return result;
		}
	}
}
