﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.RAPOR.FATURA
{
    public partial class RAPOR_ALIS_FATURALARI : Form
    {
        public RAPOR_ALIS_FATURALARI()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();
        CommonClass commonClass = new CommonClass();
        DefaultStyles styles = new DefaultStyles();
        private void RAPOR_STOK_KARTLARI_Load(object sender, EventArgs e)
        {
            styles.dataGridStyle(dataGridView1);
            dataGridView1.DataSource = helper.getDataTable("SELECT*FROM ALIS_FATURALARI_V2");
            toolStripStatusLabel1.Text ="Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
        }

        private void sORGUÇALIŞTIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAPOR.RAPOR_SORGU_CALISTIR frm = new RAPOR.RAPOR_SORGU_CALISTIR();
            frm.ShowDialog();
            if(frm.QUERY!=null && frm.QUERY!=string.Empty && frm.QUERY != "")
            {
                try
                {
                    dataGridView1.DataSource = helper.getDataTable(frm.QUERY);
                    toolStripStatusLabel1.Text = "Toplam Kayıt : " + dataGridView1.Rows.Count.ToString();
                }
                catch(Exception x)
                {
                    MessageBox.Show(x.Message,"RAPOR");
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            styles.dataGridFormatNumber(dataGridView1);
        }
    }
}
