namespace BilgeSahaf.STOK
{
    partial class STOK_KARTLARI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STOK_KARTLARI));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sTOKHAREKETLERİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kARTIKOPYALAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rAPORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOKENVANTERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOKMALİYETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOKKARDURUMUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tAHMİNİENVANTERKAZANÇToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yENİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yENİSTOKKARTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataHareketler = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BELGE_TARIHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BELGE_NUMARASI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIREN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIKAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIRIM_FIYAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISKONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOPLAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKLENME_TARIHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAREKET_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAREKET_TIPI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACIKLAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHareketler)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(784, 284);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTOKHAREKETLERİToolStripMenuItem,
            this.kARTIKOPYALAToolStripMenuItem,
            this.toolStripSeparator1,
            this.rAPORToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 76);
            // 
            // sTOKHAREKETLERİToolStripMenuItem
            // 
            this.sTOKHAREKETLERİToolStripMenuItem.Name = "sTOKHAREKETLERİToolStripMenuItem";
            this.sTOKHAREKETLERİToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.sTOKHAREKETLERİToolStripMenuItem.Text = "DÜZENLE ";
            this.sTOKHAREKETLERİToolStripMenuItem.Click += new System.EventHandler(this.sTOKHAREKETLERİToolStripMenuItem_Click);
            // 
            // kARTIKOPYALAToolStripMenuItem
            // 
            this.kARTIKOPYALAToolStripMenuItem.Name = "kARTIKOPYALAToolStripMenuItem";
            this.kARTIKOPYALAToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.kARTIKOPYALAToolStripMenuItem.Text = "KARTI KOPYALA";
            this.kARTIKOPYALAToolStripMenuItem.Click += new System.EventHandler(this.kARTIKOPYALAToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // rAPORToolStripMenuItem
            // 
            this.rAPORToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTOKENVANTERToolStripMenuItem,
            this.sTOKMALİYETToolStripMenuItem,
            this.sTOKKARDURUMUToolStripMenuItem,
            this.tAHMİNİENVANTERKAZANÇToolStripMenuItem});
            this.rAPORToolStripMenuItem.Name = "rAPORToolStripMenuItem";
            this.rAPORToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.rAPORToolStripMenuItem.Text = "RAPOR";
            // 
            // sTOKENVANTERToolStripMenuItem
            // 
            this.sTOKENVANTERToolStripMenuItem.Name = "sTOKENVANTERToolStripMenuItem";
            this.sTOKENVANTERToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.sTOKENVANTERToolStripMenuItem.Text = "STOK ENVANTER";
            this.sTOKENVANTERToolStripMenuItem.Click += new System.EventHandler(this.sTOKENVANTERToolStripMenuItem_Click);
            // 
            // sTOKMALİYETToolStripMenuItem
            // 
            this.sTOKMALİYETToolStripMenuItem.Name = "sTOKMALİYETToolStripMenuItem";
            this.sTOKMALİYETToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.sTOKMALİYETToolStripMenuItem.Text = "STOK MALİYET";
            this.sTOKMALİYETToolStripMenuItem.Click += new System.EventHandler(this.sTOKMALİYETToolStripMenuItem_Click);
            // 
            // sTOKKARDURUMUToolStripMenuItem
            // 
            this.sTOKKARDURUMUToolStripMenuItem.Name = "sTOKKARDURUMUToolStripMenuItem";
            this.sTOKKARDURUMUToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.sTOKKARDURUMUToolStripMenuItem.Text = "STOK KAR DURUMU";
            this.sTOKKARDURUMUToolStripMenuItem.Click += new System.EventHandler(this.sTOKKARDURUMUToolStripMenuItem_Click);
            // 
            // tAHMİNİENVANTERKAZANÇToolStripMenuItem
            // 
            this.tAHMİNİENVANTERKAZANÇToolStripMenuItem.Name = "tAHMİNİENVANTERKAZANÇToolStripMenuItem";
            this.tAHMİNİENVANTERKAZANÇToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.tAHMİNİENVANTERKAZANÇToolStripMenuItem.Text = "TAHMİNİ ENVANTER KAZANÇ";
            this.tAHMİNİENVANTERKAZANÇToolStripMenuItem.Click += new System.EventHandler(this.tAHMİNİENVANTERKAZANÇToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 26);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripProgressBar1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
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
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yENİToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
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
            this.yENİSTOKKARTIToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yENİSTOKKARTIToolStripMenuItem.Text = "YENİ STOK KARTI";
            this.yENİSTOKKARTIToolStripMenuItem.Click += new System.EventHandler(this.yENİSTOKKARTIToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 223);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dataHareketler);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(776, 197);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Tüm Hareketler";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dataHareketler
            // 
            this.dataHareketler.AllowUserToAddRows = false;
            this.dataHareketler.AllowUserToDeleteRows = false;
            this.dataHareketler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TUR,
            this.BELGE_TARIHI,
            this.BELGE_NUMARASI,
            this.CARI,
            this.GIREN,
            this.CIKAN,
            this.BIRIM_FIYAT,
            this.ISKONTO,
            this.KDV,
            this.TOPLAM,
            this.EKLENME_TARIHI,
            this.HAREKET_ID,
            this.HAREKET_TIPI,
            this.ACIKLAMA});
            this.dataHareketler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataHareketler.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataHareketler.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataHareketler.Location = new System.Drawing.Point(3, 3);
            this.dataHareketler.Name = "dataHareketler";
            this.dataHareketler.ReadOnly = true;
            this.dataHareketler.Size = new System.Drawing.Size(770, 191);
            this.dataHareketler.TabIndex = 0;
            this.dataHareketler.DoubleClick += new System.EventHandler(this.dataHareketler_DoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // TUR
            // 
            this.TUR.HeaderText = "TÜR";
            this.TUR.Name = "TUR";
            this.TUR.ReadOnly = true;
            // 
            // BELGE_TARIHI
            // 
            this.BELGE_TARIHI.HeaderText = "BELGE TARİHİ";
            this.BELGE_TARIHI.Name = "BELGE_TARIHI";
            this.BELGE_TARIHI.ReadOnly = true;
            // 
            // BELGE_NUMARASI
            // 
            this.BELGE_NUMARASI.HeaderText = "BELGE NUMARASI";
            this.BELGE_NUMARASI.Name = "BELGE_NUMARASI";
            this.BELGE_NUMARASI.ReadOnly = true;
            // 
            // CARI
            // 
            this.CARI.HeaderText = "CARİ";
            this.CARI.Name = "CARI";
            this.CARI.ReadOnly = true;
            // 
            // GIREN
            // 
            this.GIREN.HeaderText = "GİREN";
            this.GIREN.Name = "GIREN";
            this.GIREN.ReadOnly = true;
            // 
            // CIKAN
            // 
            this.CIKAN.HeaderText = "ÇIKAN";
            this.CIKAN.Name = "CIKAN";
            this.CIKAN.ReadOnly = true;
            // 
            // BIRIM_FIYAT
            // 
            this.BIRIM_FIYAT.HeaderText = "BİRİM FİYAT";
            this.BIRIM_FIYAT.Name = "BIRIM_FIYAT";
            this.BIRIM_FIYAT.ReadOnly = true;
            // 
            // ISKONTO
            // 
            this.ISKONTO.HeaderText = "İSKONTO";
            this.ISKONTO.Name = "ISKONTO";
            this.ISKONTO.ReadOnly = true;
            // 
            // KDV
            // 
            this.KDV.HeaderText = "KDV";
            this.KDV.Name = "KDV";
            this.KDV.ReadOnly = true;
            // 
            // TOPLAM
            // 
            this.TOPLAM.HeaderText = "TOPLAM";
            this.TOPLAM.Name = "TOPLAM";
            this.TOPLAM.ReadOnly = true;
            // 
            // EKLENME_TARIHI
            // 
            this.EKLENME_TARIHI.HeaderText = "EKLENME TARİHİ";
            this.EKLENME_TARIHI.Name = "EKLENME_TARIHI";
            this.EKLENME_TARIHI.ReadOnly = true;
            // 
            // HAREKET_ID
            // 
            this.HAREKET_ID.HeaderText = "HAREKET_ID";
            this.HAREKET_ID.Name = "HAREKET_ID";
            this.HAREKET_ID.ReadOnly = true;
            this.HAREKET_ID.Visible = false;
            // 
            // HAREKET_TIPI
            // 
            this.HAREKET_TIPI.HeaderText = "HAREKET_TIPI";
            this.HAREKET_TIPI.Name = "HAREKET_TIPI";
            this.HAREKET_TIPI.ReadOnly = true;
            this.HAREKET_TIPI.Visible = false;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.HeaderText = "AÇIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.ReadOnly = true;
            // 
            // STOK_KARTLARI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "STOK_KARTLARI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOK KARTLARI";
            this.Load += new System.EventHandler(this.STOK_KARTLARI_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataHareketler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yENİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yENİSTOKKARTIToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rAPORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOKENVANTERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOKMALİYETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOKKARDURUMUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tAHMİNİENVANTERKAZANÇToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOKHAREKETLERİToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage7;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataHareketler;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem kARTIKOPYALAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn BELGE_TARIHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn BELGE_NUMARASI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARI;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIREN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIKAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIRIM_FIYAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISKONTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn KDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOPLAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKLENME_TARIHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAREKET_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAREKET_TIPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACIKLAMA;
    }
}