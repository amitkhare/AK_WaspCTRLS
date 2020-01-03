using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AK_WebPWrapper;


namespace AK_WaspCTRLS
{
    class ImageData
    {
        public Image image { get; private set; }
        public FileInfo imageInfo { get; private set; }
        public ImageData(Image img, FileInfo info)
        {
            image = img;
            imageInfo = info;
        }
    }
    class GetImage
    {
        public static ImageData FromFilePath(string fullPath)
        {
            if (!File.Exists(fullPath)) return null;

            FileInfo fInfo = new FileInfo(fullPath);
            if (fInfo.Extension == ".webp")

                return new ImageData(getfromWebP(fullPath), fInfo);
            else
                return new ImageData(getFromImage(fullPath), fInfo);
        }


        private static Image getFromImage(string fullpath)
        {
            try
            {
                Image tempImage = new Bitmap(fullpath);
                Image img = new Bitmap(tempImage);
                tempImage.Dispose();
                return img;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nIn GetImage.getFromImage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


        }

        private static Image getfromWebP(string fullpath) {
            try
            {
                if (!Helpers.isExiestWebpDLL())
                {
                    MessageBox.Show("libwebp_x86.dll and/or libwebp_x64.dll are missing.\n\nPlease Place them at \n"
                        + Helpers.WEBPDLLPATH, "Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                WebP webp = new WebP();
                Image img = new Bitmap(webp.Load(fullpath));
                webp.Dispose();
                return img;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message + "\r\nIn GetImage.getfromWebP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private static bool IsValidImage(string filename)
        {
            try
            {
                using (Image newImage = Image.FromFile(filename))
                { }
            }
            catch (OutOfMemoryException)
            {
                //The file does not have a valid image format.
                //-or- GDI+ does not support the pixel format of the file

                return false;
            }
            return true;
        }

    }
}
