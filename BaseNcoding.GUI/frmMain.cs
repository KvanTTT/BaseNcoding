using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

			cmbMethod.Items.Add("Base32");
			cmbMethod.Items.Add("Base64");
			cmbMethod.Items.Add("Base128");
			cmbMethod.Items.Add("Base256");
			cmbMethod.Items.Add("Base1024");
			cmbMethod.Items.Add("ZBase32");
			cmbMethod.Items.Add("Base85");
			cmbMethod.Items.Add("Base91");
			cmbMethod.SelectedIndex = 0;

			foreach (var sample in Samples)
				cmbSample.Items.Add(sample);
			cmbSample.SelectedIndex = 0;
		}

		private void btnEncode_Click(object sender, EventArgs e)
		{
			try
			{
				BaseN method = GetMethod();
				tbOutput.Text = method.EncodeString(tbInput.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void btnDecode_Click(object sender, EventArgs e)
		{
			try
			{
				BaseN method = GetMethod();
				tbOutput.Text = method.DecodeToString(tbInput.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private BaseN GetMethod()
		{
			BaseN method = null;
			string alphabet = tbAlphabet.Text;
			if (tbSpecialChar.Text.Length > 1)
				throw new ArgumentException("Special char should contains one symbol");
			char special = string.IsNullOrWhiteSpace(tbSpecialChar.Text) ? (char)0 : tbSpecialChar.Text[0];
			switch (cmbMethod.SelectedItem.ToString())
			{
				case "Base32":
					method = new Base32(alphabet, special);
					break;
				case "Base64":
					method = new Base64(alphabet, special);
					break;
				case "Base128":
					method = new Base128(alphabet, special);
					break;
				case "Base256":
					method = new Base256(alphabet, special);
					break;
				case "Base1024":
					method = new Base1024(alphabet, special);
					break;
				case "ZBase32":
					method = new ZBase32(alphabet, special);
					break;
				case "Base85":
					method = new Base85(alphabet, special, cbPrefixPostfix.Checked);
					break;
				case "Base91":
					method = new Base91(alphabet, special);
					break;
			}
			return method;
		}

		private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbPrefixPostfix.Enabled = false;
			cbPrefixPostfix.Checked = false;
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
			}
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
				tbInput.Text = (cmbSample.SelectedItem as ComboBoxItem).Value.ToString();
				tbOutput.Clear();
			}
		}
	}
}
