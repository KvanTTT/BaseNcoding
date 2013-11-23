using NUnit.Framework;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base1024Tests : BaseNTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base1024();
		}
	}
}
