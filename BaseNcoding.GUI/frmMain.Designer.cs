namespace BaseNcoding.GUI
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.cmbSample = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbInput = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.btnEncode = new System.Windows.Forms.Button();
			this.btnDecode = new System.Windows.Forms.Button();
			this.cmbMethod = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSpecialChar = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbAlphabet = new System.Windows.Forms.TextBox();
			this.cbPrefixPostfix = new System.Windows.Forms.CheckBox();
			this.btnSwapInputOutput = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbTextEncoding = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbOutputLength = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbInputLength = new System.Windows.Forms.TextBox();
			this.nudLineLength = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLineLength)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cmbSample);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.tbInput);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.tbOutput);
			this.splitContainer1.Size = new System.Drawing.Size(568, 655);
			this.splitContainer1.SplitterDistance = 319;
			this.splitContainer1.TabIndex = 3;
			// 
			// cmbSample
			// 
			this.cmbSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSample.FormattingEnabled = true;
			this.cmbSample.Location = new System.Drawing.Point(59, 5);
			this.cmbSample.Name = "cmbSample";
			this.cmbSample.Size = new System.Drawing.Size(121, 21);
			this.cmbSample.TabIndex = 3;
			this.cmbSample.SelectedIndexChanged += new System.EventHandler(this.cmbSample_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(5, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Input";
			// 
			// tbInput
			// 
			this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInput.Location = new System.Drawing.Point(3, 29);
			this.tbInput.Multiline = true;
			this.tbInput.Name = "tbInput";
			this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbInput.Size = new System.Drawing.Size(562, 287);
			this.tbInput.TabIndex = 1;
			this.tbInput.Text = resources.GetString("tbInput.Text");
			this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
			this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(5, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Output";
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(3, 23);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbOutput.Size = new System.Drawing.Size(562, 306);
			this.tbOutput.TabIndex = 2;
			this.tbOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// btnEncode
			// 
			this.btnEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEncode.Location = new System.Drawing.Point(586, 425);
			this.btnEncode.Name = "btnEncode";
			this.btnEncode.Size = new System.Drawing.Size(114, 23);
			this.btnEncode.TabIndex = 4;
			this.btnEncode.Text = "Encode";
			this.btnEncode.UseVisualStyleBackColor = true;
			this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
			// 
			// btnDecode
			// 
			this.btnDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDecode.Location = new System.Drawing.Point(586, 454);
			this.btnDecode.Name = "btnDecode";
			this.btnDecode.Size = new System.Drawing.Size(114, 23);
			this.btnDecode.TabIndex = 5;
			this.btnDecode.Text = "Decode";
			this.btnDecode.UseVisualStyleBackColor = true;
			this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
			// 
			// cmbMethod
			// 
			this.cmbMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMethod.FormattingEnabled = true;
			this.cmbMethod.Location = new System.Drawing.Point(646, 23);
			this.cmbMethod.Name = "cmbMethod";
			this.cmbMethod.Size = new System.Drawing.Size(101, 21);
			this.cmbMethod.TabIndex = 6;
			this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(583, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Max Line Length";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(583, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Method";
			// 
			// tbSpecialChar
			// 
			this.tbSpecialChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSpecialChar.Location = new System.Drawing.Point(678, 80);
			this.tbSpecialChar.Name = "tbSpecialChar";
			this.tbSpecialChar.Size = new System.Drawing.Size(68, 20);
			this.tbSpecialChar.TabIndex = 12;
			this.tbSpecialChar.Text = "=";
			this.tbSpecialChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSpecialChar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(583, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Special Char";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(583, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Alphabet";
			// 
			// tbAlphabet
			// 
			this.tbAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAlphabet.Location = new System.Drawing.Point(586, 139);
			this.tbAlphabet.Multiline = true;
			this.tbAlphabet.Name = "tbAlphabet";
			this.tbAlphabet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbAlphabet.Size = new System.Drawing.Size(161, 194);
			this.tbAlphabet.TabIndex = 15;
			this.tbAlphabet.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
			this.tbAlphabet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// cbPrefixPostfix
			// 
			this.cbPrefixPostfix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPrefixPostfix.AutoSize = true;
			this.cbPrefixPostfix.Location = new System.Drawing.Point(586, 340);
			this.cbPrefixPostfix.Name = "cbPrefixPostfix";
			this.cbPrefixPostfix.Size = new System.Drawing.Size(83, 17);
			this.cbPrefixPostfix.TabIndex = 16;
			this.cbPrefixPostfix.Text = "PrefixPostfix";
			this.cbPrefixPostfix.UseVisualStyleBackColor = true;
			// 
			// btnSwapInputOutput
			// 
			this.btnSwapInputOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSwapInputOutput.Location = new System.Drawing.Point(706, 439);
			this.btnSwapInputOutput.Name = "btnSwapInputOutput";
			this.btnSwapInputOutput.Size = new System.Drawing.Size(40, 23);
			this.btnSwapInputOutput.TabIndex = 17;
			this.btnSwapInputOutput.Text = "↑↓";
			this.btnSwapInputOutput.UseVisualStyleBackColor = true;
			this.btnSwapInputOutput.Click += new System.EventHandler(this.btnSwapInputOutput_Click);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(583, 366);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Text Encoding";
			// 
			// cmbTextEncoding
			// 
			this.cmbTextEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTextEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTextEncoding.FormattingEnabled = true;
			this.cmbTextEncoding.Location = new System.Drawing.Point(587, 382);
			this.cmbTextEncoding.Name = "cmbTextEncoding";
			this.cmbTextEncoding.Size = new System.Drawing.Size(160, 21);
			this.cmbTextEncoding.TabIndex = 18;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(582, 528);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Output Length";
			// 
			// tbOutputLength
			// 
			this.tbOutputLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputLength.Location = new System.Drawing.Point(678, 525);
			this.tbOutputLength.Name = "tbOutputLength";
			this.tbOutputLength.ReadOnly = true;
			this.tbOutputLength.Size = new System.Drawing.Size(67, 20);
			this.tbOutputLength.TabIndex = 22;
			this.tbOutputLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(582, 502);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "Input Length";
			// 
			// tbInputLength
			// 
			this.tbInputLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInputLength.Location = new System.Drawing.Point(678, 499);
			this.tbInputLength.Name = "tbInputLength";
			this.tbInputLength.ReadOnly = true;
			this.tbInputLength.Size = new System.Drawing.Size(68, 20);
			this.tbInputLength.TabIndex = 20;
			this.tbInputLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// nudLineLength
			// 
			this.nudLineLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudLineLength.Location = new System.Drawing.Point(678, 54);
			this.nudLineLength.Name = "nudLineLength";
			this.nudLineLength.Size = new System.Drawing.Size(67, 20);
			this.nudLineLength.TabIndex = 24;
			this.nudLineLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 679);
			this.Controls.Add(this.nudLineLength);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbOutputLength);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tbInputLength);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cmbTextEncoding);
			this.Controls.Add(this.btnSwapInputOutput);
			this.Controls.Add(this.cbPrefixPostfix);
			this.Controls.Add(this.tbAlphabet);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbSpecialChar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbMethod);
			this.Controls.Add(this.btnDecode);
			this.Controls.Add(this.btnEncode);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmMain";
			this.Text = "BaseNcoder";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudLineLength)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Button btnEncode;
		private System.Windows.Forms.Button btnDecode;
		private System.Windows.Forms.ComboBox cmbMethod;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbSpecialChar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbAlphabet;
		private System.Windows.Forms.CheckBox cbPrefixPostfix;
		private System.Windows.Forms.Button btnSwapInputOutput;
		private System.Windows.Forms.ComboBox cmbSample;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbTextEncoding;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbOutputLength;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbInputLength;
		private System.Windows.Forms.NumericUpDown nudLineLength;
	}
}

