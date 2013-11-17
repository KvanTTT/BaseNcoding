using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseNcoding
{
	public abstract class BaseN
	{
		public uint Base
		{
			get;
			protected set;
		}

		public double BitsPerChar
		{
			get
			{
				return Math.Log(Base, 2);
			}
		}

		public string Alphabet
		{
			get;
			protected set;
		}

		public char Special
		{
			get;
			protected set;
		}

		public abstract bool HaveSpecial
		{
			get;
		}

		protected int[] InvAlphabet;

		public BaseN(uint b, string alphabet, char special)
		{
			if (alphabet.Length != b)
				throw new ArgumentException("Base string should contain " + b + " chars");

			for (int i = 0; i < b; i++)
				for (int j = i + 1; j < b; j++)
					if (alphabet[i] == alphabet[j])
						throw new ArgumentException("Base string should contain distinct chars");

			if (alphabet.Contains(special))
				throw new AggregateException("Base string should not contain special char");

			Base = b;
			Alphabet = alphabet;
			Special = special;

			InvAlphabet = new int[Alphabet.Max(c => c) + 1];

			for (int i = 0; i < InvAlphabet.Length; i++)
				InvAlphabet[i] = -1;

			for (int i = 0; i < b; i++)
				InvAlphabet[Alphabet[i]] = i;
		}

		public virtual string EncodeString(string data)
		{
			return Encode(Encoding.UTF8.GetBytes(data));
		}

		public abstract string Encode(byte[] data);

		public virtual string DecodeToString(string data)
		{
			return Encoding.UTF8.GetString(Decode(data));
		}

		public abstract byte[] Decode(string data);

		/// <summary>
		/// From: http://stackoverflow.com/a/600306/1046374
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static bool IsPowerOfTwo(uint x)
		{
			return (x & (x - 1)) == 0;
		}

		/// <summary>
		/// From: http://stackoverflow.com/a/13569863/1046374
		/// </summary>
		public static int LCM(int a, int b)
		{
			int num1, num2;
			if (a > b)
			{
				num1 = a;
				num2 = b;
			}
			else
			{
				num1 = b;
				num2 = a;
			}

			for (int i = 1; i <= num2; i++)
				if ((num1 * i) % num2 == 0)
					return i * num1;
			return num2;
		}
	}
}
