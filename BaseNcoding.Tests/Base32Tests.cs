using NUnit.Framework;
using System;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base32Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base32();
		}

		public const string Base32SampleString = "Ronald";
		public const string Base32SampleStringResult = "KJXW4YLMMQ======";

		[TestCase(Base32SampleString)]
		public void Base32EncodeCompareToConstantValue(string str)
		{
			string encoded = Converter.EncodeString(str);

			Assert.AreEqual(Base32SampleStringResult, encoded);
		}

		[TestCase(Base32SampleString)]
		public void Base32CompareEncodeandDecode(string str)
		{
			string encoded = Converter.EncodeString(str);
			string decoded = Converter.DecodeToString(encoded);

			Assert.AreEqual(decoded, encoded);
		}
	}
}
