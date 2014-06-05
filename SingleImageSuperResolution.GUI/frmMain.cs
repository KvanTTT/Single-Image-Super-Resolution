using SingleImageSuperResolution.GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleImageSuperResolution.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            nudDecLevelsCount.Value = Settings.Default.DecLevelsCount;
            nudIncLevelsCount.Value = Settings.Default.IncLevelsCount;
            tbDecreaseRatio.Text = Settings.Default.DecreaseRatio.ToString();
            tbIncreaseRatio.Text = Settings.Default.IncreaseRatio.ToString();
            nudBlockSize.Value = Settings.Default.BlockSize;
            nudDecIncrement.Value = Settings.Default.DecIncrement;
            tbReplaceDistance.Text = Settings.Default.ReplaceDistance.ToString();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.DecLevelsCount = (int)nudDecLevelsCount.Value;
            Settings.Default.IncLevelsCount = (int)nudIncLevelsCount.Value;
            Settings.Default.DecreaseRatio = double.Parse(tbDecreaseRatio.Text);
            Settings.Default.IncreaseRatio = double.Parse(tbIncreaseRatio.Text);
            Settings.Default.BlockSize = (int)nudBlockSize.Value;
            Settings.Default.DecIncrement = (int)nudDecIncrement.Value;
            Settings.Default.ReplaceDistance = double.Parse(tbReplaceDistance.Text);
        }

        private void btnOpenInputImage_Click(object sender, EventArgs e)
        {
            ofdInput.FileName = tbInputImage.Text;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var input = new Bitmap(tbInputImage.Text);
            pbInput.Image = input;

            var stopwatch = Stopwatch.StartNew();

            var superResoultion = new SuperResolution(input)
            {
                BlockWidth = (int)nudBlockSize.Value,
                BlockHeight = (int)nudBlockSize.Value,
                DecLevelsCount = (int)nudDecLevelsCount.Value,
                DecZoomCoef = double.Parse(tbDecreaseRatio.Text),
                DecBlockWidth = (int)nudBlockSize.Value,
                DecBlockHeight = (int)nudBlockSize.Value,
                IncLevelsCount = (int)nudIncLevelsCount.Value,
                ZoomCoef = double.Parse(tbIncreaseRatio.Text),
                DecBlockIncX = (int)nudDecIncrement.Value,
                DecBlockIncY = (int)nudDecIncrement.Value,
                ReplaceDistance = double.Parse(tbReplaceDistance.Text),
                Parallelization = cbParallel.Checked
            };
            var restored = superResoultion.Process();

            stopwatch.Stop();
            tbTime.Text = stopwatch.Elapsed.ToString();

            pbOutputInterpolation.Image = new Bitmap(input,
                (int)Math.Round(input.Width * superResoultion.ZoomCoef),
                (int)Math.Round(input.Height * superResoultion.ZoomCoef));
            pbOutputSuperResolution.Image = restored;

            var extension = Path.GetExtension(tbInputImage.Text);
            var fileName = Path.GetFileNameWithoutExtension(tbInputImage.Text);
            pbOutputInterpolation.Image.Save(fileName + " Interpolation (" + tbIncreaseRatio.Text + ").png", ImageFormat.Png);
            pbOutputSuperResolution.Image.Save(fileName + " SR (" + tbIncreaseRatio.Text + ").png", ImageFormat.Png);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pbOutputSuperResolution.Image.Save(sfd.FileName, format);
            }
        }

        private void pnlInterpolation_Scroll(object sender, ScrollEventArgs e)
        {
            var srHorizScroll = pnlSR.HorizontalScroll;
            var srVertScroll = pnlSR.VerticalScroll;
            var interpHorizScroll = pnlInterpolation.HorizontalScroll;
            var interpVertScroll = pnlInterpolation.VerticalScroll;

            srHorizScroll.Value = (int)Math.Round((double)interpHorizScroll.Value /
                (interpHorizScroll.Maximum - interpHorizScroll.Minimum) * (srHorizScroll.Maximum - srHorizScroll.Minimum));
            srVertScroll.Value = (int)Math.Round((double)interpVertScroll.Value /
                (interpVertScroll.Maximum - interpVertScroll.Minimum) * (srVertScroll.Maximum - srVertScroll.Minimum));
        }

        private void pnlSR_Scroll(object sender, ScrollEventArgs e)
        {
            var srHorizScroll = pnlSR.HorizontalScroll;
            var srVertScroll = pnlSR.VerticalScroll;
            var interpHorizScroll = pnlInterpolation.HorizontalScroll;
            var interpVertScroll = pnlInterpolation.VerticalScroll;

            interpHorizScroll.Value = (int)Math.Round((double)srHorizScroll.Value /
                (srHorizScroll.Maximum - srHorizScroll.Minimum) * (interpHorizScroll.Maximum - interpHorizScroll.Minimum));
            interpVertScroll.Value = (int)Math.Round((double)srVertScroll.Value /
                (srVertScroll.Maximum - srVertScroll.Minimum) * (interpVertScroll.Maximum - interpVertScroll.Minimum));
        }

        
    }
}
