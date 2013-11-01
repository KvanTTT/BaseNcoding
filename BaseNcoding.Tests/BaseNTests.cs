using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding.Tests
{
	[TestFixture]
	public abstract class BaseNTests
	{
		/// <summary>
		/// Sample from http://en.wikipedia.org/wiki/Base64#Examples
		/// </summary>
		public const string Base64SampleString = 
				"Man is distinguished, not only by his reason, but by this singular passion from " +
				"other animals, which is a lust of the mind, that by a perseverance of delight " +
				"in the continued and indefatigable generation of knowledge, exceeds the short " +
				"vehemence of any carnal pleasure.";

		public const string RusString =
				"Зарегистрируйтесь сейчас на Десятую Международную Конференцию по " +
				"Unicode, которая состоится 10-12 марта 1997 года в Майнце в Германии. " +
				"Конференция соберет широкий круг экспертов по  вопросам глобального " +
				"Интернета и Unicode, локализации и интернационализации, воплощению и " +
				"применению Unicode в различных операционных системах и программных " +
				"приложениях, шрифтах, верстке и многоязычных компьютерных системах.";

		public const string GreekString =
				"Σὲ γνωρίζω ἀπὸ τὴν κόψη " +
				"τοῦ σπαθιοῦ τὴν τρομερή, " +
				"σὲ γνωρίζω ἀπὸ τὴν ὄψη " +
				"ποὺ μὲ βία μετράει τὴ γῆ. " +
				"᾿Απ᾿ τὰ κόκκαλα βγαλμένη " +
				"τῶν ῾Ελλήνων τὰ ἱερά " +
				"καὶ σὰν πρῶτα ἀνδρειωμένη " +
				"χαῖρε, ὦ χαῖρε, ᾿Ελευθεριά!";

		protected BaseN Converter;

		[TestCase(Base64SampleString)]
		[TestCase(RusString)]
		[TestCase(GreekString)]
		public void EncodeDecodeTest(string str)
		{
			string encoded = Converter.EncodeString(str);
			string decoded = Converter.DecodeToString(encoded);

			Assert.AreEqual(str, decoded);
		}

		[Test]
		public void TailTests()
		{
			char testChar = 'a';
			StringBuilder strBuilder = new StringBuilder();

			if (BaseN.IsPowerOfTwo(Converter.Base) && Converter.BitsPerChar <= 8)
			{
				int bitsPerChar = (int)Converter.BitsPerChar;
				int bitsPerByte = 8;
				int charByteBitsLcm = BaseN.LCM(bitsPerByte, bitsPerChar);
				int maxTailLength = charByteBitsLcm / bitsPerByte - 1;
				for (int i = 0; i <= maxTailLength + 1; i++)
				{
					strBuilder.Append(testChar);
					string str = strBuilder.ToString();
					string encoded = Converter.EncodeString(str);
					Assert.AreEqual(maxTailLength - (i % (maxTailLength + 1)), encoded.Count(c => c == Converter.Special));
					Assert.AreEqual(str, Converter.DecodeToString(encoded));
				}
			}
		}
	}
}
