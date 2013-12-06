using NUnit.Framework;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base256Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new Base256();
		}
	}
}
