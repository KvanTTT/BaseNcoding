using NUnit.Framework;

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
