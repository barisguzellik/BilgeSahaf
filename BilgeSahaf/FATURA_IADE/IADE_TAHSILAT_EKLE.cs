﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA_IADE
{
    public partial class IADE_TAHSILAT_EKLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public IADE_TAHSILAT_EKLE()
        {
            InitializeComponent();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int FATURA_ID = 0;
        public string TUTAR = "0.00";

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

            string[] col =
            {
                "TARIH",
                "EKLENME_TARIHI",
                "TUTAR",
                "ALIS_FATURA_ID"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtTutar.Text.Replace(",","."),
                FATURA_ID.ToString()
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("IADE_TAHSILATLAR_V2", col, val);
                MessageBox.Show("Tahsilat Eklendi...","Tahsilat");
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Tahsilat");
            }
            

        }

        private void TAHSILAT_EKLE_Load(object sender, EventArgs e)
        {
            txtTutar.Text = TUTAR;
        }
    }
}
