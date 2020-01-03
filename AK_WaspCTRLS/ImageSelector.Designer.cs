namespace AK_WaspCTRLS
{
    partial class ImageSelector
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelector));
            this.pnl_top = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtn_Stamp = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Crop = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Pencil = new System.Windows.Forms.ToolStripButton();
            this.tsBtn_Reload = new System.Windows.Forms.ToolStripButton();
            this.pBox = new AK_WaspCTRLS.AK_PictureBox();
            this.pnl_top.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_top.Controls.Add(this.toolStrip1);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(360, 25);
            this.pnl_top.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtn_Stamp,
            this.tsBtn_Crop,
            this.tsBtn_Pencil,
            this.tsBtn_Reload});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(358, 23);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtn_Stamp
            // 
            this.tsBtn_Stamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Stamp.Enabled = false;
            this.tsBtn_Stamp.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Stamp.Image")));
            this.tsBtn_Stamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Stamp.Name = "tsBtn_Stamp";
            this.tsBtn_Stamp.Size = new System.Drawing.Size(23, 20);
            this.tsBtn_Stamp.Text = "toolStripButton3";
            this.tsBtn_Stamp.ToolTipText = "Stamp Eraser";
            // 
            // tsBtn_Crop
            // 
            this.tsBtn_Crop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Crop.Enabled = false;
            this.tsBtn_Crop.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Crop.Image")));
            this.tsBtn_Crop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Crop.Name = "tsBtn_Crop";
            this.tsBtn_Crop.Size = new System.Drawing.Size(23, 20);
            this.tsBtn_Crop.Text = "toolStripButton2";
            this.tsBtn_Crop.ToolTipText = "Crop";
            // 
            // tsBtn_Pencil
            // 
            this.tsBtn_Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Pencil.Enabled = false;
            this.tsBtn_Pencil.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Pencil.Image")));
            this.tsBtn_Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Pencil.Name = "tsBtn_Pencil";
            this.tsBtn_Pencil.Size = new System.Drawing.Size(23, 20);
            this.tsBtn_Pencil.Text = "toolStripButton1";
            this.tsBtn_Pencil.ToolTipText = "Pencil";
            // 
            // tsBtn_Reload
            // 
            this.tsBtn_Reload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtn_Reload.Image = ((System.Drawing.Image)(resources.GetObject("tsBtn_Reload.Image")));
            this.tsBtn_Reload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtn_Reload.Name = "tsBtn_Reload";
            this.tsBtn_Reload.Size = new System.Drawing.Size(23, 20);
            this.tsBtn_Reload.Text = "toolStripButton4";
            this.tsBtn_Reload.ToolTipText = "Reload";
            this.tsBtn_Reload.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // pBox
            // 
            this.pBox.BackColor = System.Drawing.Color.Gray;
            this.pBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBox.Location = new System.Drawing.Point(0, 25);
            this.pBox.Margin = new System.Windows.Forms.Padding(2);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(360, 219);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox.TabIndex = 1;
            this.pBox.TabStop = false;
            // 
            // ImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.pnl_top);
            this.Name = "ImageSelector";
            this.Size = new System.Drawing.Size(360, 244);
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private AK_PictureBox pBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtn_Pencil;
        private System.Windows.Forms.ToolStripButton tsBtn_Crop;
        private System.Windows.Forms.ToolStripButton tsBtn_Stamp;
        private System.Windows.Forms.ToolStripButton tsBtn_Reload;
    }
}
