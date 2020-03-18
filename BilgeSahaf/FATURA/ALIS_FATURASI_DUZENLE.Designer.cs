namespace BilgeSahaf.FATURA
{
    partial class ALIS_FATURASI_DUZENLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALIS_FATURASI_DUZENLE));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kAYDETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fATURAYISİLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kAPATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDepo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBelgeNo = new System.Windows.Forms.TextBox();
            this.txtUnvani = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCariID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarih = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtBelgeNotu = new System.Windows.Forms.ToolStripTextBox();
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
            this.fATURAYISİLToolStripMenuItem,
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
            // fATURAYISİLToolStripMenuItem
            // 
            this.fATURAYISİLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fATURAYISİLToolStripMenuItem.Image")));
            this.fATURAYISİLToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fATURAYISİLToolStripMenuItem.Name = "fATURAYISİLToolStripMenuItem";
            this.fATURAYISİLToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.fATURAYISİLToolStripMenuItem.Text = "FATURAYI SİL";
            this.fATURAYISİLToolStripMenuItem.Click += new System.EventHandler(this.fATURAYISİLToolStripMenuItem_Click);
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
            this.groupBox1.Controls.Add(this.txtUnvani);
            this.groupBox1.Controls.Add(this.label8);
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
            this.txtDepo.Location = new System.Drawing.Point(398, 45);
            this.txtDepo.Name = "txtDepo";
            this.txtDepo.Size = new System.Drawing.Size(96, 21);
            this.txtDepo.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(395, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Depo";
            // 
            // txtBelgeNo
            // 
            this.txtBelgeNo.Location = new System.Drawing.Point(503, 45);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new System.Drawing.Size(100, 20);
            this.txtBelgeNo.TabIndex = 11;
            // 
            // txtUnvani
            // 
            this.txtUnvani.Location = new System.Drawing.Point(179, 48);
            this.txtUnvani.Name = "txtUnvani";
            this.txtUnvani.ReadOnly = true;
            this.txtUnvani.Size = new System.Drawing.Size(116, 20);
            this.txtUnvani.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Belge No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 26);
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
            this.txtGenelToplam.Location = new System.Drawing.Point(622, 48);
            this.txtGenelToplam.Name = "txtGenelToplam";
            this.txtGenelToplam.ReadOnly = true;
            this.txtGenelToplam.Size = new System.Drawing.Size(150, 20);
            this.txtGenelToplam.TabIndex = 10;
            this.txtGenelToplam.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(619, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "GENEL TOPLAM";
            // 
            // txtKdv
            // 
            this.txtKdv.Location = new System.Drawing.Point(421, 48);
            this.txtKdv.Name = "txtKdv";
            this.txtKdv.ReadOnly = true;
            this.txtKdv.Size = new System.Drawing.Size(150, 20);
            this.txtKdv.TabIndex = 8;
            this.txtKdv.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "KDV TOPLAM";
            // 
            // txtIskonto
            // 
            this.txtIskonto.Location = new System.Drawing.Point(220, 48);
            this.txtIskonto.Name = "txtIskonto";
            this.txtIskonto.ReadOnly = true;
            this.txtIskonto.Size = new System.Drawing.Size(150, 20);
            this.txtIskonto.TabIndex = 6;
            this.txtIskonto.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 26);
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
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.dataGridView1.Location = new System.Drawing.Point(0, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 342);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
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
            this.toolStrip1.TabIndex = 12;
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
            // ALIS_FATURASI_DUZENLE
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
            this.Name = "ALIS_FATURASI_DUZENLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALIŞ FATURASI DÜZENLE";
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
        private System.Windows.Forms.ToolStripMenuItem fATURAYISİLToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBelgeNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtDepo;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtBelgeNotu;
    }
}