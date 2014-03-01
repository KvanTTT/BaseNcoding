using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class BaseNTests
	{
		[Test]
		public void BaseNCompareToBase64()
		{
			string s = "aaa";
			var converter = new BaseN(Base64.DefaultAlphabet);
			string encoded = converter.EncodeString(s);
			string base64standart = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));

			Assert.AreEqual(base64standart, encoded);
		}

		[Test]
		public void GetOptimalBitsCount()
		{
			uint charsCountInBits;
			Assert.AreEqual(5, BaseN.GetOptimalBitsCount2(32, out charsCountInBits));
			Assert.AreEqual(6, BaseN.GetOptimalBitsCount2(64, out charsCountInBits));
			Assert.AreEqual(32, BaseN.GetOptimalBitsCount2(85, out charsCountInBits));
			Assert.AreEqual(13, BaseN.GetOptimalBitsCount2(91, out charsCountInBits));
		}

		[Test]
		public void EncodeDecodeBaseN()
		{
			byte testByte = 157;
			List<byte> bytes = new List<byte>();
			for (uint radix = 2; radix < 1000; radix++)
			{
				var baseN = new BaseN(StringGenerator.GetAlphabet((int)radix), 64);
				int testBytesCount = Math.Max((baseN.BlockBitsCount + 7) / 8, (int)baseN.BlockCharsCount);
				bytes.Clear();
				for (int i = 0; i <= testBytesCount + 1; i++)
				{
					var array = bytes.ToArray();
					var encoded = baseN.Encode(array);
					var decoded = baseN.Decode(encoded);
					CollectionAssert.AreEqual(array, decoded);
					bytes.Add(testByte);
				}
			}
		}

		[Test]
		public void EncodeDecodeBaseBigN()
		{
			byte testByte = 157;
			List<byte> bytes = new List<byte>();
			for (uint radix = 2; radix < 1000; radix++)
			{
				var baseN = new BaseBigN(StringGenerator.GetAlphabet((int)radix), 256);
				int testBytesCount = Math.Max((baseN.BlockBitsCount + 7) / 8, baseN.BlockCharsCount);
				bytes.Clear();
				for (int i = 0; i <= testBytesCount + 1; i++)
				{
					var array = bytes.ToArray();
					var encoded = baseN.Encode(array);
					var decoded = baseN.Decode(encoded);
					CollectionAssert.AreEqual(array, decoded);
					bytes.Add(testByte);
				}
			}
		}

		[Test]
		public void EncodeDecodeParallel()
		{
			var randomString = StringGenerator.GetRandom(10000000, true);
			var baseN = new BaseN(StringGenerator.GetAlphabet(85));

			var stopwatch = new Stopwatch();
			stopwatch.Start();
			var baseNEncoded = baseN.EncodeString(randomString);
			stopwatch.Stop();
			var baseNTime = stopwatch.Elapsed;

			stopwatch.Restart();
			baseN.Parallel = true;
			var baseNEncodedParallel = baseN.EncodeString(randomString);
			stopwatch.Stop();
			var baseNParallelTime = stopwatch.Elapsed;

			CollectionAssert.AreEqual(baseNEncoded, baseNEncodedParallel);
			Assert.Less(baseNParallelTime, baseNTime);
		}
	}
}
