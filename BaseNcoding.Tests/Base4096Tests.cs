using NUnit.Framework;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base4096Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base4096();
		}
	}
}
