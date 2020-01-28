using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BarcodeRecoveryCS
{
    class ImageProcessing
    {
        public Bitmap Threshold(Bitmap image, int lower, int upper)
        {
            Color col;
            Bitmap ret = image;

            // go through each pixel in the image
            for (int r = 0; r < image.Height; r++)
                for (int c = 0; c < image.Width; c++)
                {
                    col = image.GetPixel(c, r);
                    // check to see if the pixels red value is between the upper and lower limits
                    // if it is set the new pixel  as white otherwise black
                    if (col.R >= lower && col.R <= upper)
                        ret.SetPixel(c, r, Color.White);
                    else
                        ret.SetPixel(c, r, Color.Black);
                }

            return ret;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap toBW(Bitmap raw)
        {
            Color pixel;
            int newBWV;

            try
            {
                // go through each pixel one at a time and calcualte the avrage color
                for (int r = 0; r < raw.Width; r++)
                {
                    for (int c = 0; c < raw.Height; c++)
                    {
                        // get pixel
                        pixel = raw.GetPixel(r, c);

                        // calculate avrage and save into newImage image variable
                        newBWV = (int)(pixel.R + pixel.G + pixel.B) / 3;
                        //newBWV = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                        raw.SetPixel(r, c, Color.FromArgb(newBWV, newBWV, newBWV));
                    }
                }
                return raw;
            }
            catch (Exception ex)
            {
                // if no image was passed return null
                return raw;
            }
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap invert(Bitmap image)
        {
            Color col, ncol;
            Bitmap ret = image;

            // go through all pixels in the image
            for (int r = 0; r < image.Height; r++)
                for (int c = 0; c < image.Width; c++){
                    // get the pixel
                    col = image.GetPixel(c,r);
                    // subtract the maximum value by the the red green and blue values
                    ncol = Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B);
                    // set the inverted pixel in the new image
                    ret.SetPixel(c, r, ncol);
                }

            return ret;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap bwThresh(Bitmap raw, int lower, int upper)
        {
            Color pixel;
            int newBWV;

            try
            {
                // go through each pixel one at a time and calcualte the avrage color
                for (int r = 0; r < raw.Height; r++)
                {
                    for (int c = 0; c < raw.Width; c++)
                    {
                        // get pixel
                        pixel = raw.GetPixel(c, r);

                        // calculate avrage and save into newImage image variable
                        newBWV = (int)(pixel.R + pixel.G + pixel.B) / 3;
                        //newBWV = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                        if (newBWV >= lower && newBWV <= upper)
                            raw.SetPixel(c, r, Color.Black);
                        else
                            raw.SetPixel(c, r, Color.White);
                    }
                }
                return raw;
            }
            catch (Exception ex)
            {
                // if no image was passed return null
                MessageBox.Show(ex.ToString());
                return raw;
            }
        }

        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap blur(Bitmap image, int blurRad)
        {
            Bitmap img = toBW(image), ret;
            List<int> filter = new List<int>();
            int mid = (int)Math.Ceiling((blurRad * 1.0) / 2),
                sum = 0;

            ret = new Bitmap(image);

            for (int r = 0; r < img.Height; r++)
                for (int c = 0; c < img.Width; c++)
                {
                    for (int subr = -mid*3; subr < mid*3; subr++)
                    {
                        for (int subc = -mid; subc < mid; subc++)
                        {
                            // get a list of values around the pixel
                            // if the pixel goes over the image set that value to 255
                            if (((r + subr) < 0 || (c + subc) < 0) || ((r + subr) >= img.Height || (c + subc) >= img.Width))
                                filter.Add(255);
                            else
                                filter.Add(img.GetPixel(c + subc, r + subr).R);
                        }
                    }
                    // do convolution
                    // gothrough all elemtnts in the list, normalize the numbers then sum up the results
                    for (int x = 0; x < filter.Count; x++)
                        sum += filter[x] / filter.Count;

                    // get the sum value and set it as a ne color
                    ret.SetPixel(c, r, Color.FromArgb(sum, sum, sum));

                    // reset for nest loop
                    sum = 0;
                    filter.Clear();
                }

            return ret;
        }
    }
}
