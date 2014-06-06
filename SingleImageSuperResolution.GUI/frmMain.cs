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
        Stopwatch Stopwatch;

        public frmMain()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            nudDecLevelsCount.Value = Settings.Default.DecLevelsCount;
            nudIncLevelsCount.Value = Settings.Default.IncLevelsCount;
            tbDecreaseRatio.Text = Settings.Default.DecreaseRatio.ToString();
            tbIncreaseRatio.Text = Settings.Default.IncreaseRatio.ToString();
            nudBlockSize.Value = Settings.Default.BlockSize;
            tbDecIncrementRatio.Text = Settings.Default.DecIncrementRatio.ToString();
            tbReplaceDistance.Text = Settings.Default.ReplaceDistance.ToString();
            tbOrigIncrement.Text = Settings.Default.OrigIncrement.ToString();
            tbInputImagesPath.Text = Settings.Default.InputImagesPath;
            cbParallel.Checked = Settings.Default.Parallel;
            tbInputImagesPath_TextChanged(null, null);
            if (cmbInputImages.Items.Count > 0)
                cmbInputImages.SelectedIndex = Settings.Default.InputImageIndex;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void btnOpenInputImagesPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbInputImagesPath.Text = dialog.SelectedPath;
                tbInputImagesPath_TextChanged(sender, e);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            SaveSettings();
            var input = new Bitmap(Path.Combine(((ComboBoxItem)cmbInputImages.SelectedItem).Value.ToString()));
            pbOutputInterpolation.Image = null;
            pbOutputSuperResolution.Image = null;

            Stopwatch = Stopwatch.StartNew();
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
                DecBlockIncXRatio = double.Parse(tbDecIncrementRatio.Text),
                DecBlockIncYRatio = double.Parse(tbDecIncrementRatio.Text),
                ReplaceDistance = double.Parse(tbReplaceDistance.Text),
                BlockIncRatioX = double.Parse(tbOrigIncrement.Text),
                BlockIncRatioY = double.Parse(tbOrigIncrement.Text),
                Parallelization = cbParallel.Checked,
                Blur = cbBlur.Checked,
                BlurKernelSize = int.Parse(tbBlurKernelSize.Text),
                BlurSigma = double.Parse(tbBlurSigma.Text)
            };
            progress.Value = 0;
            superResoultion.FragmentFounded += superResoultion_FragmentFounded;
            var output = superResoultion.Process();
            progress.Value = progress.Maximum;

            Stopwatch.Stop();
            tbTime.Text = Stopwatch.Elapsed.ToString();

            /*pbOutputInterpolation.Image = new Bitmap(input,
                (int)Math.Round(input.Width * superResoultion.ZoomCoef),
                (int)Math.Round(input.Height * superResoultion.ZoomCoef));*/
            pbOutputInterpolation.Image = Utils.ChangeSize(input, (int)Math.Round(input.Width * superResoultion.ZoomCoef), (int)Math.Round(input.Height * superResoultion.ZoomCoef));
            pbOutputSuperResolution.Image = output.Image;
            tbMinDistance.Text = output.MinDistance.ToString();
            tbMaxDistance.Text = output.MaxDistance.ToString();
            tbAvgDistance.Text = output.AvgDistance.ToString();

            var extension = Path.GetExtension(cmbInputImages.SelectedItem.ToString());
            var fileName = cmbInputImages.SelectedItem.ToString();
            pbOutputInterpolation.Image.Save(fileName + " Interpolation (" + tbIncreaseRatio.Text + ").png", ImageFormat.Png);
            pbOutputSuperResolution.Image.Save(string.Format("{0} SR ({1}{2}).png", fileName, tbIncreaseRatio.Text, cbBlur.Checked ? ", Blur" : "", ImageFormat.Png));
        }

        void superResoultion_FragmentFounded(object sender, EventArgs e)
        {
            var args = (FragmentEventArgs)e;
            progress.Value = (int)Math.Round(progress.Minimum +
                ((double)args.IncLevel + (double)args.FragmentNumber / args.FragmentCount) / args.IncLevelsCount * 
                (progress.Maximum - progress.Minimum));
            tbTime.Text = Stopwatch.Elapsed.ToString();
            Application.DoEvents();
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

        private void cbBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBlur.Checked)
            {
                tbBlurKernelSize.Enabled = true;
                tbBlurSigma.Enabled = true;
            }
            else
            {
                tbBlurKernelSize.Enabled = false;
                tbBlurSigma.Enabled = false;
            }
        }

        private void cmbInputImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbInput.Image = new Bitmap(Path.Combine(((ComboBoxItem)cmbInputImages.SelectedItem).Value.ToString()));
            pbOutputInterpolation.Image = null;
            pbOutputSuperResolution.Image = null;
        }

        private void tbInputImagesPath_TextChanged(object sender, EventArgs e)
        {
            cmbInputImages.Items.Clear();
            var files = Directory.EnumerateFiles(tbInputImagesPath.Text, "*.*", SearchOption.AllDirectories)
                .Where(file => (new string[] { ".jpg", ".jpeg", ".png", ".bmp" }).Contains(Path.GetExtension(file)));
            foreach (var file in files)
                cmbInputImages.Items.Add(new ComboBoxItem(file, Path.GetFileName(file)));
            cmbInputImages.SelectedIndex = 0;
            pbOutputInterpolation.Image = null;
            pbOutputSuperResolution.Image = null;
        }

        private void SaveSettings()
        {
            Settings.Default.DecLevelsCount = (int)nudDecLevelsCount.Value;
            Settings.Default.IncLevelsCount = (int)nudIncLevelsCount.Value;
            Settings.Default.DecreaseRatio = double.Parse(tbDecreaseRatio.Text);
            Settings.Default.IncreaseRatio = double.Parse(tbIncreaseRatio.Text);
            Settings.Default.BlockSize = (int)nudBlockSize.Value;
            Settings.Default.DecIncrementRatio = double.Parse(tbDecIncrementRatio.Text);
            Settings.Default.OrigIncrement = double.Parse(tbOrigIncrement.Text);
            Settings.Default.ReplaceDistance = double.Parse(tbReplaceDistance.Text);
            Settings.Default.InputImagesPath = tbInputImagesPath.Text;
            Settings.Default.InputImageIndex = cmbInputImages.SelectedIndex;
            Settings.Default.Parallel = cbParallel.Checked;
            Settings.Default.Save();
        }
    }
}
