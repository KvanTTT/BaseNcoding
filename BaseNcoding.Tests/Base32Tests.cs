using NUnit.Framework;

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

		private const string Base32SampleString = "Ronald";
		private const string Base32SampleStringResult = "KJXW4YLMMQ======";

		[TestCase(Base32SampleString)]
		public void Base32EncodeCompareEncodedAndExpected(string str)
		{
			string encoded = Converter.EncodeString(str);

			Assert.AreEqual(Base32SampleStringResult, encoded);
		}

		[TestCase(Base32SampleString)]
		public void Base32CompareSourceAndDecoded(string str)
		{
			string encoded = Converter.EncodeString(str);
			string decoded = Converter.DecodeToString(encoded);

			Assert.AreEqual(str, decoded);
		}
	}
}
