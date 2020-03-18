namespace BilgeSahaf.RAPOR
{
    partial class RAPOR_SORGU_CALISTIR
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.çALIŞTIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sORGUYUÇALIŞTIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kAPATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çALIŞTIRToolStripMenuItem,
            this.kAPATToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(557, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // çALIŞTIRToolStripMenuItem
            // 
            this.çALIŞTIRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sORGUYUÇALIŞTIRToolStripMenuItem});
            this.çALIŞTIRToolStripMenuItem.Name = "çALIŞTIRToolStripMenuItem";
            this.çALIŞTIRToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.çALIŞTIRToolStripMenuItem.Text = "ÇALIŞTIR";
            // 
            // sORGUYUÇALIŞTIRToolStripMenuItem
            // 
            this.sORGUYUÇALIŞTIRToolStripMenuItem.Name = "sORGUYUÇALIŞTIRToolStripMenuItem";
            this.sORGUYUÇALIŞTIRToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sORGUYUÇALIŞTIRToolStripMenuItem.Text = "SORGUYU ÇALIŞTIR";
            this.sORGUYUÇALIŞTIRToolStripMenuItem.Click += new System.EventHandler(this.sORGUYUÇALIŞTIRToolStripMenuItem_Click);
            // 
            // kAPATToolStripMenuItem
            // 
            this.kAPATToolStripMenuItem.Name = "kAPATToolStripMenuItem";
            this.kAPATToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kAPATToolStripMenuItem.Text = "KAPAT";
            this.kAPATToolStripMenuItem.Click += new System.EventHandler(this.kAPATToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(557, 334);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // RAPOR_SORGU_CALISTIR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 358);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RAPOR_SORGU_CALISTIR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAPOR SORGU ÇALIŞTIR";
            this.Load += new System.EventHandler(this.RAPOR_SORGU_CALISTIR_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem çALIŞTIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sORGUYUÇALIŞTIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kAPATToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}