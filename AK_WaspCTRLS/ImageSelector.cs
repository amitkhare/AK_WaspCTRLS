using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System;

namespace AK_WaspCTRLS
{
    public partial class ImageSelector: UserControl
    {
        [Browsable(true), Description("Output Image Format"), Category("Misc")]
        public Formats SaveImageAs { get; set; }

        // Image Save Initial Directory Selector
        [Description("Initial Directory path, typically DESKTOP/ DOWNLOADS"), Category("Misc")]
        public string InitialDirectory { get; set; }

        // Image Save Destination Selector
        [Description("Destination folder path, typically available to all systems"), Category("Misc")]
        public string DestinationParentDirectory { get; set; }
        // Image Quality Selector
        [Description("Destination image quality between 1 to 100"), Category("Misc")]
        public int ImageQuality { get; set; }

        [Description("Slug Text Field Name"), Category("Misc")]
        public string TextBox_Slug { get; set; }

        [Description("TextBox Name FilePath UserTag"), Category("Misc")]
        public string TextBox_FilePath { get; set; }

        private ImageOperator imageOperator;
        private string randomSlugName = Helpers.GenerateName(5);
        public ImageSelector()
        {
            InitializeComponent();


            // imageOperator is also instanciated in functions
            // OnTextBox_Slug_TextChanged()
            // TaskUpdateFromParent()
            // imageOperator = new ImageOperator(Helpers.getDestiantionDateDirectory(DestinationParentDirectory), SaveImageAs, ImageQuality);

            pBox.ImageStateChanged += OnImageStateChanged;

            _ = TaskUpdateFromParent();
        }


        private void OnImageStateChanged(object sender, ImageStateChangedEventArgs e)
        {
            if (e.CurrentState == ImageState.Added && pBox.Image != null)
            {
                string newFilepath = imageOperator.Save(pBox.Image, pBox.ImageNameWithoutExtension);
                pBox.SetImage(ImageState.Mutated, newFilepath);
            }

            updateParent(pBox.ImagePath);
            

        }

        private async Task TaskUpdateFromParent()
        {
            await Task.Delay(600);

            if (DestinationParentDirectory == null) DestinationParentDirectory = Helpers.WaspDrive + "DailyLoops";
            if (InitialDirectory == null) InitialDirectory = Helpers.Desktop.TrimEnd('\\');
            if (ImageQuality < 1 | ImageQuality > 100) ImageQuality = 85;
            if (TextBox_Slug == null) TextBox_Slug = "txtSlug";
            if (TextBox_FilePath == null) TextBox_FilePath = "txtFilePath";

            imageOperator = new ImageOperator(Helpers.getDestiantionDateDirectory(DestinationParentDirectory), SaveImageAs, ImageQuality);

            if (this.Parent == null || this.Parent.Controls.Count < 1) return;

            // define TextBox_Slug
            if (this.Parent.Controls[TextBox_FilePath] != null)
            {
                TextBox textBoxFilePath = (TextBox)this.Parent.Controls[TextBox_FilePath];

                if (textBoxFilePath.Text.Length > 0 && File.Exists(textBoxFilePath.Text))
                {
                    pBox.SetImage(ImageState.Mutated, textBoxFilePath.Text);
                }
                textBoxFilePath.ReadOnly = true;
                textBoxFilePath.TextChanged -= OnTextBox_FilePath_TextChanged;
                textBoxFilePath.TextChanged += OnTextBox_FilePath_TextChanged;
            }

            // define TextBox_Slug
            string slugName = randomSlugName;
            TextBox textBoxSlug = null;
            if (this.Parent.Controls[TextBox_Slug] != null)
            {
                textBoxSlug = (TextBox)this.Parent.Controls[TextBox_Slug];                
            }

            else if (this.Parent != null && this.Parent.Controls["pnlMain"] != null && this.Parent.Controls["pnlMain"].Controls["grDesignerForm"].Controls[TextBox_Slug] != null)
            {
                textBoxSlug = (TextBox) this.Parent.Controls["pnlMain"].Controls["grDesignerForm"].Controls[TextBox_Slug];
            }

            else if (this.Parent.Parent != null && this.Parent.Parent.Controls[TextBox_Slug] != null) {

                textBoxSlug = (TextBox)this.Parent.Parent.Controls[TextBox_Slug];
            }

            else if (this.Parent.Parent != null && this.Parent.Parent.Controls["pnlMain"] != null  && this.Parent.Parent.Controls["pnlMain"].Controls["grDesignerForm"].Controls[TextBox_Slug] != null)
            {
                textBoxSlug = (TextBox)this.Parent.Parent.Controls["pnlMain"].Controls["grDesignerForm"].Controls[TextBox_Slug];
            }

            if (textBoxSlug != null) { 
                if (textBoxSlug.Text.Length > 0) slugName = textBoxSlug.Text.Trim();
                else textBoxSlug.Text = slugName;
            }

            string path = Helpers.getDestiantionDateDirectory(DestinationParentDirectory) + slugName + "\\";
            imageOperator = new ImageOperator(path, SaveImageAs, ImageQuality);

            textBoxSlug.TextChanged -= OnTextBox_Slug_TextChanged;
            textBoxSlug.TextChanged += OnTextBox_Slug_TextChanged;

            
        }

        private void OnTextBox_Slug_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxSlug = (TextBox) sender;
            string slugName = randomSlugName;
            if (textBoxSlug.Text.Length > 0) slugName = textBoxSlug.Text.Trim();
            else textBoxSlug.Text = slugName;

            string path = Helpers.getDestiantionDateDirectory(DestinationParentDirectory) + slugName + "\\";
            imageOperator = new ImageOperator(path, SaveImageAs, ImageQuality);
        }

        private void OnTextBox_FilePath_TextChanged(object sender, EventArgs e)
        {
            pBox.SetImage(ImageState.Mutated, ((TextBox)sender).Text);
        }

        private void updateParent(string imagepath = "")
        {
            if (this.Parent == null || this.Parent.Controls.Count < 2) return;

            if (this.Parent.Controls[TextBox_FilePath] != null) {
                TextBox textBox = (TextBox) this.Parent.Controls[TextBox_FilePath];
                textBox.Text = imagepath;                
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pBox.ReloadImage();
        }
    }
}
