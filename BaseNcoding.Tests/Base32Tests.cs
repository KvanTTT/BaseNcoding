﻿using NUnit.Framework;
using System;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base32Tests : BaseNTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base32();
		}
	}
}