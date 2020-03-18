namespace BilgeSahaf.GIRIS
{
    partial class GIRIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GIRIS));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectionFalse = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectionTrue = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtUser = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPwd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionFalse,
            this.connectionTrue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 175);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(353, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connectionFalse
            // 
            this.connectionFalse.BackColor = System.Drawing.Color.Transparent;
            this.connectionFalse.ForeColor = System.Drawing.Color.Red;
            this.connectionFalse.Name = "connectionFalse";
            this.connectionFalse.Size = new System.Drawing.Size(125, 17);
            this.connectionFalse.Text = "İnternet Bağlantısı Yok";
            this.connectionFalse.Visible = false;
            // 
            // connectionTrue
            // 
            this.connectionTrue.BackColor = System.Drawing.Color.Transparent;
            this.connectionTrue.ForeColor = System.Drawing.Color.Green;
            this.connectionTrue.Name = "connectionTrue";
            this.connectionTrue.Size = new System.Drawing.Size(130, 17);
            this.connectionTrue.Text = "İnternet Bağlantısı Aktif";
            this.connectionTrue.Visible = false;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(123, 106);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonButton1.Size = new System.Drawing.Size(163, 37);
            this.kryptonButton1.TabIndex = 9;
            this.kryptonButton1.Values.Text = "GİRİŞ YAP";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // txtUser
            // 
            this.txtUser.AlwaysActive = false;
            this.txtUser.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.txtUser.Location = new System.Drawing.Point(123, 54);
            this.txtUser.Name = "txtUser";
            this.txtUser.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtUser.Size = new System.Drawing.Size(163, 20);
            this.txtUser.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 163;
            this.comboBox1.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.comboBox1.Location = new System.Drawing.Point(123, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(68, 28);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel1.TabIndex = 12;
            this.kryptonLabel1.Values.Text = "Şube";
            // 
            // txtPwd
            // 
            this.txtPwd.AlwaysActive = false;
            this.txtPwd.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.txtPwd.Location = new System.Drawing.Point(123, 80);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtPwd.PasswordChar = '●';
            this.txtPwd.Size = new System.Drawing.Size(163, 20);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(29, 54);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonLabel2.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel2.TabIndex = 14;
            this.kryptonLabel2.Values.Text = "Kullanıcı Adı";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(61, 80);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonLabel3.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel3.TabIndex = 15;
            this.kryptonLabel3.Values.Text = "Parola";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(162, 149);
            this.label4.Name = "label4";
            this.label4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.label4.Size = new System.Drawing.Size(6, 2);
            this.label4.TabIndex = 16;
            this.label4.Values.Text = "";
            // 
            // GIRIS
            // 
            this.AcceptButton = this.kryptonButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(353, 197);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GIRIS";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GİRİŞ";
            this.Load += new System.EventHandler(this.GIRIS_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel connectionFalse;
        private System.Windows.Forms.ToolStripStatusLabel connectionTrue;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUser;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPwd;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
    }
}