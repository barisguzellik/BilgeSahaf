namespace BilgeSahaf.FATURA
{
    partial class YENI_ALIS_FATURASI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YENI_ALIS_FATURASI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kAYDETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aKTARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kİDAALIŞFATURASIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kAPATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDepo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBelgeNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUnvani = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCariID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarih = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtToplamAdet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtToplam = new System.Windows.Forms.TextBox();
            this.txtGenelToplam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKdv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIskonto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.URUN_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARKOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOK_ADI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACIKLAMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIRIM_FIYAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISKONTO_ORAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISKONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOPLAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtBelgeNotu = new System.Windows.Forms.ToolStripTextBox();
            this.eFATXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kAYDETToolStripMenuItem,
            this.aKTARToolStripMenuItem,
            this.kAPATToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kAYDETToolStripMenuItem
            // 
            this.kAYDETToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kAYDETToolStripMenuItem.Image")));
            this.kAYDETToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.kAYDETToolStripMenuItem.Name = "kAYDETToolStripMenuItem";
            this.kAYDETToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.kAYDETToolStripMenuItem.Text = "KAYDET";
            this.kAYDETToolStripMenuItem.Click += new System.EventHandler(this.kAYDETToolStripMenuItem_Click);
            // 
            // aKTARToolStripMenuItem
            // 
            this.aKTARToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kİDAALIŞFATURASIToolStripMenuItem,
            this.xMLToolStripMenuItem,
            this.eFATXMLToolStripMenuItem});
            this.aKTARToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aKTARToolStripMenuItem.Image")));
            this.aKTARToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aKTARToolStripMenuItem.Name = "aKTARToolStripMenuItem";
            this.aKTARToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.aKTARToolStripMenuItem.Text = "GETİR";
            this.aKTARToolStripMenuItem.Click += new System.EventHandler(this.aKTARToolStripMenuItem_Click);
            // 
            // kİDAALIŞFATURASIToolStripMenuItem
            // 
            this.kİDAALIŞFATURASIToolStripMenuItem.Name = "kİDAALIŞFATURASIToolStripMenuItem";
            this.kİDAALIŞFATURASIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kİDAALIŞFATURASIToolStripMenuItem.Text = "EXCEL (DEFAULT)";
            this.kİDAALIŞFATURASIToolStripMenuItem.Click += new System.EventHandler(this.kİDAALIŞFATURASIToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xMLToolStripMenuItem.Text = "E-FAT XML (EMEK)";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // kAPATToolStripMenuItem
            // 
            this.kAPATToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kAPATToolStripMenuItem.Image")));
            this.kAPATToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.kAPATToolStripMenuItem.Name = "kAPATToolStripMenuItem";
            this.kAPATToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.kAPATToolStripMenuItem.Text = "KAPAT";
            this.kAPATToolStripMenuItem.Click += new System.EventHandler(this.kAPATToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDepo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBelgeNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtUnvani);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtCariID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTarih);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgiler";
            // 
            // txtDepo
            // 
            this.txtDepo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDepo.FormattingEnabled = true;
            this.txtDepo.Location = new System.Drawing.Point(402, 44);
            this.txtDepo.Name = "txtDepo";
            this.txtDepo.Size = new System.Drawing.Size(96, 21);
            this.txtDepo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(399, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Depo";
            // 
            // txtBelgeNo
            // 
            this.txtBelgeNo.Location = new System.Drawing.Point(504, 45);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new System.Drawing.Size(100, 20);
            this.txtBelgeNo.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Belge No";
            // 
            // txtUnvani
            // 
            this.txtUnvani.Location = new System.Drawing.Point(158, 48);
            this.txtUnvani.Name = "txtUnvani";
            this.txtUnvani.ReadOnly = true;
            this.txtUnvani.Size = new System.Drawing.Size(170, 20);
            this.txtUnvani.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cari Ünvanı";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCariID
            // 
            this.txtCariID.Location = new System.Drawing.Point(19, 48);
            this.txtCariID.Name = "txtCariID";
            this.txtCariID.ReadOnly = true;
            this.txtCariID.Size = new System.Drawing.Size(100, 20);
            this.txtCariID.TabIndex = 3;
            this.txtCariID.TextChanged += new System.EventHandler(this.txtCariID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cari";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarih";
            // 
            // txtTarih
            // 
            this.txtTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtTarih.Location = new System.Drawing.Point(610, 45);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.Size = new System.Drawing.Size(162, 20);
            this.txtTarih.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtToplamAdet);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtToplam);
            this.groupBox2.Controls.Add(this.txtGenelToplam);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtKdv);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIskonto);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 476);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 85);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fatura Toplamları";
            // 
            // txtToplamAdet
            // 
            this.txtToplamAdet.Location = new System.Drawing.Point(643, 48);
            this.txtToplamAdet.Name = "txtToplamAdet";
            this.txtToplamAdet.ReadOnly = true;
            this.txtToplamAdet.Size = new System.Drawing.Size(109, 20);
            this.txtToplamAdet.TabIndex = 13;
            this.txtToplamAdet.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(640, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "TOPLAM ADET";
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(19, 48);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.ReadOnly = true;
            this.txtToplam.Size = new System.Drawing.Size(150, 20);
            this.txtToplam.TabIndex = 11;
            this.txtToplam.Text = "0";
            // 
            // txtGenelToplam
            // 
            this.txtGenelToplam.Location = new System.Drawing.Point(487, 48);
            this.txtGenelToplam.Name = "txtGenelToplam";
            this.txtGenelToplam.ReadOnly = true;
            this.txtGenelToplam.Size = new System.Drawing.Size(150, 20);
            this.txtGenelToplam.TabIndex = 10;
            this.txtGenelToplam.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(484, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "GENEL TOPLAM";
            // 
            // txtKdv
            // 
            this.txtKdv.Location = new System.Drawing.Point(331, 48);
            this.txtKdv.Name = "txtKdv";
            this.txtKdv.ReadOnly = true;
            this.txtKdv.Size = new System.Drawing.Size(150, 20);
            this.txtKdv.TabIndex = 8;
            this.txtKdv.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "KDV TOPLAM";
            // 
            // txtIskonto
            // 
            this.txtIskonto.Location = new System.Drawing.Point(175, 48);
            this.txtIskonto.Name = "txtIskonto";
            this.txtIskonto.ReadOnly = true;
            this.txtIskonto.Size = new System.Drawing.Size(150, 20);
            this.txtIskonto.TabIndex = 6;
            this.txtIskonto.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "İSKONTO TOPLAM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "TOPLAM";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URUN_ID,
            this.BARKOD,
            this.STOK_ADI,
            this.ACIKLAMA,
            this.ADET,
            this.BIRIM_FIYAT,
            this.ISKONTO_ORAN,
            this.ISKONTO,
            this.KDV,
            this.TOPLAM});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataGridView1.Location = new System.Drawing.Point(0, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 342);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // URUN_ID
            // 
            this.URUN_ID.HeaderText = "STOK ID";
            this.URUN_ID.Name = "URUN_ID";
            this.URUN_ID.ReadOnly = true;
            // 
            // BARKOD
            // 
            this.BARKOD.HeaderText = "BARKOD";
            this.BARKOD.Name = "BARKOD";
            // 
            // STOK_ADI
            // 
            this.STOK_ADI.HeaderText = "STOK ADI";
            this.STOK_ADI.Name = "STOK_ADI";
            this.STOK_ADI.ReadOnly = true;
            // 
            // ACIKLAMA
            // 
            this.ACIKLAMA.HeaderText = "AÇIKLAMA";
            this.ACIKLAMA.Name = "ACIKLAMA";
            // 
            // ADET
            // 
            this.ADET.HeaderText = "MİKTAR";
            this.ADET.Name = "ADET";
            // 
            // BIRIM_FIYAT
            // 
            this.BIRIM_FIYAT.HeaderText = "BİRİM FİYAT";
            this.BIRIM_FIYAT.Name = "BIRIM_FIYAT";
            // 
            // ISKONTO_ORAN
            // 
            this.ISKONTO_ORAN.HeaderText = "İNDİRİM %";
            this.ISKONTO_ORAN.Name = "ISKONTO_ORAN";
            // 
            // ISKONTO
            // 
            this.ISKONTO.HeaderText = "İNDİRİM TL";
            this.ISKONTO.Name = "ISKONTO";
            // 
            // KDV
            // 
            this.KDV.HeaderText = "KDV";
            this.KDV.Name = "KDV";
            // 
            // TOPLAM
            // 
            this.TOPLAM.HeaderText = "TOPLAM";
            this.TOPLAM.Name = "TOPLAM";
            this.TOPLAM.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtBelgeNotu});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel1.Text = "Belge Notu";
            // 
            // txtBelgeNotu
            // 
            this.txtBelgeNotu.Name = "txtBelgeNotu";
            this.txtBelgeNotu.Size = new System.Drawing.Size(500, 25);
            // 
            // eFATXMLToolStripMenuItem
            // 
            this.eFATXMLToolStripMenuItem.Name = "eFATXMLToolStripMenuItem";
            this.eFATXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eFATXMLToolStripMenuItem.Text = "E-FAT XML (PREFIX)";
            this.eFATXMLToolStripMenuItem.Click += new System.EventHandler(this.eFATXMLToolStripMenuItem_Click);
            // 
            // YENI_ALIS_FATURASI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "YENI_ALIS_FATURASI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YENİ ALIŞ FATURASI";
            this.Load += new System.EventHandler(this.YENI_SATIS_FATURASI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kAYDETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kAPATToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUnvani;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCariID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtTarih;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtToplam;
        private System.Windows.Forms.TextBox txtGenelToplam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKdv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIskonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBelgeNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtDepo;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn URUN_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARKOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOK_ADI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACIKLAMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADET;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIRIM_FIYAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISKONTO_ORAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISKONTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn KDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOPLAM;
        private System.Windows.Forms.ToolStripMenuItem aKTARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kİDAALIŞFATURASIToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtToplamAdet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtBelgeNotu;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eFATXMLToolStripMenuItem;
    }
}