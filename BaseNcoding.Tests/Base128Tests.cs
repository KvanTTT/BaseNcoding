using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public class Base128Tests
	{
		/// <summary>
		/// Sample from http://en.wikipedia.org/wiki/Base64
		/// </summary>
		[Test]
		public void Base64SampleTest()
		{
			string str =
				"Man is distinguished, not only by his reason, but by this singular passion from " +
				"other animals, which is a lust of the mind, that by a perseverance of delight " +
				"in the continued and indefatigable generation of knowledge, exceeds the short " +
				"vehemence of any carnal pleasure.";

			string base128 = BaseNConvert.ToBase128(str);
			string deserializedBase128 = BaseNConvert.FromBase128ToString(base128);

			Assert.AreEqual(str, deserializedBase128);
		}

		[Test]
		public void UnicodeRusTest()
		{
			string str =
				"Зарегистрируйтесь сейчас на Десятую Международную Конференцию по " +
				"Unicode, которая состоится 10-12 марта 1997 года в Майнце в Германии. " +
				"Конференция соберет широкий круг экспертов по  вопросам глобального " +
				"Интернета и Unicode, локализации и интернационализации, воплощению и " +
				"применению Unicode в различных операционных системах и программных " +
				"приложениях, шрифтах, верстке и многоязычных компьютерных системах.";

			string base128 = BaseNConvert.ToBase128(str);
			string deserializedBase128 = BaseNConvert.FromBase128ToString(base128);

			Assert.AreEqual(str, deserializedBase128);
		}

		[Test]
		public void UnicodeGreekTest()
		{
			string str =
				"Σὲ γνωρίζω ἀπὸ τὴν κόψη " +
				"τοῦ σπαθιοῦ τὴν τρομερή, " +
				"σὲ γνωρίζω ἀπὸ τὴν ὄψη " +
				"ποὺ μὲ βία μετράει τὴ γῆ. " +
				"᾿Απ᾿ τὰ κόκκαλα βγαλμένη " +
				"τῶν ῾Ελλήνων τὰ ἱερά " +
				"καὶ σὰν πρῶτα ἀνδρειωμένη " +
				"χαῖρε, ὦ χαῖρε, ᾿Ελευθεριά!";

			string base128 = BaseNConvert.ToBase128(str);
			string deserializedBase128 = BaseNConvert.FromBase128ToString(base128);

			Assert.AreEqual(str, deserializedBase128);
		}

		[Test]
		public void TailTests()
		{
			string str, base128;

			str = "a";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Zl------", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦J-----", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aaa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦V7----", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aaaa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦V@.---", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aaaaa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦V@2(--", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aaaaaa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦V@2)n-", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aaaaaaa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦V@2)n°", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));

			str = "aaaaaaaa";
			base128 = BaseNConvert.ToBase128(str);
			Assert.AreEqual("Z¦V@2)n°Zl------", base128);
			Assert.AreEqual(str, BaseNConvert.FromBase128ToString(base128));
		}
	}
}
