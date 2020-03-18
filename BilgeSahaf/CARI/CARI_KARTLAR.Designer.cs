namespace BilgeSahaf.CARI
{
    partial class CARI_KARTLAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CARI_KARTLAR));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dÜZENLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rAPORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cARİBAKİYEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sumAlacak = new System.Windows.Forms.Label();
            this.sumBorc = new System.Windows.Forms.Label();
            this.sumBakiye = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yENİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yENİSTOKKARTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAZDIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.HAREKET_TIPI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAREKET_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARIH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BORC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALACAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BELGE_TARIHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_TARIH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ALACAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_BORC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_EKLENME_TARIHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ITEM_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BELGE_NUMARASI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACIKLAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(784, 261);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Tag = "CariGrid1";
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dÜZENLEToolStripMenuItem,
            this.rAPORToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // dÜZENLEToolStripMenuItem
            // 
            this.dÜZENLEToolStripMenuItem.Name = "dÜZENLEToolStripMenuItem";
            this.dÜZENLEToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dÜZENLEToolStripMenuItem.Text = "DÜZENLE";
            this.dÜZENLEToolStripMenuItem.Click += new System.EventHandler(this.dÜZENLEToolStripMenuItem_Click);
            // 
            // rAPORToolStripMenuItem
            // 
            this.rAPORToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cARİBAKİYEToolStripMenuItem});
            this.rAPORToolStripMenuItem.Name = "rAPORToolStripMenuItem";
            this.rAPORToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rAPORToolStripMenuItem.Text = "RAPOR";
            // 
            // cARİBAKİYEToolStripMenuItem
            // 
            this.cARİBAKİYEToolStripMenuItem.Name = "cARİBAKİYEToolStripMenuItem";
            this.cARİBAKİYEToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.cARİBAKİYEToolStripMenuItem.Text = "CARİ BAKİYE";
            this.cARİBAKİYEToolStripMenuItem.Click += new System.EventHandler(this.cARİBAKİYEToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel2.Controls.Add(this.sumAlacak);
            this.panel2.Controls.Add(this.sumBorc);
            this.panel2.Controls.Add(this.sumBakiye);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 311);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 25);
            this.panel2.TabIndex = 4;
            // 
            // sumAlacak
            // 
            this.sumAlacak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumAlacak.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumAlacak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumAlacak.Location = new System.Drawing.Point(184, 0);
            this.sumAlacak.Name = "sumAlacak";
            this.sumAlacak.Size = new System.Drawing.Size(200, 25);
            this.sumAlacak.TabIndex = 0;
            this.sumAlacak.Text = "ALACAK : 0.00";
            this.sumAlacak.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sumBorc
            // 
            this.sumBorc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumBorc.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumBorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumBorc.Location = new System.Drawing.Point(384, 0);
            this.sumBorc.Name = "sumBorc";
            this.sumBorc.Size = new System.Drawing.Size(200, 25);
            this.sumBorc.TabIndex = 1;
            this.sumBorc.Text = "BORÇ : 0.00";
            this.sumBorc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sumBakiye
            // 
            this.sumBakiye.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sumBakiye.Dock = System.Windows.Forms.DockStyle.Right;
            this.sumBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sumBakiye.Location = new System.Drawing.Point(584, 0);
            this.sumBakiye.Name = "sumBakiye";
            this.sumBakiye.Size = new System.Drawing.Size(200, 25);
            this.sumBakiye.TabIndex = 2;
            this.sumBakiye.Text = "BAKİYE : 0.00";
            this.sumBakiye.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1});
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
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yENİToolStripMenuItem,
            this.yAZDIRToolStripMenuItem});
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
            this.yENİToolStripMenuItem.Name = "yENİToolStripMenuItem";
            this.yENİToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.yENİToolStripMenuItem.Text = "YENİ";
            // 
            // yENİSTOKKARTIToolStripMenuItem
            // 
            this.yENİSTOKKARTIToolStripMenuItem.Name = "yENİSTOKKARTIToolStripMenuItem";
            this.yENİSTOKKARTIToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.yENİSTOKKARTIToolStripMenuItem.Text = "YENİ CARİ KART";
            this.yENİSTOKKARTIToolStripMenuItem.Click += new System.EventHandler(this.yENİSTOKKARTIToolStripMenuItem_Click);
            // 
            // yAZDIRToolStripMenuItem
            // 
            this.yAZDIRToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("yAZDIRToolStripMenuItem.Image")));
            this.yAZDIRToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.yAZDIRToolStripMenuItem.Name = "yAZDIRToolStripMenuItem";
            this.yAZDIRToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.yAZDIRToolStripMenuItem.Text = "YAZDIR";
            this.yAZDIRToolStripMenuItem.Click += new System.EventHandler(this.yAZDIRToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 221);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DoubleClick += new System.EventHandler(this.tabControl1_DoubleClick);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.dataGridView2);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(776, 195);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "Tüm Hareketler";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_TUR,
            this.COL_TARIH,
            this.COL_ALACAK,
            this.COL_BORC,
            this.COL_EKLENME_TARIHI,
            this.COL_ITEM_ID,
            this.COL_ITEM_TYPE,
            this.BELGE_NUMARASI,
            this.ACIKLAMA});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataGridView2.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataGridView2.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Custom1;
            this.dataGridView2.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Custom1;
            this.dataGridView2.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Custom1;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(770, 189);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.Tag = "CariGrid2";
            this.dataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // HAREKET_TIPI
            // 
            this.HAREKET_TIPI.HeaderText = "HAREKET_TIPI";
            this.HAREKET_TIPI.Name = "HAREKET_TIPI";
            this.HAREKET_TIPI.ReadOnly = true;
            this.HAREKET_TIPI.Visible = false;
            // 
            // HAREKET_ID
            // 
            this.HAREKET_ID.HeaderText = "HAREKET_ID";
            this.HAREKET_ID.Name = "HAREKET_ID";
            this.HAREKET_ID.ReadOnly = true;
            this.HAREKET_ID.Visible = false;
            // 
            // TARIH
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.TARIH.DefaultCellStyle = dataGridViewCellStyle1;
            this.TARIH.HeaderText = "TARİH";
            this.TARIH.Name = "TARIH";
            this.TARIH.ReadOnly = true;
            // 
            // BORC
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.BORC.DefaultCellStyle = dataGridViewCellStyle2;
            this.BORC.HeaderText = "BORÇ";
            this.BORC.Name = "BORC";
            this.BORC.ReadOnly = true;
            // 
            // ALACAK
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ALACAK.DefaultCellStyle = dataGridViewCellStyle3;
            this.ALACAK.HeaderText = "ALACAK";
            this.ALACAK.Name = "ALACAK";
            this.ALACAK.ReadOnly = true;
            // 
            // BELGE_TARIHI
            // 
            this.BELGE_TARIHI.HeaderText = "BELGE TARİHİ";
            this.BELGE_TARIHI.Name = "BELGE_TARIHI";
            this.BELGE_TARIHI.ReadOnly = true;
            // 
            // TUR
            // 
            this.TUR.HeaderText = "TÜR";
            this.TUR.Name = "TUR";
            this.TUR.ReadOnly = true;
            // 
            // COL_TUR
            // 
            this.COL_TUR.HeaderText = "TÜR";
            this.COL_TUR.Name = "COL_TUR";
            this.COL_TUR.ReadOnly = true;
            this.COL_TUR.Width = 146;
            // 
            // COL_TARIH
            // 
            this.COL_TARIH.HeaderText = "BELGE TARİHİ";
            this.COL_TARIH.Name = "COL_TARIH";
            this.COL_TARIH.ReadOnly = true;
            this.COL_TARIH.Width = 146;
            // 
            // COL_ALACAK
            // 
            this.COL_ALACAK.HeaderText = "ALACAK";
            this.COL_ALACAK.Name = "COL_ALACAK";
            this.COL_ALACAK.ReadOnly = true;
            this.COL_ALACAK.Width = 145;
            // 
            // COL_BORC
            // 
            this.COL_BORC.HeaderText = "BORÇ";
            this.COL_BORC.Name = "COL_BORC";
            this.COL_BORC.ReadOnly = true;
            this.COL_BORC.Width = 146;
            // 
            // COL_EKLENME_TARIHI
            // 
            this.COL_EKLENME_TARIHI.HeaderText = "EKLENME TARİHİ";
            this.COL_EKLENME_TARIHI.Name = "COL_EKLENME_TARIHI";
            this.COL_EKLENME_TARIHI.ReadOnly = true;
            this.COL_EKLENME_TARIHI.Width = 146;
            // 
            // COL_ITEM_ID
            // 
            this.COL_ITEM_ID.HeaderText = "COL_ITEM_ID";
            this.COL_ITEM_ID.Name = "COL_ITEM_ID";
            this.COL_ITEM_ID.ReadOnly = true;
            this.COL_ITEM_ID.Visible = false;
            // 
            // COL_ITEM_TYPE
            // 
            this.COL_ITEM_TYPE.HeaderText = "COL_ITEM_TYPE";
            this.COL_ITEM_TYPE.Name = "COL_ITEM_TYPE";
            this.COL_ITEM_TYPE.ReadOnly = true;
            this.COL_ITEM_TYPE.Visible = false;
            // 
            // BELGE_NUMARASI
            // 
            this.BELGE_NUMARASI.HeaderText = "BELGE NUMARASI";
            this.BELGE_NUMARASI.Name = "BELGE_NUMARASI";
            this.BELGE_NUMARASI.ReadOnly = true;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.HeaderText = "AÇIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            this.ACIKLAMA.ReadOnly = true;
            // 
            // CARI_KARTLAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "CARI_KARTLAR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARİ KARTLAR";
            this.Load += new System.EventHandler(this.CARI_KARTLAR_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CARI_KARTLAR_KeyPress);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yENİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yENİSTOKKARTIToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rAPORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cARİBAKİYEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dÜZENLEToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAREKET_TIPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAREKET_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARIH;
        private System.Windows.Forms.DataGridViewTextBoxColumn BORC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALACAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn BELGE_TARIHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TUR;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label sumAlacak;
        private System.Windows.Forms.Label sumBorc;
        private System.Windows.Forms.Label sumBakiye;
        private System.Windows.Forms.ToolStripMenuItem yAZDIRToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_TARIH;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ALACAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_BORC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_EKLENME_TARIHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ITEM_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ITEM_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BELGE_NUMARASI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACIKLAMA;
    }
}