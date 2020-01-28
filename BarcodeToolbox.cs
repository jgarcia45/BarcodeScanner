using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace BarcodeRecoveryCS
{
    public struct FoundBars
    {
        public int x;
        public int y;
        public int barWidth;

        public void addToY()
        {
            y++;
        }
    }


    class BarcodeToolbox
    {
        Bitmap raw;
        HeapSort hs;
        HeapSortSize hss;
        List<FoundBars> bars = new List<FoundBars>();
        int SamplePoints = 85;


        public BarcodeToolbox(Bitmap image)
        {
            raw = image;
        }
        public BarcodeToolbox()
        {
            raw = null;
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void assignImage(Bitmap image)
        {
            raw = image;
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap identifyBars()
        {
            Bitmap ret;
            Color col;
            int rows;
            double imageCurrentRow=0, sampleUnits;
            if (raw == null)
                return null;

            rows = raw.Height;

            // get 50 test points these will be used to get barcode data
            sampleUnits = Convert.ToDouble(rows / (SamplePoints*1.0));
            if ((sampleUnits - (int)sampleUnits) > 0)
                sampleUnits = (int)sampleUnits + 1;


            // setup image to display
            ret = raw;

            // go through the image checking all pixels along the sample rows
            for (int r = 0; r < SamplePoints; r++)
            {
                imageCurrentRow += sampleUnits;
                if (imageCurrentRow > raw.Height)
                    break;
                
                for (int c = 0; c < raw.Width; c++)
                {
                    //ret.SetPixel(c, imageCurrentRow, Color.Red);
                    col = raw.GetPixel(c, (int)Math.Ceiling(imageCurrentRow));
                    if ((int)col.R <= 10 && (int)col.G < 10 && (int)col.B < 10)
                    {
                        bars.Add(getFoundBars(c, (int)Math.Ceiling(imageCurrentRow)));
                        c += bars[bars.Count - 1].barWidth;
                    }
                }
            }



            // remake barcode image
            for (int r = 0; r < bars.Count; r++)
            {
                // color the row that is the exact with of the bar RED
                for (int t = 0; t < bars[r].barWidth; t++)
                {
                    ret.SetPixel(bars[r].x + t, bars[r].y, Color.Red);
                }
            }

            return ret;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        FoundBars getFoundBars(int x, int y)
        {
            FoundBars ret = new FoundBars();
            Color col;
            int barWidth = 0;

            // form given pixel position continue to go accross the row
            // until a whight pixel is found
            for (int i = x; i < raw.Width; i++)
            {
                col = raw.GetPixel(i, y);

                // if the pixel is black count that pixel 
                if ((int)col.R <= 10 && (int)col.G < 10 && (int)col.B < 10)
                {
                    barWidth += 1;
                    if ((i + 1 == raw.Width))
                    {
                        ret.x = x;
                        ret.y = y;
                        ret.barWidth = barWidth;
                        break;
                    }
                }
                else
                {
                    // when the pixel is not black save information on
                    // the bar and add the pixel with to structure
                    ret.x = x;
                    ret.y = y;
                    ret.barWidth = barWidth;
                    break;
                }
            }

            // return the loaded structure
            return ret;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap isGoodBar()
        {
            Bitmap ret;
            Color col;
            int rows,
                coln = 0, mode;
            double imageCurrentRow, sampleUnits;
            List<FoundBars> tmpList = new List<FoundBars>();
            List<FoundBars> ConfermedBars = new List<FoundBars>();
            hs = new HeapSort();

            if (raw == null)
                return null;

            rows = raw.Height;

            // get x number of test points these will be used to get barcode data
            sampleUnits = Convert.ToInt32(rows / SamplePoints);

            // setup image to display
            ret = raw;

            // go through the image checking all pixels along the sample rows
            for (int r = 0; r < SamplePoints; r++)
            {
                imageCurrentRow = r * sampleUnits;

                for (int c = 0; c < raw.Width; c++)
                {
                    //ret.SetPixel(c, imageCurrentRow, Color.Red);
                    col = raw.GetPixel(c, (int)imageCurrentRow);
                    if ((int)col.R <= 10 && (int)col.G < 10 && (int)col.B < 10)
                    {
                        bars.Add(getFoundBars(c, (int)imageCurrentRow));
                        c += bars[bars.Count - 1].barWidth;
                    }
                }
            }


            //Write("(");

            // convert the list of found bars to an array 
            FoundBars[] arrays = bars.ToArray();

            // use heap sort to sort the array
            hs.Heap_Sort(arrays);


            for (int i = 0; i < arrays.Length; i++ )
            {
                for (int u = i; u < arrays.Length;u++ ) {
                    if (arrays[u].x == arrays[i].x)
                        tmpList.Add(arrays[u]);
                    else
                        break;
                }

                // shift the index so it wont recount the seame x position
                i += tmpList.Count - 1;

                // check to see if its a good bar
                if (tmpList.Count > 2)
                    ConfermedBars.Add(tmpList[0]);

                // reset the list
                tmpList.Clear();
            }
            
            // remake barcode image
            for (int r = 0; r < ConfermedBars.Count; r++)
            {
                // color the row that is the exact with of the bar RED
                for (int t = 0; t < ConfermedBars[r].barWidth; t++)
                {
                    ret.SetPixel(ConfermedBars[r].x + t, ConfermedBars[r].y, Color.Red);
                }
            }
            return ret;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap Reconstruct(int inc = 1, bool isCode39=true)
        {
            Bitmap ret;
            Color col;
            int rows,cashe,
                coln = 0, widthprv=0;
            double sampleUnits, imageCurrentRow=0, xdiff;
            List<FoundBars> tmpList = new List<FoundBars>();
            List<FoundBars> ConfermedBars = new List<FoundBars>();
            hs = new HeapSort();
            hss = new HeapSortSize();

            if (raw == null)
                return null;

            rows = raw.Height;

            // get x number of test points these will be used to get barcode data
            sampleUnits = Convert.ToDouble(rows / (SamplePoints*1.0));
            if ((sampleUnits - (int)sampleUnits) > 0)
                sampleUnits = (int)sampleUnits + 1;

            // setup image to display
            ret = raw;

            // go through the image checking all pixels along the sample rows
            for (int r = 0; r < SamplePoints; r++)
            {
                imageCurrentRow += sampleUnits;
                if (imageCurrentRow >= raw.Height)
                    break;

                for (int c = 0; c < raw.Width; c++)
                {
                    //ret.SetPixel(c, imageCurrentRow, Color.Red);
                    col = raw.GetPixel(c, (int)imageCurrentRow);
                    if ((int)col.R <= 10 && (int)col.G < 10 && (int)col.B < 10)
                    {
                        bars.Add(getFoundBars(c, (int)imageCurrentRow));
                        c += bars[bars.Count - 1].barWidth;
                    }
                }
            }
            // convert the list of found bars to an array 
            FoundBars[] arrays = bars.ToArray();

            // use heap sort to sort the array
            hs.Heap_Sort(arrays);


            for (int i = 0; i < arrays.Length; i++)
            {
                // check width of barcode
                if (i > 0 && ConfermedBars.Count > 0)
                {
                    widthprv = ConfermedBars[ConfermedBars.Count - 1].barWidth;
                    xdiff = arrays[i].x - ConfermedBars[ConfermedBars.Count - 1].x;
                    if (widthprv >= xdiff)
                        continue;
                }

                // check if x positons are good
                for (int u = i; u < arrays.Length; u++)
                {
                    // check x positions of the bars
                    if (arrays[u].x >= (arrays[i].x - (arrays[i].barWidth / 5)) && arrays[u].x <= (arrays[i].x + (arrays[i].barWidth / 5)))
                        tmpList.Add(arrays[u]);
                    else
                        break;
                }

                // shift the index so it wont recount the seame x position
                i += tmpList.Count - 1;

                // check to see if its a good bar
                if (tmpList.Count > 2)
                {
                    // calc avrage width
                    // use heap sort to sort the array then remove the first and last fith of the barcode
                    // this removes the smallest and largest parts of the barcode
                    cashe = tmpList.Count/7;
                    if (cashe < 0)
                        cashe = 1;
                    hss.Heap_Sort(tmpList);
                    for (int t = 0; t < cashe; t++)
                    {
                        tmpList.RemoveAt(t);
                        tmpList.RemoveAt(tmpList.Count - 1 - t);
                    }
                    if (tmpList.Count <= 5)
                    {
                        // reset the list
                        tmpList.Clear();
                        continue;
                    }


                    // calculate the avrage of the result
                    for (int x = 0; x < tmpList.Count; x++)
                    {
                        coln += tmpList[x].barWidth;
                    }

                    // set avrage to the first element of the list
                    FoundBars tmpBar = new FoundBars();
                    tmpBar.x = tmpList[0].x;
                    tmpBar.y = 0;
                    tmpBar.barWidth = coln / tmpList.Count;

                    // save the fist element of the list
                    ConfermedBars.Add(tmpBar);
                    coln = 0;
                }

                // reset the list
                tmpList.Clear();
            }







            // profile bar widts
            List<FoundBars> checkWidth = new List<FoundBars>();
            bool isUniqueWidth = false;
            for (int i = 0; i < ConfermedBars.Count(); i++ )
            {
                FoundBars width = new FoundBars();
                width.barWidth = ConfermedBars[i].barWidth;
                width.y = 0;

                if (checkWidth.Count() > 0)
                {
                    // finds unique withs of bars
                    for (int u = 0; u < checkWidth.Count(); u++)
                        if (width.barWidth == checkWidth[u].barWidth)
                        {
                            isUniqueWidth = false;
                            break;
                        }
                        else
                            isUniqueWidth = true;

                    // if unique add to lis
                    if(isUniqueWidth == true)
                         checkWidth.Add(width);
                    else
                    {
                        // if not unique update value
                        for (int u = 0; u < checkWidth.Count(); u++)
                        {
                            if (width.barWidth == checkWidth[u].barWidth)
                            {
                                (checkWidth[u]).addToY();
                            }
                        }
                    }
                }
                else
                {
                    checkWidth.Add(width);
                }

            }

            List<int> colSize = new List<int>();
            List<int> confirmedSize = new List<int>();


            for (int i = 0; i < checkWidth.Count(); i++)
                colSize.Add(checkWidth[i].barWidth);

            colSize.Sort();
            

            int p=0, colSizeDivPtIndex=0;
            int mid=0;
            // divide the sorted column sizes to two or  three
            if(isCode39 == true)
            {

                mid = colSize.Count >> 1;
                for (int i = 0; i < mid; i++)
                    p += colSize[i];
                p /= mid;
                confirmedSize.Add(p);

                p = 0;
                for (int i = mid; i < colSize.Count(); i++)
                    p += colSize[i];
                p /= mid;
                confirmedSize.Add(p);
            }else
            {
                mid = colSize.Count /3;
                for (int u = 0; u < 3; u++)
                {
                    colSizeDivPtIndex += mid;
                    for (int i = (mid * u); i < colSizeDivPtIndex; i++)
                    {
                        p += colSize[i];
                    }
                    p /= mid;
                    confirmedSize.Add(p);
                    p = 0;
                }

                confirmedSize.Sort();
                confirmedSize[0] = confirmedSize[2] / 4;//(confirmedSize[0]+confirmedSize[2] / 3)/2;
                confirmedSize[1] = (confirmedSize[2] / 2);//(confirmedSize[1]+(2 * confirmedSize[2]) / 3)/2;
                confirmedSize[2] = (int)(confirmedSize[2] *.96);
            }
            for (int i = 0; i < confirmedSize.Count(); i++)
                Write(confirmedSize[i] + "");

            /*
             *    int min = raw.Width;
            for (int i = 0; i < checkWidth.Count(); i++)
                if (checkWidth[i].barWidth < min)
                    min = checkWidth[i].barWidth;
             */






            // make new bitmap of equal width as the raw image
            ret = new Bitmap(raw.Width, 50);
            for (int r = 0; r < ret.Height; r++)
                for (int c = 0; c < ret.Width; c++)
                    ret.SetPixel(c, r, Color.White);


            if (isCode39 == true)
            {
                // remake barcode image
                for (int r = 0; r < ret.Height; r++)
                    for (int c = 0, index = 0; c < ret.Width; c++)
                    {
                        if (index >= ConfermedBars.Count())
                            break;
                        // color the row that is the exact with of the confermed Bar
                        if (c == ConfermedBars[index].x)
                        {
                            int q = ConfermedBars[index].barWidth + inc;
                            // ===========================================================
                            // code 39 section
                            if (isCode39 == true)
                                q = (ConfermedBars[index].barWidth + inc > confirmedSize[0]) ? confirmedSize[1] : confirmedSize[0];
                            else
                            {
                                // ===========================================================
                                // 128 section
                                if (ConfermedBars[index].barWidth + inc >= (confirmedSize[1]))
                                    q = confirmedSize[2];
                                else
                                    if (ConfermedBars[index].barWidth + inc >= (confirmedSize[0]))
                                    q = confirmedSize[1];
                                else
                                    q = confirmedSize[0];
                            }
                            // ===========================================================
                            for (int subt = 0; subt < q; subt++)
                            {
                                int cl = ConfermedBars[index].x + subt;
                                if (cl < raw.Width)
                                    ret.SetPixel(cl, r, Color.Black);
                                else
                                {

                                    break;
                                }
                            }

                            if (isCode39 == true)
                                c += ConfermedBars[index].barWidth + inc;
                            else
                                c += q;

                            // if new c value passes the next confermed bar index keep incrementing 
                            // unill c is smaller than the next x position
                            for (int w = index; w < ConfermedBars.Count; w++)
                                if (c >= ConfermedBars[w].x)
                                    index++;
                                else
                                    break;
                        }
                        else
                            ret.SetPixel(c, r, Color.White);
                    }
            }else
            {
                //remake barcode image
                for (int r = 0; r < ret.Height; r++)
                    for (int c = 0, index = 0; c < ret.Width; c++)
                    {
                        if (index >= ConfermedBars.Count())
                            break;
                        //color the row that is the exact width of the confirmed Bar
                        if (c == ConfermedBars[index].x)
                        {
                            for (int subt = 0; subt < ConfermedBars[index].barWidth + 1; subt++)
                            {
                                ret.SetPixel(ConfermedBars[index].x + subt, r, Color.Black);
                            }
                            c += ConfermedBars[index].barWidth + 1;

                            //if new c value passes the next confirmed bar index keep incrementing
                            //untill c is smaller than the next x position
                            for (int w = index; w < ConfermedBars.Count; w++)
                            {
                                if (c >= ConfermedBars[w].x)
                                {
                                    index++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                            ret.SetPixel(c, r, Color.White);
                    }
            }
            return ret;
        }







        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<FoundBars> DoBuble(List<FoundBars> bars)
        {
            FoundBars tmp;

            for (int i = 0; i < bars.Count; i++ ) {
                for (int u = i+1; u < bars.Count;u++ )
                {
                    if (bars[u].x < bars[i].x){
                        tmp =bars[u];
                        bars[u] = bars[i];
                        bars[i] = tmp;
                    }
                        
                }
            }
            return bars;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Bitmap DrawCircle(int x0, int y0, int radius, Bitmap img)
        {
            int x = radius;
            int y = 0;
            int decisionOver2 = 1 - x;   // Decision criterion divided by 2 evaluated at x=r, y=0

            while (y <= x)
            {
                img.SetPixel(x + x0, y + y0, Color.Blue); // Octant 1
                img.SetPixel(y + x0, x + y0, Color.Blue); // Octant 2
                img.SetPixel((-x + x0 > -1) ? -x + x0 : 0, y + y0, Color.Blue); // Octant 4
                img.SetPixel((-y + x0 > -1) ? -y + x0 : 0, x + y0, Color.Blue); // Octant 3
                img.SetPixel((-x + x0 > -1) ? -x + x0 : 0, (-y + y0 > -1) ? -y + y0 : 0, Color.Blue); // Octant 5
                img.SetPixel((-y + x0 > -1) ? -y + x0 : 0, (-x + y0 > -1) ? -x + y0 : 0, Color.Blue); // Octant 6
                img.SetPixel(x + x0, (-y + y0 > -1) ? -y + y0 : 0, Color.Blue); // Octant 7
                img.SetPixel(y + x0, (-x + y0 > -1) ? -x + y0 : 0, Color.Blue); // Octant 8
                y++;
                if (decisionOver2 <= 0)
                {
                    decisionOver2 += 2 * y + 1;   // Change in decision criterion for y -> y+1
                }
                else
                {
                    x--;
                    decisionOver2 += 2 * (y - x) + 1;   // Change for y -> y+1, x -> x-1
                }
            }

            return img;
        }




        
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Write(string input)
        {
            StreamWriter write;
            try
            {
                write = new StreamWriter(File.Open(@"D:\bars.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write));
                try
                {
                    write.BaseStream.Seek(0, SeekOrigin.End);
                    write.WriteLine(input);
                    write.Flush();
                    write.Close();
                }
                catch (Exception ex1) { }
            }
            catch (Exception ex2) { }
        }
    }
}
