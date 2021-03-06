﻿using NUnit.Framework;
using System;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base64Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base64();
		}

		[TestCase(Base64SampleString)]
		[TestCase(RusString)]
		[TestCase(GreekString)]
		public void Base64CompareToStandard(string str)
		{
			string encoded = Converter.EncodeString(str);
			string base64Standard = Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

			Assert.AreEqual(base64Standard, encoded);
		}
	}
}
