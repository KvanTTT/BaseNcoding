using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base91Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base91();
		}
	}
}
