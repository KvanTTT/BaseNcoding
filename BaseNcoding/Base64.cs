using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding
{
	/// <summary>
	/// http://www.herongyang.com/encoding/Base64-Sun-Java-Implementation.html
	/// </summary>
	public class Base64 : BaseN
	{
		public const string DefaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
		public const char DefaultSpecial = '=';

		public Base64(string alphabet = DefaultAlphabet, char special = DefaultSpecial)
			: base(64, alphabet, special)
		{
		}

		public override string Encode(byte[] data)
		{
			StringBuilder result = new StringBuilder((data.Length + 2) / 3 * 4);

			byte x = 0;
			int old = 0;
			int i;
			for (i = 0; i < data.Length; i++)
			{
				x = data[i];
				switch (i % 3)
				{
					case 0:
						result.Append(Alphabet[x >> 2]);
						break;
					case 1:
						result.Append(Alphabet[((old << 4) & 0x30) | (x >> 4)]);
						break;
					case 2:
						result.Append(Alphabet[((old << 2) & 0x3C) | (x >> 6)]);
						result.Append(Alphabet[x & 0x3F]);
						break;
				}
				old = x;
			}

			switch (i % 3)
			{
				case 1:
					result.Append(Alphabet[(old << 4) & 0x30]);
					result.Append(Special);
					result.Append(Special);
					break;
				case 2:
					result.Append(Alphabet[((old << 2) & 0x3C)]);
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

			int length = (data.Length + 3) / 4 * 3 - (data.Length - lastSpecialInd);
			byte[] result = new byte[length];
			int dst = 0;

			for (int i = 0; i < data.Length; i++)
			{
				int code = Alphabet.IndexOf(data[i]);
				if (code == -1)
					break;
				switch (i % 4)
				{
					case 0:
						result[dst] = (byte)(code << 2);
						break;
					case 1:
						result[dst++] |= (byte)((code >> 4) & 0x3);
						if (dst < length)
							result[dst] = (byte)(code << 4);
						break;
					case 2:
						result[dst++] |= (byte)((code >> 2) & 0xF);
						if (dst < length)
							result[dst] = (byte)(code << 6);
						break;
					case 3:
						result[dst++] |= (byte)(code & 0x3f);
						break;
				}
			}

			return result;
		}
	}
}
