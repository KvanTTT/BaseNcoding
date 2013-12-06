using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class BitsArrayTests
	{
		[Test]
		public void AddBitsTest()
		{
			var bitsArray = new BitsArray(3);
			bitsArray.AddBits(32, 6);
			bitsArray.AddBits(32, 6);
			bitsArray.AddBits(32, 6);
			bitsArray.AddBits(32, 6);
			Assert.AreEqual(24, bitsArray.CurrentBitPos);
			var bytes = bitsArray.ToBytesArray();
			Assert.AreEqual(130, bytes[0]);
			Assert.AreEqual(8, bytes[1]);
			Assert.AreEqual(32, bytes[2]);
		}

		[Test]
		public void AddBitsTest2()
		{
			var bitsArray = new BitsArray(3);
			bitsArray.AddBits(33, 6);
			bitsArray.AddBits(33, 6);
			bitsArray.AddBits(33, 6);
			bitsArray.AddBits(33, 6);
			Assert.AreEqual(24, bitsArray.CurrentBitPos);
			var bytes = bitsArray.ToBytesArray();
			Assert.AreEqual(134, bytes[0]);
			Assert.AreEqual(24, bytes[1]);
			Assert.AreEqual(97, bytes[2]);
		}

		[Test]
		public void AddBitsTest3()
		{
			var bitsArray = new BitsArray(7);
			bitsArray.AddBits(8193, 14);
			bitsArray.AddBits(8193, 14);
			bitsArray.AddBits(8193, 14);
			bitsArray.AddBits(8193, 14);
			Assert.AreEqual(56, bitsArray.CurrentBitPos);
			var bytes = bitsArray.ToBytesArray();
			Assert.AreEqual(128, bytes[0]);
			Assert.AreEqual(6, bytes[1]);
			Assert.AreEqual(0, bytes[2]);
			Assert.AreEqual(24, bytes[3]);
			Assert.AreEqual(0, bytes[4]);
			Assert.AreEqual(96, bytes[5]);
			Assert.AreEqual(1, bytes[6]);
		}

		[Test]
		public void GetBitsTest2()
		{
			var bytes = new byte[] { 134, 24, 97 };
			var bitsArray = new BitsArray(bytes);
			Assert.AreEqual(33, bitsArray.GetBits(6));
			Assert.AreEqual(33, bitsArray.GetBits(6));
			Assert.AreEqual(33, bitsArray.GetBits(6));
			Assert.AreEqual(33, bitsArray.GetBits(6));
			Assert.AreEqual(24, bitsArray.CurrentBitPos);
		}

		[Test]
		public void GetBitsTest3()
		{
			var bytes = new byte[] { 128, 6, 0, 24, 0, 96, 1 };
			var bitsArray = new BitsArray(bytes);
			Assert.AreEqual(8193, bitsArray.GetBits(14));
			Assert.AreEqual(8193, bitsArray.GetBits(14));
			Assert.AreEqual(8193, bitsArray.GetBits(14));
			Assert.AreEqual(8193, bitsArray.GetBits(14));
			Assert.AreEqual(56, bitsArray.CurrentBitPos);
		}
	}
}
