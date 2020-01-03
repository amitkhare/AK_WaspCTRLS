namespace TestCTRL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageSelector1 = new AK_WaspCTRLS.ImageSelector();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grDesignerForm = new System.Windows.Forms.GroupBox();
            this.txtSlug = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grDesignerForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(15, 268);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(361, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageSelector1);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Location = new System.Drawing.Point(31, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 313);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // imageSelector1
            // 
            this.imageSelector1.DestinationParentDirectory = "X:\\DailyLoops";
            this.imageSelector1.ImageQuality = 85;
            this.imageSelector1.InitialDirectory = "C:\\Users\\BSUser\\Desktop";
            this.imageSelector1.Location = new System.Drawing.Point(15, 19);
            this.imageSelector1.Name = "imageSelector1";
            this.imageSelector1.SaveImageAs = AK_WaspCTRLS.Formats.JPG;
            this.imageSelector1.Size = new System.Drawing.Size(360, 244);
            this.imageSelector1.TabIndex = 8;
            this.imageSelector1.TextBox_FilePath = "txtFilePath";
            this.imageSelector1.TextBox_Slug = "txtSlug";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grDesignerForm);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMain.Location = new System.Drawing.Point(0, 419);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(520, 86);
            this.pnlMain.TabIndex = 7;
            // 
            // grDesignerForm
            // 
            this.grDesignerForm.Controls.Add(this.txtSlug);
            this.grDesignerForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDesignerForm.Location = new System.Drawing.Point(0, 0);
            this.grDesignerForm.Name = "grDesignerForm";
            this.grDesignerForm.Size = new System.Drawing.Size(520, 86);
            this.grDesignerForm.TabIndex = 0;
            this.grDesignerForm.TabStop = false;
            this.grDesignerForm.Text = "grDesignerForm";
            // 
            // txtSlug
            // 
            this.txtSlug.Location = new System.Drawing.Point(31, 42);
            this.txtSlug.Name = "txtSlug";
            this.txtSlug.Size = new System.Drawing.Size(417, 20);
            this.txtSlug.TabIndex = 0;
            this.txtSlug.Text = "Fykyju";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 505);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grDesignerForm.ResumeLayout(false);
            this.grDesignerForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grDesignerForm;
        private System.Windows.Forms.TextBox txtSlug;
        private AK_WaspCTRLS.ImageSelector imageSelector1;
    }
}

