namespace BilgeSahaf.FATURA
{
    partial class ALIS_FATURALARI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALIS_FATURALARI));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sumToplam = new System.Windows.Forms.Label();
            this.sumIskonto = new System.Windows.Forms.Label();
            this.sumKdv = new System.Windows.Forms.Label();
            this.sumGenelToplam = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yENİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yENİSTOKKARTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataIcerik = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataIcerik)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(784, 206);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel2.Controls.Add(this.sumToplam);
            this.panel2.Controls.Add(this.sumIskonto);
            this.panel2.Controls.Add(this.sumKdv);
            this.panel2.Controls.Add(this.sumGenelToplam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 25);
            this.panel2.TabIndex = 14;
            // 
            // sumToplam
            // 
            this.sumToplam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumToplam.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumToplam.Location = new System.Drawing.Point(-16, 0);
            this.sumToplam.Name = "sumToplam";
            this.sumToplam.Size = new System.Drawing.Size(200, 25);
            this.sumToplam.TabIndex = 0;
            this.sumToplam.Text = "ALACAK : 0.00";
            this.sumToplam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sumIskonto
            // 
            this.sumIskonto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumIskonto.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumIskonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumIskonto.Location = new System.Drawing.Point(184, 0);
            this.sumIskonto.Name = "sumIskonto";
            this.sumIskonto.Size = new System.Drawing.Size(200, 25);
            this.sumIskonto.TabIndex = 1;
            this.sumIskonto.Text = "BORÇ : 0.00";
            this.sumIskonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sumKdv
            // 
            this.sumKdv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumKdv.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumKdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumKdv.Location = new System.Drawing.Point(384, 0);
            this.sumKdv.Name = "sumKdv";
            this.sumKdv.Size = new System.Drawing.Size(200, 25);
            this.sumKdv.TabIndex = 2;
            this.sumKdv.Text = "BAKİYE : 0.00";
            this.sumKdv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sumGenelToplam
            // 
            this.sumGenelToplam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumGenelToplam.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumGenelToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumGenelToplam.Location = new System.Drawing.Point(584, 0);
            this.sumGenelToplam.Name = "sumGenelToplam";
            this.sumGenelToplam.Size = new System.Drawing.Size(200, 25);
            this.sumGenelToplam.TabIndex = 3;
            this.sumGenelToplam.Text = "BAKİYE : 0.00";
            this.sumGenelToplam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "FİLTRELE";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBox1_KeyPress);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yENİToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yENİToolStripMenuItem
            // 
            this.yENİToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yENİSTOKKARTIToolStripMenuItem});
            this.yENİToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("yENİToolStripMenuItem.Image")));
            this.yENİToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.yENİToolStripMenuItem.Name = "yENİToolStripMenuItem";
            this.yENİToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.yENİToolStripMenuItem.Text = "YENİ";
            // 
            // yENİSTOKKARTIToolStripMenuItem
            // 
            this.yENİSTOKKARTIToolStripMenuItem.Name = "yENİSTOKKARTIToolStripMenuItem";
            this.yENİSTOKKARTIToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.yENİSTOKKARTIToolStripMenuItem.Text = "YENİ ALIŞ FATURASI";
            this.yENİSTOKKARTIToolStripMenuItem.Click += new System.EventHandler(this.yENİSTOKKARTIToolStripMenuItem_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 277);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataIcerik);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "İçerik";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataIcerik
            // 
            this.dataIcerik.AllowUserToAddRows = false;
            this.dataIcerik.AllowUserToDeleteRows = false;
            this.dataIcerik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataIcerik.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataIcerik.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataIcerik.Location = new System.Drawing.Point(3, 3);
            this.dataIcerik.Margin = new System.Windows.Forms.Padding(2);
            this.dataIcerik.Name = "dataIcerik";
            this.dataIcerik.ReadOnly = true;
            this.dataIcerik.RowTemplate.Height = 24;
            this.dataIcerik.Size = new System.Drawing.Size(770, 245);
            this.dataIcerik.TabIndex = 1;
            this.dataIcerik.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataIcerik_DataBindingComplete);
            this.dataIcerik.DoubleClick += new System.EventHandler(this.dataIcerik_DoubleClick);
            // 
            // ALIS_FATURALARI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "ALIS_FATURALARI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALIŞ FATURALARI";
            this.Load += new System.EventHandler(this.SATIS_FATURALARI_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataIcerik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yENİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yENİSTOKKARTIToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataIcerik;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label sumToplam;
        private System.Windows.Forms.Label sumIskonto;
        private System.Windows.Forms.Label sumKdv;
        private System.Windows.Forms.Label sumGenelToplam;
    }
}