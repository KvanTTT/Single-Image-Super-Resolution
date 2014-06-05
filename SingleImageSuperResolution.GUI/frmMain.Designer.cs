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
            this.tbInputImage = new System.Windows.Forms.TextBox();
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
            this.nudDecIncrement = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbReplaceDistance = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudDecIncrement)).BeginInit();
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
            this.label7.Location = new System.Drawing.Point(10, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Output Superresolution";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(723, 103);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(100, 20);
            this.tbTime.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(687, 106);
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
            this.splitContainer1.Size = new System.Drawing.Size(766, 317);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Output Nearest Neighbour";
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
            this.pnlInterpolation.Size = new System.Drawing.Size(378, 298);
            this.pnlInterpolation.TabIndex = 20;
            this.pnlInterpolation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlInterpolation_Scroll);
            // 
            // pbOutputInterpolation
            // 
            this.pbOutputInterpolation.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pbOutputInterpolation.Location = new System.Drawing.Point(12, 13);
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
            this.pnlSR.Size = new System.Drawing.Size(384, 298);
            this.pnlSR.TabIndex = 12;
            this.pnlSR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pnlSR_Scroll);
            // 
            // pbOutputSuperResolution
            // 
            this.pbOutputSuperResolution.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pbOutputSuperResolution.Location = new System.Drawing.Point(13, 13);
            this.pbOutputSuperResolution.Name = "pbOutputSuperResolution";
            this.pbOutputSuperResolution.Size = new System.Drawing.Size(272, 235);
            this.pbOutputSuperResolution.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOutputSuperResolution.TabIndex = 8;
            this.pbOutputSuperResolution.TabStop = false;
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Location = new System.Drawing.Point(122, 130);
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
            this.btnOpenInputImage.Location = new System.Drawing.Point(197, 295);
            this.btnOpenInputImage.Name = "btnOpenInputImage";
            this.btnOpenInputImage.Size = new System.Drawing.Size(25, 20);
            this.btnOpenInputImage.TabIndex = 32;
            this.btnOpenInputImage.Text = "...";
            this.btnOpenInputImage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Block Size";
            // 
            // tbInputImage
            // 
            this.tbInputImage.Location = new System.Drawing.Point(25, 295);
            this.tbInputImage.Name = "tbInputImage";
            this.tbInputImage.Size = new System.Drawing.Size(166, 20);
            this.tbInputImage.TabIndex = 33;
            this.tbInputImage.Text = "..\\..\\..\\Samples\\Fractal Temple.jpg";
            // 
            // tbDecreaseRatio
            // 
            this.tbDecreaseRatio.Location = new System.Drawing.Point(122, 78);
            this.tbDecreaseRatio.Name = "tbDecreaseRatio";
            this.tbDecreaseRatio.Size = new System.Drawing.Size(100, 20);
            this.tbDecreaseRatio.TabIndex = 29;
            this.tbDecreaseRatio.Text = "1.25";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Input Image Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Decrease Ratio";
            // 
            // nudDecLevelsCount
            // 
            this.nudDecLevelsCount.Location = new System.Drawing.Point(122, 26);
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
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Dec Levels Count";
            // 
            // nudIncLevelsCount
            // 
            this.nudIncLevelsCount.Location = new System.Drawing.Point(122, 52);
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
            this.label8.Location = new System.Drawing.Point(22, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Inc Levels Count";
            // 
            // cbParallel
            // 
            this.cbParallel.AutoSize = true;
            this.cbParallel.Location = new System.Drawing.Point(25, 246);
            this.cbParallel.Name = "cbParallel";
            this.cbParallel.Size = new System.Drawing.Size(60, 17);
            this.cbParallel.TabIndex = 37;
            this.cbParallel.Text = "Parallel";
            this.cbParallel.UseVisualStyleBackColor = true;
            // 
            // tbIncreaseRatio
            // 
            this.tbIncreaseRatio.Location = new System.Drawing.Point(122, 104);
            this.tbIncreaseRatio.Name = "tbIncreaseRatio";
            this.tbIncreaseRatio.Size = new System.Drawing.Size(100, 20);
            this.tbIncreaseRatio.TabIndex = 39;
            this.tbIncreaseRatio.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Increase Ratio";
            // 
            // nudDecIncrement
            // 
            this.nudDecIncrement.Location = new System.Drawing.Point(122, 156);
            this.nudDecIncrement.Name = "nudDecIncrement";
            this.nudDecIncrement.Size = new System.Drawing.Size(100, 20);
            this.nudDecIncrement.TabIndex = 41;
            this.nudDecIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Dec Increment";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbReplaceDistance);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudDecIncrement);
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
            this.groupBox1.Controls.Add(this.tbInputImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnOpenInputImage);
            this.groupBox1.Controls.Add(this.nudBlockSize);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 371);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Replace Distance";
            // 
            // tbReplaceDistance
            // 
            this.tbReplaceDistance.Location = new System.Drawing.Point(122, 181);
            this.tbReplaceDistance.Name = "tbReplaceDistance";
            this.tbReplaceDistance.Size = new System.Drawing.Size(100, 20);
            this.tbReplaceDistance.TabIndex = 43;
            this.tbReplaceDistance.Text = "9999";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 625);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudDecIncrement)).EndInit();
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
        private System.Windows.Forms.TextBox tbInputImage;
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
        private System.Windows.Forms.NumericUpDown nudDecIncrement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbReplaceDistance;
    }
}

