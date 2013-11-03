using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class ZBase32Tests : BaseNTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new ZBase32();
		}
	}
}
