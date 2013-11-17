using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseNcoding
{
	public class Base256 : BaseN
	{
		public const string DefaultAlphabet = "!#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳĴĵĶķĸĹĺĻļĽľĿŀŁł";
		public const char DefaultSpecial = (char)0;

		public override bool HaveSpecial
		{
			get { return false; }
		}

		public Base256(string alphabet = DefaultAlphabet, char special = DefaultSpecial)
			: base(256, alphabet, special)
		{
		}

		public override string Encode(byte[] data)
		{
			StringBuilder result = new StringBuilder(data.Length);

			for (int i = 0; i < data.Length; i++)
				result.Append(Alphabet[data[i]]);

			return result.ToString();
		}

		public override byte[] Decode(string data)
		{
			byte[] result = new byte[data.Length];

			for (int i = 0; i < data.Length; i++)
				result[i] = (byte)InvAlphabet[data[i]];

			return result;
		}
	}
}
