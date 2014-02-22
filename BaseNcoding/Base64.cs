using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding
{
	public class Base64 : Base
	{
		public const string DefaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
		public const char DefaultSpecial = '=';

		public override bool HaveSpecial
		{
			get { return true; }
		}

		public Base64(string alphabet = DefaultAlphabet, char special = DefaultSpecial, Encoding textEncoding = null)
			: base(64, alphabet, special, textEncoding)
		{
		}

		public override string Encode(byte[] data)
		{
			StringBuilder result = new StringBuilder((data.Length + 2) / 3 * 4);

			byte x1, x2;
			int i;
			string alphabet = Alphabet;

			int length3 = (data.Length / 3) * 3;
			for (i = 0; i < length3; i += 3)
			{
				x1 = data[i];
				result.Append(alphabet[x1 >> 2]);

				x2 = data[i + 1];
				result.Append(alphabet[((x1 << 4) & 0x30) | (x2 >> 4)]);

				x1 = data[i + 2];
				result.Append(alphabet[((x2 << 2) & 0x3C) | (x1 >> 6)]);
				result.Append(alphabet[x1 & 0x3F]);
			}

			switch (data.Length - length3)
			{
				case 1:
					x1 = data[i];
					result.Append(alphabet[x1 >> 2]);
					result.Append(alphabet[(x1 << 4) & 0x30]);

					result.Append(Special, 2);
					break;
				case 2:
					x1 = data[i];
					result.Append(alphabet[x1 >> 2]);
					x2 = data[i + 1];
					result.Append(alphabet[((x1 << 4) & 0x30) | (x2 >> 4)]);
					result.Append(alphabet[(x2 << 2) & 0x3C]);

					result.Append(Special);
					break;
			}

			return result.ToString();
		}

		public override byte[] Decode(string data)
		{
			unchecked
			{
				if (string.IsNullOrEmpty(data))
					return new byte[0];

				int lastSpecialInd = data.Length;
				while (data[lastSpecialInd - 1] == Special)
					lastSpecialInd--;
				int tailLength = data.Length - lastSpecialInd;

				byte[] result = new byte[(data.Length + 3) / 4 * 3 - tailLength];
				int length3 = result.Length / 3 * 3;
				int x1, x2;

				int i, srcInd = 0;
				for (i = 0; i < length3; i += 3)
				{
					x1 = InvAlphabet[data[srcInd++]];
					x2 = InvAlphabet[data[srcInd++]];
					result[i] = (byte)((x1 << 2) | ((x2 >> 4) & 0x3));

					x1 = InvAlphabet[data[srcInd++]];
					result[i + 1] = (byte)((x2 << 4) | ((x1 >> 2) & 0xF));

					x2 = InvAlphabet[data[srcInd++]];
					result[i + 2] = (byte)((x1 << 6) | (x2 & 0x3F));
				}

				switch (tailLength)
				{
					case 2:
						x1 = InvAlphabet[data[srcInd++]];
						x2 = InvAlphabet[data[srcInd++]];
						result[i] = (byte)((x1 << 2) | ((x2 >> 4) & 0x3));
						break;
					case 1:
						x1 = InvAlphabet[data[srcInd++]];
						x2 = InvAlphabet[data[srcInd++]];
						result[i] = (byte)((x1 << 2) | ((x2 >> 4) & 0x3));
						x1 = InvAlphabet[data[srcInd++]];
						result[i + 1] = (byte)((x2 << 4) | ((x1 >> 2) & 0xF));
						break;
				}

				return result;
			}
		}
	}
}
