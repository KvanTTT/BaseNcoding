using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding
{
	public static class StringGenerator
	{
		public static string GetAlphabet(int charsCount)
		{
			var result = new StringBuilder(charsCount);
			int i = 0;
			int count = 0;
			do
			{
				char c = (char)i;
				if (!char.IsControl(c) && !char.IsWhiteSpace(c))
				{
					result.Append(c);
					count++;
				}
				i++;
			}
			while (count < charsCount);

			return result.ToString();
		}

		public static string GetRandom(int size, bool onlyLettersAndDigits)
		{
			Random r = new Random();
			if (onlyLettersAndDigits)
			{
				string lettersAndDigits = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
				StringBuilder result = new StringBuilder(size);
				for (int i = 0; i < size; i++)
					result.Append(lettersAndDigits[r.Next(lettersAndDigits.Length)]);
				return result.ToString();
			}
			else
			{
				var data = new byte[size];
				for (int i = 0; i < size; i++)
					data[i] = (byte)r.Next(32, 127);
				var encoding = new ASCIIEncoding();
				return encoding.GetString(data);
			}
		}
	}
}
