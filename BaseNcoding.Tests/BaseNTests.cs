using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class BaseNTests
	{
		[Test]
		public void Base64Test()
		{
			var baseN = new BaseN(64, Base64.DefaultAlphabet, Base64.DefaultSpecial);
			var base64 = new Base64();

			char testChar = 'a';
			StringBuilder strBuilder = new StringBuilder();

			int bitsPerChar = (int)base64.BitsPerChar;
			int bitsPerByte = 8;
			int charByteBitsLcm = Base.LCM(bitsPerByte, bitsPerChar);
			int maxTailLength = charByteBitsLcm / bitsPerByte - 1;
			for (int i = 0; i <= maxTailLength + 2; i++)
			{
				string str = strBuilder.ToString();

				var encoded = baseN.EncodeString(str);
				var decoded = baseN.DecodeToString(encoded);

				Assert.AreEqual(str, decoded);

				/*var encoded64 = base64.EncodeString(str);
				var decoded64 = base64.DecodeToString(encoded64);
				Assert.AreEqual(encoded64, encoded);
				Assert.AreEqual(decoded64, decoded);*/

				strBuilder.Append(testChar);
			}
		}

		[Test]
		public void Base85Test()
		{
			var baseN = new BaseN(85, Base85.DefaultAlphabet, '\\');

			char testChar = 'a';
			StringBuilder strBuilder = new StringBuilder();

			/*int bitsPerChar = (int)baseN.BitsPerChar;
			int bitsPerByte = 8;
			int charByteBitsLcm = Base.LCM(bitsPerByte, bitsPerChar);
			int maxTailLength = charByteBitsLcm / bitsPerByte - 1;*/
			for (int i = 0; i <= 10; i++)
			{
				string str = strBuilder.ToString();

				var encoded = baseN.EncodeString(str);
				var decoded = baseN.DecodeToString(encoded);

				Assert.AreEqual(str, decoded);
				strBuilder.Append(testChar);
			}
		}
	}
}
