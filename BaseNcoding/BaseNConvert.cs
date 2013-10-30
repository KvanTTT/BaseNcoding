using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding
{
	public class BaseNConvert
	{
		static char Special = '-';
		static string Base128Chars = "!#$%()*,.0123456789:;=@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«¬®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎ";

		public static string ToBase128(string data)
		{
			return ToBase128(Encoding.UTF8.GetBytes(data));
		}

		public static string ToBase128(byte[] data)
		{
			StringBuilder result = new StringBuilder((data.Length + 6) / 7 * 8);

			byte x = 0;
			int state = 0;
			int old = 0;
			for (int i = 0; i < data.Length; i++)
			{
				x = data[i];
				switch (++state)
				{
					case 1:
						result.Append(Base128Chars[(x >> 1) & 0x7F]);
						break;
					case 2:
						result.Append(Base128Chars[((old << 6) & 0x40) | ((x >> 2) & 0x3F)]);
						break;
					case 3:
						result.Append(Base128Chars[((old << 5) & 0x60) | ((x >> 3) & 0x1F)]);
						break;
					case 4:
						result.Append(Base128Chars[((old << 4) & 0x70) | ((x >> 4) & 0x0F)]);
						break;
					case 5:
						result.Append(Base128Chars[((old << 3) & 0x78) | ((x >> 5) & 0x07)]);
						break;
					case 6:
						result.Append(Base128Chars[((old << 2) & 0x7C) | ((x >> 6) & 0x03)]);
						break;
					case 7:
						result.Append(Base128Chars[((old << 1) & 0x7E) | ((x >> 7) & 0x01)]);
						result.Append(Base128Chars[x & 0x7F]);
						state = 0;
						break;
				}
				old = x;
			}

			switch (state)
			{
				case 1:
					result.Append(Base128Chars[(old << 6) & 0x40]);
					result.Append(Special, 6);
					break;
				case 2:
					result.Append(Base128Chars[((old << 5) & 0x60)]);
					result.Append(Special, 5);
					break;
				case 3:
					result.Append(Base128Chars[((old << 4) & 0x70)]);
					result.Append(Special, 4);
					break;
				case 4:
					result.Append(Base128Chars[((old << 3) & 0x78)]);
					result.Append(Special, 3);
					break;
				case 5:
					result.Append(Base128Chars[((old << 2) & 0x7C)]);
					result.Append(Special, 2);
					break;
				case 6:
					result.Append(Base128Chars[((old << 1) & 0x7E)]);
					result.Append(Special);
					break;
			}

			return result.ToString();
		}

		public static byte[] FromBase128(string s)
		{
			int lastSpecialInd = s.Length;
			while (s[lastSpecialInd - 1] == Special)
				lastSpecialInd--;

			int length = (s.Length + 7) / 8 * 7 - (s.Length - lastSpecialInd);
			byte[] result = new byte[length];
			int dst = 0;

			for (int i = 0; i < s.Length; i++)
			{
				int code = Base128Chars.IndexOf(s[i]);
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

		public static string FromBase128ToString(string s)
		{
			return Encoding.UTF8.GetString(FromBase128(s));
		}
	}
}
