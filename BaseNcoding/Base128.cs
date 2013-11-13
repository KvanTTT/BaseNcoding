using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding
{
	public class Base128 : BaseN
	{
		public const string DefaultAlphabet = "!#$%()*,.0123456789:;-@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«¬®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎ";
		public const char DefaultSpecial = '=';

		public Base128(string alphabet = DefaultAlphabet, char special = DefaultSpecial)
			: base(128, alphabet, special)
		{
		}

		public override string Encode(byte[] data)
		{
			int dataLength = data.Length;
			StringBuilder result = new StringBuilder((dataLength + 6) / 7 * 8);

			byte x1, x2;
			int i;

			int length7 = (dataLength / 7) * 7;
			for (i = 0; i < length7; i += 7)
			{
				x1 = data[i];
				result.Append(Alphabet[x1 >> 1]);

				x2 = data[i + 1];
				result.Append(Alphabet[((x1 << 6) & 0x40) | (x2 >> 2)]);

				x1 = data[i + 2];
				result.Append(Alphabet[((x2 << 5) & 0x60) | (x1 >> 3)]);

				x2 = data[i + 3];
				result.Append(Alphabet[((x1 << 4) & 0x70) | (x2 >> 4)]);

				x1 = data[i + 4];
				result.Append(Alphabet[((x2 << 3) & 0x78) | (x1 >> 5)]);

				x2 = data[i + 5];
				result.Append(Alphabet[((x1 << 2) & 0x7C) | (x2 >> 6)]);

				x1 = data[i + 6];
				result.Append(Alphabet[((x2 << 1) & 0x7E) | (x1 >> 7)]);
				result.Append(Alphabet[x1 & 0x7F]);
			}

			switch (dataLength - length7)
			{
				case 1:
					x1 = data[i];
					result.Append(Alphabet[x1 >> 1]);
					result.Append(Alphabet[(x1 << 6) & 0x40]);
					
					result.Append(Special, 6);
					break;
				case 2:
					x1 = data[i];
					result.Append(Alphabet[x1 >> 1]);
					x2 = data[i + 1];
					result.Append(Alphabet[((x1 << 6) & 0x40) | (x2 >> 2)]);
					result.Append(Alphabet[((x2 << 5) & 0x60)]);

					result.Append(Special, 5);
					break;
				case 3:
					x1 = data[i];
					result.Append(Alphabet[x1 >> 1]);
					x2 = data[i + 1];
					result.Append(Alphabet[((x1 << 6) & 0x40) | (x2 >> 2)]);
					x1 = data[i + 2];
					result.Append(Alphabet[((x2 << 5) & 0x60) | (x1 >> 3)]);
					result.Append(Alphabet[(x1 << 4) & 0x70]);

					result.Append(Special, 4);
					break;
				case 4:
					x1 = data[i];
					result.Append(Alphabet[x1 >> 1]);
					x2 = data[i + 1];
					result.Append(Alphabet[((x1 << 6) & 0x40) | (x2 >> 2)]);
					x1 = data[i + 2];
					result.Append(Alphabet[((x2 << 5) & 0x60) | (x1 >> 3)]);
					x2 = data[i + 3];
					result.Append(Alphabet[((x1 << 4) & 0x70) | (x2 >> 4)]);
					result.Append(Alphabet[(x2 << 3) & 0x78]);

					result.Append(Special, 3);
					break;
				case 5:
					x1 = data[i];
					result.Append(Alphabet[x1 >> 1]);
					x2 = data[i + 1];
					result.Append(Alphabet[((x1 << 6) & 0x40) | (x2 >> 2)]);
					x1 = data[i + 2];
					result.Append(Alphabet[((x2 << 5) & 0x60) | (x1 >> 3)]);
					x2 = data[i + 3];
					result.Append(Alphabet[((x1 << 4) & 0x70) | (x2 >> 4)]);
					x1 = data[i + 4];
					result.Append(Alphabet[((x2 << 3) & 0x78) | (x1 >> 5)]);
					result.Append(Alphabet[(x1 << 2) & 0x7C]);

					result.Append(Special, 2);
					break;
				case 6:
					x1 = data[i];
					result.Append(Alphabet[x1 >> 1]);
					x2 = data[i + 1];
					result.Append(Alphabet[((x1 << 6) & 0x40) | (x2 >> 2)]);
					x1 = data[i + 2];
					result.Append(Alphabet[((x2 << 5) & 0x60) | (x1 >> 3)]);
					x2 = data[i + 3];
					result.Append(Alphabet[((x1 << 4) & 0x70) | (x2 >> 4)]);
					x1 = data[i + 4];
					result.Append(Alphabet[((x2 << 3) & 0x78) | (x1 >> 5)]);
					x2 = data[i + 5];
					result.Append(Alphabet[((x1 << 2) & 0x7C) | (x2 >> 6)]);
					result.Append(Alphabet[(x2 << 1) & 0x7E]);

					result.Append(Special);
					break;
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

			byte[] result = new byte[(data.Length + 7) / 8 * 7 - tailLength];
			int length7 = result.Length / 7 * 7;
			int x1, x2;

			int i, srcInd = 0;
			for (i = 0; i < length7; i += 7)
			{
				x1 = Alphabet.IndexOf(data[srcInd++]);
				x2 = Alphabet.IndexOf(data[srcInd++]);
				result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));

				x1 = Alphabet.IndexOf(data[srcInd++]);
				result[i + 1] = (byte)((x2 << 2) | ((x1 >> 5) & 0x03));

				x2 = Alphabet.IndexOf(data[srcInd++]);
				result[i + 2] = (byte)((x1 << 3) | ((x2 >> 4) & 0x07));

				x1 = Alphabet.IndexOf(data[srcInd++]);
				result[i + 3] = (byte)((x2 << 4) | ((x1 >> 3) & 0x0F));

				x2 = Alphabet.IndexOf(data[srcInd++]);
				result[i + 4] = (byte)((x1 << 5) | ((x2 >> 2) & 0x1F));

				x1 = Alphabet.IndexOf(data[srcInd++]);
				result[i + 5] = (byte)((x2 << 6) | ((x1 >> 1) & 0x3F));

				x2 = Alphabet.IndexOf(data[srcInd++]);
				result[i + 6] = (byte)((x1 << 7) | (x2 & 0x7F));
			}

			switch (tailLength)
			{
				case 6:
					x1 = Alphabet.IndexOf(data[srcInd++]);
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));
					break;
				case 5:
					x1 = Alphabet.IndexOf(data[srcInd++]);
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 1] = (byte)((x2 << 2) | ((x1 >> 5) & 0x03));
					break;
				case 4:
					x1 = Alphabet.IndexOf(data[srcInd++]);
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 1] = (byte)((x2 << 2) | ((x1 >> 5) & 0x03));
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 2] = (byte)((x1 << 3) | ((x2 >> 4) & 0x07));
					break;
				case 3:
					x1 = Alphabet.IndexOf(data[srcInd++]);
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 1] = (byte)((x2 << 2) | ((x1 >> 5) & 0x03));
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 2] = (byte)((x1 << 3) | ((x2 >> 4) & 0x07));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 3] = (byte)((x2 << 4) | ((x1 >> 3) & 0x0F));
					break;
				case 2:
					x1 = Alphabet.IndexOf(data[srcInd++]);
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 1] = (byte)((x2 << 2) | ((x1 >> 5) & 0x03));
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 2] = (byte)((x1 << 3) | ((x2 >> 4) & 0x07));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 3] = (byte)((x2 << 4) | ((x1 >> 3) & 0x0F));
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 4] = (byte)((x1 << 5) | ((x2 >> 2) & 0x1F));
					break;
				case 1:
					x1 = Alphabet.IndexOf(data[srcInd++]);
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i] = (byte)((x1 << 1) | ((x2 >> 6) & 0x01));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 1] = (byte)((x2 << 2) | ((x1 >> 5) & 0x03));
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 2] = (byte)((x1 << 3) | ((x2 >> 4) & 0x07));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 3] = (byte)((x2 << 4) | ((x1 >> 3) & 0x0F));
					x2 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 4] = (byte)((x1 << 5) | ((x2 >> 2) & 0x1F));
					x1 = Alphabet.IndexOf(data[srcInd++]);
					result[i + 5] = (byte)((x2 << 6) | ((x1 >> 1) & 0x3F));
					break;
			}

			return result;
		}
	}
}
