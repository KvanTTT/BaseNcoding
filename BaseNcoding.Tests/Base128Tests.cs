﻿using NUnit.Framework;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base128Tests : BaseNTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base128();
		}
	}
}
