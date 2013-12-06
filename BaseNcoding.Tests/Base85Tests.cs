using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base85Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base85();
		}

		[TestCase(Base64SampleString)]
		[TestCase(RusString)]
		[TestCase(GreekString)]
		public void PrefixPostfixTest(string str)
		{
			var converter = Converter as Base85;
			converter.PrefixPostfix = true;

			string encoded = converter.EncodeString(str);

			Assert.IsTrue(encoded.Contains(Base85.Prefix) && encoded.Contains(Base85.Postfix));

			string decoded = converter.DecodeToString(encoded);

			Assert.AreEqual(str, decoded);

			converter.PrefixPostfix = false;
		}
	}
}
