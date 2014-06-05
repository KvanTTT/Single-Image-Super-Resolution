namespace SingleImageSuperResolution.GUI
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbInput = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ofdInput = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlInterpolation = new System.Windows.Forms.Panel();
            this.pbOutputInterpolation = new System.Windows.Forms.PictureBox();
            this.pnlSR = new System.Windows.Forms.Panel();
            this.pbOutputSuperResolution = new System.Windows.Forms.PictureBox();
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.btnOpenInputImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInputImagesPath = new System.Windows.Forms.TextBox();
            this.tbDecreaseRatio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDecLevelsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudIncLevelsCount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbParallel = new System.Windows.Forms.CheckBox();
            this.tbIncreaseRatio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbInputImages = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbBlurSigma = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbBlurKernelSize = new System.Windows.Forms.TextBox();
            this.cbBlur = new System.Windows.Forms.CheckBox();
            this.cbRandomize = new System.Windows.Forms.CheckBox();
            this.tbOrigIncrement = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbDecIncrementRatio = new System.Windows.Forms.TextBox();
            this.tbReplaceDistance = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMinDistance = new System.Windows.Forms.TextBox();
            this.tbMaxDistance = new System.Windows.Forms.TextBox();
            this.tbAvgDistance = new System.Windows.Forms.TextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlInterpolation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutputInterpolation)).BeginInit();
            this.pnlSR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutputSuperResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecLevelsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncLevelsCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(684, 28);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(139, 24);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.pbInput);
            this.panel1.Location = new System.Drawing.Point(289, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 271);
            this.panel1.TabIndex = 10;
            // 
            // pbInput
            // 
            this.pbInput.Location = new System.Drawing.Point(3, 3);
            this.pbInput.Name = "pbInput";
            this.pbInput.Size = new System.Drawing.Size(272, 235);
            this.pbInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbInput.TabIndex = 8;
            this.pbInput.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(684, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 24);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Input";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Output Superresolution";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(721, 155);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(103, 20);
            this.tbTime.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(685, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Time";
            // 
            // ofdInput
            // 
            this.ofdInput.Filter = "bmp (*.bmp)|*.bmp|jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|tiff (*.tiff)|*.tiff";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(289, 302);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.pnlInterpolation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlSR);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Size = new System.Drawing.Size(766, 367);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Output Interpolation";
            // 
            // pnlInterpolation
            // 
            this.pnlInterpolation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInterpolation.AutoScroll = true;
            this.pnlInterpolation.BackColor = System.Drawing.Color.Moccasin;
            this.pnlInterpolation.Controls.Add(this.pbOutputInterpolation);
            this.pnlInterpolation.Location = new System.Drawing.Point(0, 19);
            this.pnlInterpolation.Name = "pnlInterpolation";
            this.pnlInterpolation.Size = new System.Drawing.Size(378, 348);
            this.pnlInterpolation.TabIndex = 20;
            this.pnlInterpolation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlInterpolation_Scroll);
            // 
            // pbOutputInterpolation
            // 
            this.pbOutputInterpolation.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pbOutputInterpolation.Location = new System.Drawing.Point(3, 3);
            this.pbOutputInterpolation.Name = "pbOutputInterpolation";
            this.pbOutputInterpolation.Size = new System.Drawing.Size(272, 235);
            this.pbOutputInterpolation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOutputInterpolation.TabIndex = 8;
            this.pbOutputInterpolation.TabStop = false;
            // 
            // pnlSR
            // 
            this.pnlSR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSR.AutoScroll = true;
            this.pnlSR.BackColor = System.Drawing.Color.Moccasin;
            this.pnlSR.Controls.Add(this.pbOutputSuperResolution);
            this.pnlSR.Location = new System.Drawing.Point(0, 19);
            this.pnlSR.Name = "pnlSR";
            this.pnlSR.Size = new System.Drawing.Size(384, 348);
            this.pnlSR.TabIndex = 12;
            this.pnlSR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlSR_Scroll);
            // 
            // pbOutputSuperResolution
            // 
            this.pbOutputSuperResolution.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pbOutputSuperResolution.Location = new System.Drawing.Point(3, 3);
            this.pbOutputSuperResolution.Name = "pbOutputSuperResolution";
            this.pbOutputSuperResolution.Size = new System.Drawing.Size(272, 235);
            this.pbOutputSuperResolution.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOutputSuperResolution.TabIndex = 8;
            this.pbOutputSuperResolution.TabStop = false;
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Location = new System.Drawing.Point(121, 129);
            this.nudBlockSize.Name = "nudBlockSize";
            this.nudBlockSize.Size = new System.Drawing.Size(100, 20);
            this.nudBlockSize.TabIndex = 31;
            this.nudBlockSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnOpenInputImage
            // 
            this.btnOpenInputImage.Location = new System.Drawing.Point(196, 384);
            this.btnOpenInputImage.Name = "btnOpenInputImage";
            this.btnOpenInputImage.Size = new System.Drawing.Size(25, 20);
            this.btnOpenInputImage.TabIndex = 32;
            this.btnOpenInputImage.Text = "...";
            this.btnOpenInputImage.UseVisualStyleBackColor = true;
            this.btnOpenInputImage.Click += new System.EventHandler(this.btnOpenInputImagesPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Block Size";
            // 
            // tbInputImagesPath
            // 
            this.tbInputImagesPath.Location = new System.Drawing.Point(24, 384);
            this.tbInputImagesPath.Name = "tbInputImagesPath";
            this.tbInputImagesPath.Size = new System.Drawing.Size(166, 20);
            this.tbInputImagesPath.TabIndex = 33;
            this.tbInputImagesPath.Text = "..\\..\\..\\Samples\\";
            this.tbInputImagesPath.TextChanged += new System.EventHandler(this.tbInputImagesPath_TextChanged);
            // 
            // tbDecreaseRatio
            // 
            this.tbDecreaseRatio.Location = new System.Drawing.Point(121, 77);
            this.tbDecreaseRatio.Name = "tbDecreaseRatio";
            this.tbDecreaseRatio.Size = new System.Drawing.Size(100, 20);
            this.tbDecreaseRatio.TabIndex = 29;
            this.tbDecreaseRatio.Text = "1.25";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Input Images Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Decrease Ratio";
            // 
            // nudDecLevelsCount
            // 
            this.nudDecLevelsCount.Location = new System.Drawing.Point(121, 25);
            this.nudDecLevelsCount.Name = "nudDecLevelsCount";
            this.nudDecLevelsCount.Size = new System.Drawing.Size(100, 20);
            this.nudDecLevelsCount.TabIndex = 26;
            this.nudDecLevelsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Dec Levels Count";
            // 
            // nudIncLevelsCount
            // 
            this.nudIncLevelsCount.Location = new System.Drawing.Point(121, 51);
            this.nudIncLevelsCount.Name = "nudIncLevelsCount";
            this.nudIncLevelsCount.Size = new System.Drawing.Size(100, 20);
            this.nudIncLevelsCount.TabIndex = 35;
            this.nudIncLevelsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Inc Levels Count";
            // 
            // cbParallel
            // 
            this.cbParallel.AutoSize = true;
            this.cbParallel.Location = new System.Drawing.Point(24, 271);
            this.cbParallel.Name = "cbParallel";
            this.cbParallel.Size = new System.Drawing.Size(60, 17);
            this.cbParallel.TabIndex = 37;
            this.cbParallel.Text = "Parallel";
            this.cbParallel.UseVisualStyleBackColor = true;
            // 
            // tbIncreaseRatio
            // 
            this.tbIncreaseRatio.Location = new System.Drawing.Point(121, 103);
            this.tbIncreaseRatio.Name = "tbIncreaseRatio";
            this.tbIncreaseRatio.Size = new System.Drawing.Size(100, 20);
            this.tbIncreaseRatio.TabIndex = 39;
            this.tbIncreaseRatio.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Increase Ratio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Dec Inc Ratio [0..1]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cmbInputImages);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbBlurSigma);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbBlurKernelSize);
            this.groupBox1.Controls.Add(this.cbBlur);
            this.groupBox1.Controls.Add(this.cbRandomize);
            this.groupBox1.Controls.Add(this.tbOrigIncrement);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tbDecIncrementRatio);
            this.groupBox1.Controls.Add(this.tbReplaceDistance);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbIncreaseRatio);
            this.groupBox1.Controls.Add(this.cbParallel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nudIncLevelsCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudDecLevelsCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbDecreaseRatio);
            this.groupBox1.Controls.Add(this.tbInputImagesPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnOpenInputImage);
            this.groupBox1.Controls.Add(this.nudBlockSize);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 522);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(22, 415);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "Images";
            // 
            // cmbInputImages
            // 
            this.cmbInputImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputImages.FormattingEnabled = true;
            this.cmbInputImages.Location = new System.Drawing.Point(24, 431);
            this.cmbInputImages.Name = "cmbInputImages";
            this.cmbInputImages.Size = new System.Drawing.Size(166, 21);
            this.cmbInputImages.TabIndex = 33;
            this.cmbInputImages.SelectedIndexChanged += new System.EventHandler(this.cmbInputImages_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(146, 324);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Sigma";
            // 
            // tbBlurSigma
            // 
            this.tbBlurSigma.Location = new System.Drawing.Point(188, 321);
            this.tbBlurSigma.Name = "tbBlurSigma";
            this.tbBlurSigma.Size = new System.Drawing.Size(47, 20);
            this.tbBlurSigma.TabIndex = 51;
            this.tbBlurSigma.Text = "1.4";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 324);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "Kernel Size";
            // 
            // tbBlurKernelSize
            // 
            this.tbBlurKernelSize.Location = new System.Drawing.Point(88, 321);
            this.tbBlurKernelSize.Name = "tbBlurKernelSize";
            this.tbBlurKernelSize.Size = new System.Drawing.Size(47, 20);
            this.tbBlurKernelSize.TabIndex = 49;
            this.tbBlurKernelSize.Text = "5";
            // 
            // cbBlur
            // 
            this.cbBlur.AutoSize = true;
            this.cbBlur.Location = new System.Drawing.Point(24, 294);
            this.cbBlur.Name = "cbBlur";
            this.cbBlur.Size = new System.Drawing.Size(44, 17);
            this.cbBlur.TabIndex = 47;
            this.cbBlur.Text = "Blur";
            this.cbBlur.UseVisualStyleBackColor = true;
            this.cbBlur.CheckedChanged += new System.EventHandler(this.cbBlur_CheckedChanged);
            // 
            // cbRandomize
            // 
            this.cbRandomize.AutoSize = true;
            this.cbRandomize.Location = new System.Drawing.Point(24, 248);
            this.cbRandomize.Name = "cbRandomize";
            this.cbRandomize.Size = new System.Drawing.Size(79, 17);
            this.cbRandomize.TabIndex = 31;
            this.cbRandomize.Text = "Randomize";
            this.cbRandomize.UseVisualStyleBackColor = true;
            // 
            // tbOrigIncrement
            // 
            this.tbOrigIncrement.Location = new System.Drawing.Point(121, 155);
            this.tbOrigIncrement.Name = "tbOrigIncrement";
            this.tbOrigIncrement.Size = new System.Drawing.Size(100, 20);
            this.tbOrigIncrement.TabIndex = 46;
            this.tbOrigIncrement.Text = "0.5";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 45;
            this.label16.Text = "Orig Inc Ratio [0..1]";
            // 
            // tbDecIncrementRatio
            // 
            this.tbDecIncrementRatio.Location = new System.Drawing.Point(121, 181);
            this.tbDecIncrementRatio.Name = "tbDecIncrementRatio";
            this.tbDecIncrementRatio.Size = new System.Drawing.Size(100, 20);
            this.tbDecIncrementRatio.TabIndex = 44;
            this.tbDecIncrementRatio.Text = "0";
            // 
            // tbReplaceDistance
            // 
            this.tbReplaceDistance.Location = new System.Drawing.Point(121, 207);
            this.tbReplaceDistance.Name = "tbReplaceDistance";
            this.tbReplaceDistance.Size = new System.Drawing.Size(100, 20);
            this.tbReplaceDistance.TabIndex = 43;
            this.tbReplaceDistance.Text = "9999";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Replace Distance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(685, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Min Distance";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(685, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Max Distance";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(686, 239);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Avg Distance";
            // 
            // tbMinDistance
            // 
            this.tbMinDistance.Location = new System.Drawing.Point(763, 186);
            this.tbMinDistance.Name = "tbMinDistance";
            this.tbMinDistance.ReadOnly = true;
            this.tbMinDistance.Size = new System.Drawing.Size(61, 20);
            this.tbMinDistance.TabIndex = 28;
            // 
            // tbMaxDistance
            // 
            this.tbMaxDistance.Location = new System.Drawing.Point(763, 210);
            this.tbMaxDistance.Name = "tbMaxDistance";
            this.tbMaxDistance.ReadOnly = true;
            this.tbMaxDistance.Size = new System.Drawing.Size(61, 20);
            this.tbMaxDistance.TabIndex = 29;
            // 
            // tbAvgDistance
            // 
            this.tbAvgDistance.Location = new System.Drawing.Point(763, 236);
            this.tbAvgDistance.Name = "tbAvgDistance";
            this.tbAvgDistance.ReadOnly = true;
            this.tbAvgDistance.Size = new System.Drawing.Size(61, 20);
            this.tbAvgDistance.TabIndex = 30;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(739, 115);
            this.progress.Maximum = 1000;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(312, 23);
            this.progress.TabIndex = 31;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(685, 122);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 32;
            this.label19.Text = "Progress";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 675);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.tbAvgDistance);
            this.Controls.Add(this.tbMaxDistance);
            this.Controls.Add(this.tbMinDistance);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnProcess);
            this.Name = "frmMain";
            this.Text = "Single Image Super Resolution";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInput)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlInterpolation.ResumeLayout(false);
            this.pnlInterpolation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutputInterpolation)).EndInit();
            this.pnlSR.ResumeLayout(false);
            this.pnlSR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutputSuperResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecLevelsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncLevelsCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbInput;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog ofdInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlInterpolation;
        private System.Windows.Forms.PictureBox pbOutputInterpolation;
        private System.Windows.Forms.Panel pnlSR;
        private System.Windows.Forms.PictureBox pbOutputSuperResolution;
        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.Button btnOpenInputImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInputImagesPath;
        private System.Windows.Forms.TextBox tbDecreaseRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDecLevelsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudIncLevelsCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbParallel;
        private System.Windows.Forms.TextBox tbIncreaseRatio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbReplaceDistance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMinDistance;
        private System.Windows.Forms.TextBox tbMaxDistance;
        private System.Windows.Forms.TextBox tbAvgDistance;
        private System.Windows.Forms.TextBox tbDecIncrementRatio;
        private System.Windows.Forms.TextBox tbOrigIncrement;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbRandomize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbBlurSigma;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbBlurKernelSize;
        private System.Windows.Forms.CheckBox cbBlur;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbInputImages;
        private System.Windows.Forms.Label label20;
    }
}

