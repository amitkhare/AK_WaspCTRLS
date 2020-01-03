using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AK_WaspCTRLS
{
    class Helpers
    {
        public static Control FindParentControl(Control theControl)
        {
            Control rControl = null;

            if (theControl.Parent != null)
            {
                if (theControl.Parent.GetType() == typeof(System.Windows.Forms.Form))
                {
                    rControl = theControl.Parent;
                }
                else

                {
                    rControl = FindParentControl(theControl.Parent);
                }
            }
            else
            {
                rControl = null;
            }
            return rControl;
        }

        public static string getDestiantionDateDirectory(string DestinationParentDirectory)
        {
            string todayYY = DateTime.Today.ToString("yyyy");
            string todayMM = DateTime.Today.ToString("MMM");
            string todayDD = DateTime.Today.ToString("dd");

            string targetPath = DestinationParentDirectory.TrimEnd('\\') + "\\" + todayYY + "-" + todayMM + "\\" + todayDD + "-" + todayMM + "\\";

            return targetPath;
        }

        public static string SystemRootDirectory = Path.GetPathRoot(Environment.SystemDirectory).TrimEnd('\\') + "\\";
        public static string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).TrimEnd('\\') + "\\";
        public static string WaspDrive = (Directory.Exists(@"X:\")) ? @"X:\" : SystemRootDirectory;
        
        public static string AssemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).TrimEnd('\\') + "\\";
        public static string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".dll";
        public static string AssemblyPath = AssemblyFolder + AssemblyName;

        public static string WaspDriveAssemblyPath = WaspDrive +"amitkhare\\webp\\"+ AssemblyName;

        public const string WEBPDLLPATH = @"C:\Program Files (x86)\Beehive Systems Ltd\WASP3D\Common\Vendor\webp\";

        public static bool isExiestWebpDLL(){
            return (File.Exists(WEBPDLLPATH + "libwebp_x86.dll") && File.Exists(WEBPDLLPATH + "libwebp_x64.dll"));
        }

        public static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }
        public static string GenerateName2(int len)
        {
            /*
            var randomObj = new Random(len);
            var placeGenerator = new RandomNameGeneratorLibrary.PlaceNameGenerator();
            string place = placeGenerator.GenerateRandomPlaceName();
            return place.Replace(" ", "");
            */
            return "";
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };

            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }


        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize, SizeSuffixes[mag]);
        }


        public static void ShowFileInExplorer(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return;
            }
            string argument = "/select, \"" + filePath + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

    }
}