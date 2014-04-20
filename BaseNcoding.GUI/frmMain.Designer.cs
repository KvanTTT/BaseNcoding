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
			this.cbOnlyLettersAndDigits = new System.Windows.Forms.CheckBox();
			this.btnGenerateInputText = new System.Windows.Forms.Button();
			this.nudGeneratingTextCharCount = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
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
			this.label10 = new System.Windows.Forms.Label();
			this.tbTime = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbOutputSize = new System.Windows.Forms.TextBox();
			this.nudAlphabetLength = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.btnGenerateAlphabet = new System.Windows.Forms.Button();
			this.cbParallel = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbBitsPerChars = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.nudMaxBitsCount = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.tbRatio = new System.Windows.Forms.TextBox();
			this.cbReverseOrder = new System.Windows.Forms.CheckBox();
			this.cbMaxCompression = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudGeneratingTextCharCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAlphabetLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxBitsCount)).BeginInit();
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
			this.splitContainer1.Panel1.Controls.Add(this.cbOnlyLettersAndDigits);
			this.splitContainer1.Panel1.Controls.Add(this.btnGenerateInputText);
			this.splitContainer1.Panel1.Controls.Add(this.nudGeneratingTextCharCount);
			this.splitContainer1.Panel1.Controls.Add(this.label11);
			this.splitContainer1.Panel1.Controls.Add(this.cmbSample);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.tbInput);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.tbOutput);
			this.splitContainer1.Size = new System.Drawing.Size(577, 683);
			this.splitContainer1.SplitterDistance = 332;
			this.splitContainer1.TabIndex = 3;
			// 
			// cbOnlyLettersAndDigits
			// 
			this.cbOnlyLettersAndDigits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbOnlyLettersAndDigits.AutoSize = true;
			this.cbOnlyLettersAndDigits.Location = new System.Drawing.Point(270, 32);
			this.cbOnlyLettersAndDigits.Name = "cbOnlyLettersAndDigits";
			this.cbOnlyLettersAndDigits.Size = new System.Drawing.Size(132, 17);
			this.cbOnlyLettersAndDigits.TabIndex = 27;
			this.cbOnlyLettersAndDigits.Text = "Only Letters and Digits";
			this.cbOnlyLettersAndDigits.UseVisualStyleBackColor = true;
			// 
			// btnGenerateInputText
			// 
			this.btnGenerateInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateInputText.Location = new System.Drawing.Point(419, 27);
			this.btnGenerateInputText.Name = "btnGenerateInputText";
			this.btnGenerateInputText.Size = new System.Drawing.Size(132, 24);
			this.btnGenerateInputText.TabIndex = 26;
			this.btnGenerateInputText.Text = "Generate Input Text";
			this.btnGenerateInputText.UseVisualStyleBackColor = true;
			this.btnGenerateInputText.Click += new System.EventHandler(this.btnGenerateInputText_Click);
			// 
			// nudGeneratingTextCharCount
			// 
			this.nudGeneratingTextCharCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudGeneratingTextCharCount.Location = new System.Drawing.Point(346, 5);
			this.nudGeneratingTextCharCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.nudGeneratingTextCharCount.Name = "nudGeneratingTextCharCount";
			this.nudGeneratingTextCharCount.Size = new System.Drawing.Size(67, 20);
			this.nudGeneratingTextCharCount.TabIndex = 25;
			this.nudGeneratingTextCharCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudGeneratingTextCharCount.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.Location = new System.Drawing.Point(267, 6);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(73, 16);
			this.label11.TabIndex = 5;
			this.label11.Text = "Char Count";
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
			this.tbInput.Location = new System.Drawing.Point(3, 57);
			this.tbInput.Multiline = true;
			this.tbInput.Name = "tbInput";
			this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbInput.Size = new System.Drawing.Size(571, 272);
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
			this.tbOutput.Size = new System.Drawing.Size(571, 321);
			this.tbOutput.TabIndex = 2;
			this.tbOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// btnEncode
			// 
			this.btnEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEncode.Location = new System.Drawing.Point(646, 510);
			this.btnEncode.Name = "btnEncode";
			this.btnEncode.Size = new System.Drawing.Size(114, 23);
			this.btnEncode.TabIndex = 4;
			this.btnEncode.Tag = "encode";
			this.btnEncode.Text = "Encode";
			this.btnEncode.UseVisualStyleBackColor = true;
			this.btnEncode.Click += new System.EventHandler(this.btnEncodeDecode_Click);
			// 
			// btnDecode
			// 
			this.btnDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDecode.Location = new System.Drawing.Point(646, 539);
			this.btnDecode.Name = "btnDecode";
			this.btnDecode.Size = new System.Drawing.Size(114, 23);
			this.btnDecode.TabIndex = 5;
			this.btnDecode.Tag = "decode";
			this.btnDecode.Text = "Decode";
			this.btnDecode.UseVisualStyleBackColor = true;
			this.btnDecode.Click += new System.EventHandler(this.btnEncodeDecode_Click);
			// 
			// cmbMethod
			// 
			this.cmbMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMethod.FormattingEnabled = true;
			this.cmbMethod.Location = new System.Drawing.Point(658, 16);
			this.cmbMethod.Name = "cmbMethod";
			this.cmbMethod.Size = new System.Drawing.Size(101, 21);
			this.cmbMethod.TabIndex = 6;
			this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(596, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Max Line Length";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(595, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Method";
			// 
			// tbSpecialChar
			// 
			this.tbSpecialChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSpecialChar.Location = new System.Drawing.Point(687, 109);
			this.tbSpecialChar.Name = "tbSpecialChar";
			this.tbSpecialChar.Size = new System.Drawing.Size(72, 20);
			this.tbSpecialChar.TabIndex = 12;
			this.tbSpecialChar.Text = "=";
			this.tbSpecialChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSpecialChar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(595, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Special Char";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(598, 168);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Alphabet";
			// 
			// tbAlphabet
			// 
			this.tbAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAlphabet.Location = new System.Drawing.Point(600, 192);
			this.tbAlphabet.Multiline = true;
			this.tbAlphabet.Name = "tbAlphabet";
			this.tbAlphabet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbAlphabet.Size = new System.Drawing.Size(161, 142);
			this.tbAlphabet.TabIndex = 15;
			this.tbAlphabet.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
			this.tbAlphabet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTextBox_KeyDown);
			// 
			// cbPrefixPostfix
			// 
			this.cbPrefixPostfix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPrefixPostfix.AutoSize = true;
			this.cbPrefixPostfix.Location = new System.Drawing.Point(598, 385);
			this.cbPrefixPostfix.Name = "cbPrefixPostfix";
			this.cbPrefixPostfix.Size = new System.Drawing.Size(83, 17);
			this.cbPrefixPostfix.TabIndex = 16;
			this.cbPrefixPostfix.Text = "PrefixPostfix";
			this.cbPrefixPostfix.UseVisualStyleBackColor = true;
			// 
			// btnSwapInputOutput
			// 
			this.btnSwapInputOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSwapInputOutput.Location = new System.Drawing.Point(596, 526);
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
			this.label7.Location = new System.Drawing.Point(595, 464);
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
			this.cmbTextEncoding.Location = new System.Drawing.Point(599, 480);
			this.cmbTextEncoding.Name = "cmbTextEncoding";
			this.cmbTextEncoding.Size = new System.Drawing.Size(160, 21);
			this.cmbTextEncoding.TabIndex = 18;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(597, 619);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Output Length";
			// 
			// tbOutputLength
			// 
			this.tbOutputLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputLength.Location = new System.Drawing.Point(695, 616);
			this.tbOutputLength.Name = "tbOutputLength";
			this.tbOutputLength.ReadOnly = true;
			this.tbOutputLength.Size = new System.Drawing.Size(66, 20);
			this.tbOutputLength.TabIndex = 22;
			this.tbOutputLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(596, 593);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "Input Length";
			// 
			// tbInputLength
			// 
			this.tbInputLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInputLength.Location = new System.Drawing.Point(695, 590);
			this.tbInputLength.Name = "tbInputLength";
			this.tbInputLength.ReadOnly = true;
			this.tbInputLength.Size = new System.Drawing.Size(66, 20);
			this.tbInputLength.TabIndex = 20;
			this.tbInputLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// nudLineLength
			// 
			this.nudLineLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudLineLength.Location = new System.Drawing.Point(687, 83);
			this.nudLineLength.Name = "nudLineLength";
			this.nudLineLength.Size = new System.Drawing.Size(72, 20);
			this.nudLineLength.TabIndex = 24;
			this.nudLineLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(598, 671);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(30, 13);
			this.label10.TabIndex = 26;
			this.label10.Text = "Time";
			// 
			// tbTime
			// 
			this.tbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTime.Location = new System.Drawing.Point(634, 668);
			this.tbTime.Name = "tbTime";
			this.tbTime.ReadOnly = true;
			this.tbTime.Size = new System.Drawing.Size(127, 20);
			this.tbTime.TabIndex = 25;
			this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(597, 645);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(96, 13);
			this.label12.TabIndex = 28;
			this.label12.Text = "Output Size (bytes)";
			// 
			// tbOutputSize
			// 
			this.tbOutputSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputSize.Location = new System.Drawing.Point(695, 642);
			this.tbOutputSize.Name = "tbOutputSize";
			this.tbOutputSize.ReadOnly = true;
			this.tbOutputSize.Size = new System.Drawing.Size(66, 20);
			this.tbOutputSize.TabIndex = 27;
			this.tbOutputSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// nudAlphabetLength
			// 
			this.nudAlphabetLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudAlphabetLength.Location = new System.Drawing.Point(687, 58);
			this.nudAlphabetLength.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
			this.nudAlphabetLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudAlphabetLength.Name = "nudAlphabetLength";
			this.nudAlphabetLength.Size = new System.Drawing.Size(72, 20);
			this.nudAlphabetLength.TabIndex = 30;
			this.nudAlphabetLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudAlphabetLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(596, 60);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(31, 13);
			this.label13.TabIndex = 29;
			this.label13.Text = "Base";
			// 
			// btnGenerateAlphabet
			// 
			this.btnGenerateAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerateAlphabet.Location = new System.Drawing.Point(689, 163);
			this.btnGenerateAlphabet.Name = "btnGenerateAlphabet";
			this.btnGenerateAlphabet.Size = new System.Drawing.Size(72, 23);
			this.btnGenerateAlphabet.TabIndex = 31;
			this.btnGenerateAlphabet.Text = "Generate";
			this.btnGenerateAlphabet.UseVisualStyleBackColor = true;
			this.btnGenerateAlphabet.Click += new System.EventHandler(this.btnGenerateAlphabet_Click);
			// 
			// cbParallel
			// 
			this.cbParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbParallel.AutoSize = true;
			this.cbParallel.Location = new System.Drawing.Point(699, 568);
			this.cbParallel.Name = "cbParallel";
			this.cbParallel.Size = new System.Drawing.Size(60, 17);
			this.cbParallel.TabIndex = 32;
			this.cbParallel.Text = "Parallel";
			this.cbParallel.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(597, 343);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(73, 13);
			this.label14.TabIndex = 34;
			this.label14.Text = "Bits Per Chars";
			// 
			// tbBitsPerChars
			// 
			this.tbBitsPerChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBitsPerChars.Location = new System.Drawing.Point(688, 340);
			this.tbBitsPerChars.Name = "tbBitsPerChars";
			this.tbBitsPerChars.ReadOnly = true;
			this.tbBitsPerChars.Size = new System.Drawing.Size(72, 20);
			this.tbBitsPerChars.TabIndex = 33;
			this.tbBitsPerChars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(596, 138);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(78, 13);
			this.label15.TabIndex = 36;
			this.label15.Text = "Max Bits Count";
			// 
			// nudMaxBitsCount
			// 
			this.nudMaxBitsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudMaxBitsCount.Location = new System.Drawing.Point(687, 136);
			this.nudMaxBitsCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudMaxBitsCount.Name = "nudMaxBitsCount";
			this.nudMaxBitsCount.Size = new System.Drawing.Size(72, 20);
			this.nudMaxBitsCount.TabIndex = 37;
			this.nudMaxBitsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMaxBitsCount.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(598, 369);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 13);
			this.label16.TabIndex = 39;
			this.label16.Text = "Ratio";
			// 
			// tbRatio
			// 
			this.tbRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRatio.Location = new System.Drawing.Point(688, 366);
			this.tbRatio.Name = "tbRatio";
			this.tbRatio.ReadOnly = true;
			this.tbRatio.Size = new System.Drawing.Size(72, 20);
			this.tbRatio.TabIndex = 38;
			this.tbRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbReverseOrder
			// 
			this.cbReverseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbReverseOrder.AutoSize = true;
			this.cbReverseOrder.Location = new System.Drawing.Point(598, 408);
			this.cbReverseOrder.Name = "cbReverseOrder";
			this.cbReverseOrder.Size = new System.Drawing.Size(173, 17);
			this.cbReverseOrder.TabIndex = 40;
			this.cbReverseOrder.Text = "Reverse Order (for BaseN only)";
			this.cbReverseOrder.UseVisualStyleBackColor = true;
			// 
			// cbMaxCompression
			// 
			this.cbMaxCompression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbMaxCompression.AutoSize = true;
			this.cbMaxCompression.Location = new System.Drawing.Point(598, 431);
			this.cbMaxCompression.Name = "cbMaxCompression";
			this.cbMaxCompression.Size = new System.Drawing.Size(109, 17);
			this.cbMaxCompression.TabIndex = 42;
			this.cbMaxCompression.Text = "Max Compression";
			this.cbMaxCompression.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 707);
			this.Controls.Add(this.cbMaxCompression);
			this.Controls.Add(this.cbReverseOrder);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbRatio);
			this.Controls.Add(this.nudMaxBitsCount);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbBitsPerChars);
			this.Controls.Add(this.cbParallel);
			this.Controls.Add(this.btnGenerateAlphabet);
			this.Controls.Add(this.nudAlphabetLength);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.btnSwapInputOutput);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tbOutputSize);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbTime);
			this.Controls.Add(this.nudLineLength);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbOutputLength);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tbInputLength);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cmbTextEncoding);
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
			((System.ComponentModel.ISupportInitialize)(this.nudGeneratingTextCharCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLineLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAlphabetLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxBitsCount)).EndInit();
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
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbTime;
		private System.Windows.Forms.Button btnGenerateInputText;
		private System.Windows.Forms.NumericUpDown nudGeneratingTextCharCount;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox cbOnlyLettersAndDigits;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbOutputSize;
		private System.Windows.Forms.NumericUpDown nudAlphabetLength;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnGenerateAlphabet;
		private System.Windows.Forms.CheckBox cbParallel;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbBitsPerChars;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown nudMaxBitsCount;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbRatio;
		private System.Windows.Forms.CheckBox cbReverseOrder;
		private System.Windows.Forms.CheckBox cbMaxCompression;
	}
}

