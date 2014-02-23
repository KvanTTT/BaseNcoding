using BaseNcoding.GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseNcoding.GUI
{
	public partial class frmMain : Form
	{
		public class ComboBoxItem
		{
			public string Text { get; set; }
			public object Value { get; set; }

			public ComboBoxItem()
			{
			}

			public ComboBoxItem(string text, object value)
			{
				Text = text;
				Value = value;
			}

			public override string ToString()
			{
				return Text;
			}
		}

		public ComboBoxItem[] Samples = 
		{
			new ComboBoxItem
			{
				Text = "Base64SampleString",
				Value = "Man is distinguished, not only by his reason, but by this singular passion from " +
				"other animals, which is a lust of the mind, that by a perseverance of delight " +
				"in the continued and indefatigable generation of knowledge, exceeds the short " +
				"vehemence of any carnal pleasure."
			},

			new ComboBoxItem
			{
				Text = "RusString",
				Value = "Зарегистрируйтесь сейчас на Десятую Международную Конференцию по " +
				"Unicode, которая состоится 10-12 марта 1997 года в Майнце в Германии. " +
				"Конференция соберет широкий круг экспертов по  вопросам глобального " +
				"Интернета и Unicode, локализации и интернационализации, воплощению и " +
				"применению Unicode в различных операционных системах и программных " +
				"приложениях, шрифтах, верстке и многоязычных компьютерных системах."
			},

			new ComboBoxItem
			{
				Text = "GreekString",
				Value = "Σὲ γνωρίζω ἀπὸ τὴν κόψη " +
				"τοῦ σπαθιοῦ τὴν τρομερή, " +
				"σὲ γνωρίζω ἀπὸ τὴν ὄψη " +
				"ποὺ μὲ βία μετράει τὴ γῆ. " +
				"᾿Απ᾿ τὰ κόκκαλα βγαλμένη " +
				"τῶν ῾Ελλήνων τὰ ἱερά " +
				"καὶ σὰν πρῶτα ἀνδρειωμένη " +
				"χαῖρε, ὦ χαῖρε, ᾿Ελευθεριά!"
			}
		};

		public frmMain()
		{
			InitializeComponent();

			var methods = new ComboBoxItem[]
			{
				new ComboBoxItem("Base32", "Base32"),
				new ComboBoxItem("Base64", "Base64"),
				new ComboBoxItem("Base128", "Base128"),
				new ComboBoxItem("Base256", "Base256"),
				new ComboBoxItem("Base1024", "Base1024"),
				new ComboBoxItem("Base4096", "Base4096"),
				new ComboBoxItem("ZBase32", "ZBase32"),
				new ComboBoxItem("Base85", "Base85"),
				new ComboBoxItem("Base91", "Base91"),
				new ComboBoxItem("BaseN", "BaseN")
			};
			cmbMethod.Items.AddRange(methods);

			cmbSample.Items.AddRange(Samples);

			var encodings = Encoding.GetEncodings();
			//cmbTextEncoding.Items.AddRange(encodings.Select(encoding => new ComboBoxItem(encoding.DisplayName, encoding)).ToArray());
			var textEncodingItems = new ComboBoxItem[]
			{
				new ComboBoxItem(Encoding.UTF8.EncodingName, Encoding.UTF8),
				new ComboBoxItem(Encoding.ASCII.EncodingName, Encoding.ASCII),
				new ComboBoxItem(Encoding.BigEndianUnicode.EncodingName, Encoding.BigEndianUnicode),
				new ComboBoxItem(Encoding.Default.EncodingName, Encoding.Default),
				new ComboBoxItem(Encoding.Unicode.EncodingName, Encoding.Unicode),
				new ComboBoxItem(Encoding.UTF32.EncodingName, Encoding.UTF32),
				new ComboBoxItem(Encoding.UTF7.EncodingName, Encoding.UTF7)
			};
			cmbTextEncoding.Items.AddRange(textEncodingItems);

			var savedMethod = methods.FirstOrDefault(item => item.Text == Settings.Default.Method);
			if (savedMethod != null)
			{
				cmbMethod.SelectedItem = savedMethod;
				tbSpecialChar.Text = Settings.Default.SpecialChar.ToString();
				tbAlphabet.Text = Settings.Default.Alphabet;
				cbPrefixPostfix.Checked = Settings.Default.PrefixPostfix;
			}
			else
			{
				cmbMethod.SelectedItem = methods.FirstOrDefault(item => item.Text == "Base64");
			}

			nudLineLength.Value = Settings.Default.MaxLineLength;

			cmbTextEncoding.SelectedItem =
				textEncodingItems.FirstOrDefault(item => item.Text == Settings.Default.TextEncoding) ??
				textEncodingItems[0];

			var savedSample = Samples.FirstOrDefault(item => item.Text == Settings.Default.Samlpe);
			if (savedSample != null)
			{
				cmbSample.SelectedItem = savedSample;
				tbInput.Text = Settings.Default.InputText;
			}
			else
			{
				cmbSample.SelectedItem = Samples[0];
			}

			nudGeneratingTextCharCount.Value = Settings.Default.GeneratingTextCharCount;
			cbOnlyLettersAndDigits.Checked = Settings.Default.GenerateOnlyLettersAndDigits;
			cbParallel.Checked = Settings.Default.Parallel;
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			Settings.Default.Method = cmbMethod.SelectedItem.ToString();
			Settings.Default.MaxLineLength = (int)nudLineLength.Value;
			Settings.Default.SpecialChar = string.IsNullOrEmpty(tbSpecialChar.Text) ? '\0' : tbSpecialChar.Text[0];
			Settings.Default.Alphabet = tbAlphabet.Text;
			Settings.Default.PrefixPostfix = cbPrefixPostfix.Checked;
			Settings.Default.TextEncoding = cmbTextEncoding.SelectedItem.ToString();
			Settings.Default.Samlpe = cmbSample.SelectedItem.ToString();
			Settings.Default.InputText = tbInput.Text;
			Settings.Default.GeneratingTextCharCount = (int)nudGeneratingTextCharCount.Value;
			Settings.Default.GenerateOnlyLettersAndDigits = cbOnlyLettersAndDigits.Checked;
			Settings.Default.Parallel = cbParallel.Checked;

			Settings.Default.Save();
		}

		private void btnEncodeDecode_Click(object sender, EventArgs e)
		{
			try
			{
				Base method = GetMethod();
				bool encode = (string)(((Button)sender).Tag) == "encode";
				string result;

				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				result = encode ? method.EncodeString(tbInput.Text) : method.DecodeToString(tbInput.Text);
				stopwatch.Stop();
				tbOutput.Text = result;
				tbTime.Text = stopwatch.Elapsed.ToString();

				tbOutputLength.Text = result.Length.ToString();
				tbOutputSize.Text = method.Encoding.GetByteCount(result).ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private Base GetMethod()
		{
			Base method = null;
			string alphabet = tbAlphabet.Text;
			if (tbSpecialChar.Text.Length > 1)
				throw new ArgumentException("Special char should contains one symbol");
			char special = string.IsNullOrWhiteSpace(tbSpecialChar.Text) ? (char)0 : tbSpecialChar.Text[0];
			Encoding textEncoding = cmbTextEncoding.SelectedItem != null ?
				(Encoding)((ComboBoxItem)cmbTextEncoding.SelectedItem).Value : null;
			bool parallel = cbParallel.Checked;
			switch (cmbMethod.SelectedItem.ToString())
			{
				case "Base32":
					method = new Base32(alphabet, special, textEncoding);
					break;
				case "Base64":
					method = new Base64(alphabet, special, textEncoding, parallel);
					break;
				case "Base128":
					method = new Base128(alphabet, special, textEncoding);
					break;
				case "Base256":
					method = new Base256(alphabet, special, textEncoding);
					break;
				case "Base1024":
					method = new Base1024(alphabet, special, textEncoding);
					break;
				case "Base4096":
					method = new Base4096(alphabet, special, textEncoding);
					break;
				case "ZBase32":
					method = new ZBase32(alphabet, special, textEncoding);
					break;
				case "Base85":
					method = new Base85(alphabet, special, cbPrefixPostfix.Checked, textEncoding);
					break;
				case "Base91":
					method = new Base91(alphabet, special, textEncoding);
					break;
				case "BaseN":
					method = new BaseN(alphabet, 32, textEncoding, parallel);
					break;
			}
			return method;
		}

		private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbPrefixPostfix.Enabled = false;
			cbPrefixPostfix.Checked = false;
			nudAlphabetLength.Enabled = false;
			switch (cmbMethod.SelectedItem.ToString())
			{
				case "Base32":
					tbAlphabet.Text = Base32.DefaultAlphabet;
					tbSpecialChar.Text = Base32.DefaultSpecial.ToString();
					break;
				case "Base64":
					tbAlphabet.Text = Base64.DefaultAlphabet;
					tbSpecialChar.Text = Base64.DefaultSpecial.ToString();
					break;
				case "Base128":
					tbAlphabet.Text = Base128.DefaultAlphabet;
					tbSpecialChar.Text = Base128.DefaultSpecial.ToString();
					break;
				case "Base256":
					tbAlphabet.Text = Base256.DefaultAlphabet;
					tbSpecialChar.Text = Base256.DefaultSpecial.ToString();
					break;
				case "Base1024":
					tbAlphabet.Text = Base1024.DefaultAlphabet;
					tbSpecialChar.Text = Base1024.DefaultSpecial.ToString();
					break;
				case "Base4096":
					tbAlphabet.Text = Base4096.DefaultAlphabet;
					tbSpecialChar.Text = Base4096.DefaultSpecial.ToString();
					break;
				case "ZBase32":
					tbAlphabet.Text = ZBase32.DefaultAlphabet;
					tbSpecialChar.Text = ZBase32.DefaultSpecial.ToString();
					break;
				case "Base85":
					cbPrefixPostfix.Enabled = true;
					tbAlphabet.Text = Base85.DefaultAlphabet;
					tbSpecialChar.Text = Base85.DefaultSpecial.ToString();
					break;
				case "Base91":
					tbAlphabet.Text = Base91.DefaultAlphabet;
					tbSpecialChar.Text = Base91.DefaultSpecial.ToString();
					break;
				case "BaseN":
					tbAlphabet.Text = Alphabet.Generate((int)nudAlphabetLength.Value);
					tbSpecialChar.Text = "";
					nudAlphabetLength.Enabled = true;
					break;
			}
			nudAlphabetLength.Value = GetMethod().CharsCount;
			cmbSample_SelectedIndexChanged(sender, e);
		}

		private void tbTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				((TextBox)sender).SelectAll();
				e.SuppressKeyPress = true;
			}
		}

		private void btnSwapInputOutput_Click(object sender, EventArgs e)
		{
			string t = tbInput.Text;
			tbInput.Text = tbOutput.Text;
			tbOutput.Text = t;
		}

		private void cmbSample_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbSample.SelectedItem as ComboBoxItem != null)
			{
				var b = ((ComboBoxItem)cmbSample.SelectedItem).Value;
				tbInput.Text = b.ToString();
				tbInputLength.Text = tbInput.Text.Length.ToString();
				tbOutput.Clear();
				tbOutputLength.Text = "0";
				tbOutputSize.Text = "0";
			}
		}

		private void tbInput_TextChanged(object sender, EventArgs e)
		{
			tbInputLength.Text = tbInput.Text.Length.ToString();
		}

		private void btnGenerateInputText_Click(object sender, EventArgs e)
		{
			tbInput.Text = RandomString((int)nudGeneratingTextCharCount.Value, cbOnlyLettersAndDigits.Checked);
			tbOutput.Clear();
			tbOutputLength.Text = "0";
			tbOutputSize.Text = "0";
		}

		public static string RandomString(int size, bool onlyLettersAndDigits)
		{
			Random r = new Random();
			if (onlyLettersAndDigits)
			{
				string lettersAndDigits = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
				StringBuilder result = new StringBuilder(size);
				for (int i = 0; i < size; i++)
					result.Append(lettersAndDigits[r.Next(lettersAndDigits.Length)]);
				return result.ToString();
			}
			else
			{
				var data = new byte[size];
				for (int i = 0; i < size; i++)
					data[i] = (byte)r.Next(32, 127);
				var encoding = new ASCIIEncoding();
				return encoding.GetString(data);
			}
		}

		private void btnGenerateAlphabet_Click(object sender, EventArgs e)
		{
			tbAlphabet.Text = Alphabet.Generate((int)nudAlphabetLength.Value);
		}
	}
}
