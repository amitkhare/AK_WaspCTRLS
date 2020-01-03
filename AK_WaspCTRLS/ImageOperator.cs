using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AK_WaspCTRLS
{
    public enum Formats { JPG = 0, PNG = 1 }

    class ImageOperator
    {
        public string destination;
        Formats SaveImageAs;
        int quality;

        public ImageOperator(string destination, Formats SaveImageAs, int quality = 85)
        {
            this.destination = destination;
            this.SaveImageAs = SaveImageAs;
            this.quality = (quality <= 100 && quality > 0) ? quality : 85;

            //if (!Directory.Exists(this.destination)) Directory.CreateDirectory(this.destination);

        }

        private string getSavePath(string filename)
        {
            string path = destination.TrimEnd('\\') + "\\" + filename;
            string extn = null;
            if (SaveImageAs == Formats.PNG)
                extn = ".png";
            else
                extn = ".jpg";

            if (!File.Exists(path + extn)) return path + extn;
            else return path + "_" + Helpers.GenerateName(5) + extn; 
        }

        public string Save(Image image, string filename)
        {
            
            if (!Directory.Exists(this.destination))
            {
                Directory.CreateDirectory(this.destination);
            }

            string fullpath = getSavePath(filename);

            try
            {
                if (SaveImageAs == Formats.JPG)
                    image.Save(fullpath, ImageFormat.Jpeg);
                if (SaveImageAs == Formats.PNG)
                    image.Save(fullpath, ImageFormat.Png);

                if (File.Exists(fullpath)) return fullpath;
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nIn ImageOperator.Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
