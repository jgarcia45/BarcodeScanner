using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace BarcodeRecoveryCS
{

    class ReadBarcode
    {
        public string read(Bitmap img)
        {
            // create a barcode reader instance
            IBarcodeReader reader = new BarcodeReader();

            // load a bitmap
            var barcodeBitmap = img;

            // detect and decode the barcode inside the bitmap
            var result = reader.Decode(img);

            // do something with the result
            if (result != null)
            {
                return result.BarcodeFormat.ToString() + ",     " + result.Text;
            }
            return "";
        }
        // /////////////////////////////////////////////////////////////////////////////////
        public Bitmap gen128(string input)
        {
            BarcodeWriter toqr;

            toqr = new BarcodeWriter();
            toqr.Format = BarcodeFormat.CODE_128;

            return toqr.Write(input);
        }
        // /////////////////////////////////////////////////////////////////////////////////
        public Bitmap gen39(string input)
        {
            BarcodeWriter toqr;

            toqr = new BarcodeWriter();
            toqr.Format = BarcodeFormat.CODE_39;

            return toqr.Write(input);
        }
    }
}
