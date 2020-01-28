using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BarcodeRecoveryCS
{
    public partial class Form1 : Form
    {
        BarcodeToolbox bt = new BarcodeToolbox();
        ReadBarcode rbar = new ReadBarcode();

        public Form1()
        {
            InitializeComponent();
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            string imageFileLoc;

            open.InitialDirectory = @"D:\RecoveredBarcodes";
            open.ShowDialog();
            imageFileLoc = open.FileName;

            picDisplay.ImageLocation = imageFileLoc;
            //picDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void identifyBarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tmp;

            try
            {
                bt = new BarcodeToolbox((Bitmap)picDisplay.Image);

                picDisplay.Image = (Image)bt.identifyBars();
            }
            catch (Exception ex){ }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void decodeBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(rbar.read((Bitmap)picDisplay.Image));
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void changeToBWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tmp;
            try
            {
                bt = new BarcodeToolbox((Bitmap)picDisplay.Image);

                tmp = bt.identifyBars();

                picDisplay.Image = (Image)tmp;
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void traversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tmp = (Bitmap)picDisplay.Image;

            try
            {
                for (int r = 0; r < tmp.Width; r++)
                {
                    for (int c = 0; c < tmp.Height; c++)
                    {
                        if (tmp.GetPixel(r, c).R > 100 && tmp.GetPixel(r, c).G == 0)
                            tmp.SetPixel(r, c, Color.Black);
                    }
                }

                picDisplay.Image = (Image)tmp;
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void identifyGoodBarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                bt = new BarcodeToolbox((Bitmap)picDisplay.Image);
                picDisplay.Image = bt.isGoodBar();
            //}
            //catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void generate128ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void generate39ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void convertToBlackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageProcessing ip = new ImageProcessing();
                picDisplay.Image = (Image)ip.toBW((Bitmap)picDisplay.Image);
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageProcessing ip = new ImageProcessing();
                picDisplay.Image = (Image)ip.Threshold((Bitmap)picDisplay.Image, 0, 80);
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageProcessing ip = new ImageProcessing();
                picDisplay.Image = (Image)ip.invert((Bitmap)picDisplay.Image);
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog open = new SaveFileDialog();

            try
            {
                open.InitialDirectory = @"D:\RecoveredBarcodes";
                open.ShowDialog();

                picDisplay.Image.Save(open.FileName + ".jpg");
            }
            catch (Exception ex) { }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageProcessing ip = new ImageProcessing();
                picDisplay.Image = (Image)ip.blur((Bitmap)picDisplay.Image, 3);
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void reconstructToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap btmap=null;
            string x;
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    btmap = (Bitmap)picDisplay.Image;
                    BarcodeToolbox bt = new BarcodeToolbox(btmap);
                    btmap = bt.Reconstruct(0, i==0);

                    // read barcode
                    x = rbar.read(btmap);
                    if (!string.IsNullOrEmpty(x))
                    {
                        picDisplay.Image = (Image)btmap;
                        MessageBox.Show(x);
                        return;
                    }
                }
                picDisplay.Image = (Image)btmap;
                MessageBox.Show("Unable To Recover");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////
        private void normalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ImageProcessing ip = new ImageProcessing();
                picDisplay.Image = (Image)ip.bwThresh((Bitmap)picDisplay.Image,0,80);
            }
            catch (Exception ex) { MessageBox.Show("No Barcode to read"); }
        }
    }
}
