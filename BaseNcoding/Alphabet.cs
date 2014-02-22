using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding
{
	public static class Alphabet
	{
		public static string Generate(int charsCount)
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
	}
}
