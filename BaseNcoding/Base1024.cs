using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding
{
	public class Base1024 : BaseN
	{
		public const string DefaultAlphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzªµºÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýþÿĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳĴĵĶķĸĹĺĻļĽľĿŀŁłŃńŅņŇňŉŊŋŌōŎŏŐőŒœŔŕŖŗŘřŚśŜŝŞşŠšŢţŤťŦŧŨũŪūŬŭŮůŰűŲųŴŵŶŷŸŹźŻżŽžſƀƁƂƃƄƅƆƇƈƉƊƋƌƍƎƏƐƑƒƓƔƕƖƗƘƙƚƛƜƝƞƟƠơƢƣƤƥƦƧƨƩƪƫƬƭƮƯưƱƲƳƴƵƶƷƸƹƺƻƼƽƾƿǀǁǂǃǄǅǆǇǈǉǊǋǌǍǎǏǐǑǒǓǔǕǖǗǘǙǚǛǜǝǞǟǠǡǢǣǤǥǦǧǨǩǪǫǬǭǮǯǰǱǲǳǴǵǶǷǸǹǺǻǼǽǾǿȀȁȂȃȄȅȆȇȈȉȊȋȌȍȎȏȐȑȒȓȔȕȖȗȘșȚțȜȝȞȟȠȡȢȣȤȥȦȧȨȩȪȫȬȭȮȯȰȱȲȳȴȵȶȸȹȺȻȼȽȾȿɀɁɂɃɄɅɆɇɈɉɊɋɌɍɎɏɐɑɒɓɔɕɖɗɘəɚɛɜɝɞɟɠɡɢɣɤɥɦɧɨɩɪɫɬɭɮɯɰɱɲɳɴɵɶɷɸɹɺɻɼɽɾɿʀʁʂʃʄʅʆʇʈʉʊʋʌʍʎʏʐʑʒʓʔʕʖʗʘʙʚʛʜʝʞʟʠʡʢʣʤʥʦʧʨʩʪʫʬʭʮʯʰʱʲʳʴʵʶʷʸʹʺʻʼʽʾʿˀˁˆˇˈˉˊˋˌˍˎˏːˑˠˡˢˣˤˬˮʹͺͻͼͽΆΈΉΊΌΎΏΐΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩΪΫάέήίΰαβγδεζηθικλμνξοπρςστυφχψωϊϋόύώϐϑϒϓϔϕϖϗϘϙϚϛϜϝϞϟϠϡϢϣϤϥϦϧϨϩϪϫϬϭϮϯϰϱϲϳϴϵϷϸϹϺϻϼϽϾϿЀЁЂЃЄЅІЇЈЉЊЋЌЍЎЏАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюяѐёђѓєѕіїјљњћќѝўџѠѡѢѣѤѥѦѧѨѩѪѫѬѭѮѯѰѱѲѳѴѵѶѷѸѹѺѻѼѽѾѿҀҁҊҋҌҍҎҏҐґҒғҔҕҖҗҘҙҚқҜҝҞҟҠҡҢңҤҥҦҧҨҩҪҫҬҭҮүҰұҲҳҴҵҶҷҸҹҺһҼҽҾҿӀӁӂӃӄӅӆӇӈӉӊӋӌӍӎӏӐӑӒӓӔӕӖӗӘәӚӛӜӝӞӟӠӡӢӣӤӥӦӧӨөӪӫӬӭӮӯӰӱӲӳӴӵӶӷӸӹӺӻӼӽӾӿԀԁԂԃԄԅԆԇԈԉԊԋԌԍԎԏԐԑԒԓԚԛԜԝԱԲԳԴԵԶԷԸԹԺԻԼԽԾԿՀՁՂՃՄՅՆՇՈՉՊՋՌՍՎՏՐՑՒՓՔ";
		public const char DefaultSpecial = '=';

		public Base1024(string alphabet = DefaultAlphabet, char special = DefaultSpecial, Encoding textEncoding = null)
			: base(1024, alphabet, special, textEncoding)
		{
		}

		public override bool HaveSpecial
		{
			get { return true; }
		}

		public override string Encode(byte[] data)
		{
			int dataLength = data.Length;
			StringBuilder result = new StringBuilder((dataLength + 4) / 5 * 4 + 1);

			int i;
			int x1, x2, x3, x4, x5;
			int length5 = (dataLength / 5) * 5;
			for (i = 0; i < length5; i += 5)
			{
				x1 = data[i];
				x2 = data[i + 1];
				x3 = data[i + 2];
				x4 = data[i + 3];
				x5 = data[i + 4];

				result.Append(Alphabet[x1 | ((x2 & 0x03) << 8)]);
				result.Append(Alphabet[(x2 >> 2) | ((x3 & 0x0F) << 6)]);
				result.Append(Alphabet[(x3 >> 4) | ((x4 & 0x3F) << 4)]);
				result.Append(Alphabet[(x4 >> 6) | (x5 << 2)]);
			}

			switch (dataLength - length5)
			{
				case 1:
					x1 = data[i];

					result.Append(Alphabet[x1]);
					result.Append(Special, 4);
					break;
				case 2:
					x1 = data[i];
					x2 = data[i + 1];

					result.Append(Alphabet[x1 | ((x2 & 0x03) << 8)]);
					result.Append(Alphabet[x2 >> 2]);
					result.Append(Special, 3);
					break;
				case 3:
					x1 = data[i];
					x2 = data[i + 1];
					x3 = data[i + 2];

					result.Append(Alphabet[x1 | ((x2 & 0x03) << 8)]);
					result.Append(Alphabet[(x2 >> 2) | ((x3 & 0x0F) << 6)]);
					result.Append(Alphabet[x3 >> 4]);
					result.Append(Special, 2);
					break;
				case 4:
					x1 = data[i];
					x2 = data[i + 1];
					x3 = data[i + 2];
					x4 = data[i + 3];

					result.Append(Alphabet[x1 | ((x2 & 0x03) << 8)]);
					result.Append(Alphabet[(x2 >> 2) | ((x3 & 0x0F) << 6)]);
					result.Append(Alphabet[(x3 >> 4) | ((x4 & 0x3F) << 4)]);
					result.Append(Alphabet[x4 >> 6]);
					result.Append(Special);
					break;
			}

			return result.ToString();
		}

		public override byte[] Decode(string data)
		{
			if (string.IsNullOrEmpty(data))
				return new byte[0];

			int lastSpecialInd = data.Length;
			while (data[lastSpecialInd - 1] == Special)
				lastSpecialInd--;
			int tailLength = data.Length - lastSpecialInd;

			byte[] result = new byte[data.Length / 4 * 5 - tailLength];

			int i, srcInd = 0;
			int x1, x2, x3, x4;
			int length5 = (data.Length / 4 - 1) * 5;
			for (i = 0; i < length5; i += 5)
			{
				x1 = InvAlphabet[data[srcInd++]];
				x2 = InvAlphabet[data[srcInd++]];
				x3 = InvAlphabet[data[srcInd++]];
				x4 = InvAlphabet[data[srcInd++]];

				result[i] = (byte)x1;
				result[i + 1] = (byte)((x1 >> 8) & 0x03 | (x2 << 2));
				result[i + 2] = (byte)((x2 >> 6) & 0x0F | (x3 << 4));
				result[i + 3] = (byte)((x3 >> 4) & 0x3F | (x4 << 6));
				result[i + 4] = (byte)(x4 >> 2);
			}
			if (tailLength == 0)
			{
				x1 = InvAlphabet[data[srcInd++]];
				x2 = InvAlphabet[data[srcInd++]];
				x3 = InvAlphabet[data[srcInd++]];
				x4 = InvAlphabet[data[srcInd++]];

				result[i] = (byte)x1;
				result[i + 1] = (byte)((x1 >> 8) & 0x03 | (x2 << 2));
				result[i + 2] = (byte)((x2 >> 6) & 0x0F | (x3 << 4));
				result[i + 3] = (byte)((x3 >> 4) & 0x3F | (x4 << 6));
				result[i + 4] = (byte)(x4 >> 2);
			}

			switch (tailLength)
			{
				case 4:
					x1 = InvAlphabet[data[srcInd++]];

					result[i] = (byte)x1;
					break;
				case 3:
					x1 = InvAlphabet[data[srcInd++]];
					x2 = InvAlphabet[data[srcInd++]];

					result[i] = (byte)x1;
					result[i + 1] = (byte)((x1 >> 8) & 0x03 | (x2 << 2));
					break;
				case 2:
					x1 = InvAlphabet[data[srcInd++]];
					x2 = InvAlphabet[data[srcInd++]];
					x3 = InvAlphabet[data[srcInd++]];

					result[i] = (byte)x1;
					result[i + 1] = (byte)((x1 >> 8) & 0x03 | (x2 << 2));
					result[i + 2] = (byte)((x2 >> 6) & 0x0F | (x3 << 4));
					break;
				case 1:
					x1 = InvAlphabet[data[srcInd++]];
					x2 = InvAlphabet[data[srcInd++]];
					x3 = InvAlphabet[data[srcInd++]];
					x4 = InvAlphabet[data[srcInd++]];

					result[i] = (byte)x1;
					result[i + 1] = (byte)((x1 >> 8) & 0x03 | (x2 << 2));
					result[i + 2] = (byte)((x2 >> 6) & 0x0F | (x3 << 4));
					result[i + 3] = (byte)((x3 >> 4) & 0x3F | (x4 << 6));
					break;
			}

			return result;
		}
	}
}