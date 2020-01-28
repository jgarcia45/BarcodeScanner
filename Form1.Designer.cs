namespace BarcodeRecoveryCS
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
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToBWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generate128ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generate39ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToBlackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifyBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identifyGoodBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconstructToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDisplay.Location = new System.Drawing.Point(0, 46);
            this.picDisplay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(2156, 1202);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.identifyBarsToolStripMenuItem,
            this.identifyGoodBarsToolStripMenuItem,
            this.reconstructToolStripMenuItem,
            this.traversToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(2156, 46);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadImageToolStripMenuItem,
            this.decodeBarcodeToolStripMenuItem,
            this.changeToBWToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uploadImageToolStripMenuItem
            // 
            this.uploadImageToolStripMenuItem.Name = "uploadImageToolStripMenuItem";
            this.uploadImageToolStripMenuItem.Size = new System.Drawing.Size(290, 38);
            this.uploadImageToolStripMenuItem.Text = "Upload Image";
            this.uploadImageToolStripMenuItem.Click += new System.EventHandler(this.uploadImageToolStripMenuItem_Click);
            // 
            // decodeBarcodeToolStripMenuItem
            // 
            this.decodeBarcodeToolStripMenuItem.Name = "decodeBarcodeToolStripMenuItem";
            this.decodeBarcodeToolStripMenuItem.Size = new System.Drawing.Size(290, 38);
            this.decodeBarcodeToolStripMenuItem.Text = "Decode Barcode";
            this.decodeBarcodeToolStripMenuItem.Click += new System.EventHandler(this.decodeBarcodeToolStripMenuItem_Click);
            // 
            // changeToBWToolStripMenuItem
            // 
            this.changeToBWToolStripMenuItem.Name = "changeToBWToolStripMenuItem";
            this.changeToBWToolStripMenuItem.Size = new System.Drawing.Size(290, 38);
            this.changeToBWToolStripMenuItem.Text = "Change to BW";
            this.changeToBWToolStripMenuItem.Click += new System.EventHandler(this.changeToBWToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generate128ToolStripMenuItem,
            this.generate39ToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(290, 38);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // generate128ToolStripMenuItem
            // 
            this.generate128ToolStripMenuItem.Name = "generate128ToolStripMenuItem";
            this.generate128ToolStripMenuItem.Size = new System.Drawing.Size(258, 38);
            this.generate128ToolStripMenuItem.Text = "Generate 128";
            this.generate128ToolStripMenuItem.Click += new System.EventHandler(this.generate128ToolStripMenuItem_Click_1);
            // 
            // generate39ToolStripMenuItem
            // 
            this.generate39ToolStripMenuItem.Name = "generate39ToolStripMenuItem";
            this.generate39ToolStripMenuItem.Size = new System.Drawing.Size(258, 38);
            this.generate39ToolStripMenuItem.Text = "Generate 39";
            this.generate39ToolStripMenuItem.Click += new System.EventHandler(this.generate39ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(290, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(290, 38);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToBlackAndWhiteToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.normalizeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 38);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // convertToBlackAndWhiteToolStripMenuItem
            // 
            this.convertToBlackAndWhiteToolStripMenuItem.Name = "convertToBlackAndWhiteToolStripMenuItem";
            this.convertToBlackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(407, 38);
            this.convertToBlackAndWhiteToolStripMenuItem.Text = "Convert to Black and White";
            this.convertToBlackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.convertToBlackAndWhiteToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(407, 38);
            this.thresholdToolStripMenuItem.Text = "Threshold";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(407, 38);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(407, 38);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
            // 
            // normalizeToolStripMenuItem
            // 
            this.normalizeToolStripMenuItem.Name = "normalizeToolStripMenuItem";
            this.normalizeToolStripMenuItem.Size = new System.Drawing.Size(407, 38);
            this.normalizeToolStripMenuItem.Text = "Normalize";
            this.normalizeToolStripMenuItem.Click += new System.EventHandler(this.normalizeToolStripMenuItem_Click);
            // 
            // identifyBarsToolStripMenuItem
            // 
            this.identifyBarsToolStripMenuItem.Name = "identifyBarsToolStripMenuItem";
            this.identifyBarsToolStripMenuItem.Size = new System.Drawing.Size(159, 38);
            this.identifyBarsToolStripMenuItem.Text = "Identify Bars";
            this.identifyBarsToolStripMenuItem.Click += new System.EventHandler(this.identifyBarsToolStripMenuItem_Click);
            // 
            // identifyGoodBarsToolStripMenuItem
            // 
            this.identifyGoodBarsToolStripMenuItem.Name = "identifyGoodBarsToolStripMenuItem";
            this.identifyGoodBarsToolStripMenuItem.Size = new System.Drawing.Size(224, 38);
            this.identifyGoodBarsToolStripMenuItem.Text = "Identify Good Bars";
            this.identifyGoodBarsToolStripMenuItem.Click += new System.EventHandler(this.identifyGoodBarsToolStripMenuItem_Click);
            // 
            // reconstructToolStripMenuItem
            // 
            this.reconstructToolStripMenuItem.Name = "reconstructToolStripMenuItem";
            this.reconstructToolStripMenuItem.Size = new System.Drawing.Size(151, 38);
            this.reconstructToolStripMenuItem.Text = "Reconstruct";
            this.reconstructToolStripMenuItem.Click += new System.EventHandler(this.reconstructToolStripMenuItem_Click);
            // 
            // traversToolStripMenuItem
            // 
            this.traversToolStripMenuItem.Name = "traversToolStripMenuItem";
            this.traversToolStripMenuItem.Size = new System.Drawing.Size(134, 38);
            this.traversToolStripMenuItem.Text = "Undo Test";
            this.traversToolStripMenuItem.Click += new System.EventHandler(this.traversToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2156, 1248);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Recover Barcodes";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identifyBarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identifyGoodBarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconstructToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToBWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generate128ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generate39ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToBlackAndWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalizeToolStripMenuItem;
    }
}

