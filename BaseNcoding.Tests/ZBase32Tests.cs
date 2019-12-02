using NUnit.Framework;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class ZBase32Tests : BaseTests
	{
		[SetUp]
		public void SetUp()
		{
			Converter = new ZBase32();
		}
	}
}
