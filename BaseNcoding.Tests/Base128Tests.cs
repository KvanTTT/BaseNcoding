using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
