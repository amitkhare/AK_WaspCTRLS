using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace AK_WaspCTRLS
{
    public enum ImageState { Added, Mutated, Removed }
    public class ImageStateChangedEventArgs : EventArgs
    {
        public ImageState CurrentState { get; private set; }
        public ImageStateChangedEventArgs(ImageState currentState)
        {
            CurrentState = currentState;
        }
    }

    public partial class AK_PictureBox : PictureBox
    {
        [Description("Fires when image state is changed"), Category("Action")]
        public event EventHandler<ImageStateChangedEventArgs> ImageStateChanged;

        private ContextMenu cm;
        public string ImagePath { get; private set; }
        public string ImageName { get; private set; }
        public string ImageExtn { get; private set; }
        public string ImageNameWithoutExtension { get; private set; }

        public AK_PictureBox()
        {
            InitializeComponent();
            InitContextMenu();

            this.MouseDoubleClick += onMouseDoubleClick;
        }


        public void ReloadImage()
        {
            if (ImagePath != null)
                SetImage(ImageState.Mutated, ImagePath);
        }

        private void InitContextMenu()
        {
            cm = new ContextMenu();
            cm.MenuItems.Add("Edit");
            cm.MenuItems.Add("Reload");
            cm.MenuItems.Add("Find in Computer");
            cm.MenuItems.Add("Delete From Computer");
            cm.MenuItems[0].Click += onCmCick_EditInPaint;
            cm.MenuItems[1].Click += onCmCick_ReloadImage;
            cm.MenuItems[2].Click += onCmCick_ShowFileInExplorer;
            cm.MenuItems[3].Click += onCmCick_DeleteFromComputer;
        }

        private void onCmCick_EditInPaint(object sender, EventArgs e)
        {
            if (!File.Exists(ImagePath)) return;
            ProcessStartInfo startInfo = new ProcessStartInfo(ImagePath);
            startInfo.Verb = "edit";

            Process.Start(startInfo);
        }

        private void onCmCick_ReloadImage(object sender, EventArgs e)
        {
            ReloadImage();
        }


        private void onCmCick_DeleteFromComputer(object sender, EventArgs e)
        {
            DialogResult confirmDeleteDialog = MessageBox.Show(
                "Are you sure to delete this image from your computer? \r\n This can't be undone.",
                "Delete?",
                MessageBoxButtons.YesNo);
            if (confirmDeleteDialog == DialogResult.Yes)
            {
                File.Delete(ImagePath);
                SetImage(ImageState.Removed, null);
            }
        }

        private void onCmCick_ShowFileInExplorer(object sender, EventArgs e)
        {
            Helpers.ShowFileInExplorer(ImagePath);
        }

        private void onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.webp *.jfif *.jpg, *.jpeg, *.jpe, *.png, *.bmp) | *.webp; *.jfif; *.jpg; *.jpeg; *.jpe; *.png; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                // watchout for this block
                // this will delete previous image from paths
                if (ImagePath != null && File.Exists(ImagePath))
                {
                    File.Delete(ImagePath);
                }

                SetImage(ImageState.Added, ofd.FileName);
            }
            ofd.Dispose();
        }

        public void SetImage(ImageState imageState, string FilePath = null)
        {

            if (File.Exists(FilePath))
            {
                ImageData imageData = GetImage.FromFilePath(FilePath);
                this.Image = imageData.image;
                ImagePath = imageData.imageInfo.FullName;
                ImageName = imageData.imageInfo.Name;
                ImageExtn = imageData.imageInfo.Extension;
                ImageNameWithoutExtension = Path.GetFileNameWithoutExtension(ImagePath);

                this.ContextMenu = cm;

            }
            else
            {
                this.Image = null;
                ImagePath = null;
                ImageName = null;
                ImageExtn = null;
                ImageNameWithoutExtension = null;

                this.ContextMenu = null;
            }
            OnImageStateChanged(imageState);
        }

        protected virtual void OnImageStateChanged(ImageState imageState)
        {
            ImageStateChanged?.Invoke(this, new ImageStateChangedEventArgs(imageState));

        }
    }
}
