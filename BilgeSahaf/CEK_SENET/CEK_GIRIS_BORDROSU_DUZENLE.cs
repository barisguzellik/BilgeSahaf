using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.CEK_SENET
{
    public partial class CEK_GIRIS_BORDROSU_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public CEK_GIRIS_BORDROSU_DUZENLE()
        {
            InitializeComponent();
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCari.Text = frm.lastSelectedUser.ToString();
        }


        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCari.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtCariUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }
        }

        DefaultStyles style = new DefaultStyles();
        CommonClass commonClass = new CommonClass();

        public int ITEM_ID = 0;

        private void CEK_GIRIS_BORDROSU_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM CEK_GIRIS_BORDROSU_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                txtBelgeNo.Text = dt.Rows[0]["BELGE_NUMARASI"].ToString();
                txtCari.Text= dt.Rows[0]["CARI"].ToString();
                txtEvrakNo.Text= dt.Rows[0]["EVRAK_NUMARASI"].ToString();
                dateTimePicker1.Text= dt.Rows[0]["TARIH"].ToString();
                dateTimePicker2.Text= dt.Rows[0]["BELGE_TARIHI"].ToString();

                DataTable dt2 = helper.getDataTable("SELECT*FROM CEK_GIRIS_BORDROSU_DETAYLAR WHERE CEK_GIRIS_ID=" + ITEM_ID + "");
                int rowsCount = 1;
                dataGridView1.Rows.Clear();
                foreach (DataRow rowChild in dt2.Rows)
                {
                    DataGridViewRow insertRow = new DataGridViewRow();
                    insertRow.CreateCells(dataGridView1);
                    insertRow.Cells[0].Value = rowChild["REFERANS"].ToString();
                    insertRow.Cells[1].Value = rowChild["VADE"].ToString();
                    insertRow.Cells[2].Value = rowChild["MEBLAG"].ToString();
                    insertRow.Cells[3].Value = rowChild["ACIKLAMA"].ToString();
                    dataGridView1.Rows.Add(insertRow);
                    rowsCount++;
                }
            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtTime = Convert.ToDateTime(dateTimePicker1.Text);
                string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;

                DateTime dtTime2 = Convert.ToDateTime(dateTimePicker2.Text);
                string dateFormat2 = dtTime2.Year + "-" + dtTime2.Month + "-" + dtTime2.Day;

                string[] col =
                {
                    "EVRAK_NUMARASI",
                    "BELGE_NUMARASI",
                    "CARI",
                    "TARIH",
                    "BELGE_TARIHI",
                    "EKLENME_TARIHI",
                    "ARA_TOPLAM",
                    "MASRAF",
                    "TOPLAM"
                };

                string[] val =
                {
                    txtEvrakNo.Text,
                    txtBelgeNo.Text,
                    txtCari.Text,
                    dateFormat,
                    dateFormat2,
                    DateTime.Now.ToString(),
                    txtAraToplam.Text.Replace(",","."),
                    txtMasraf.Text.Replace(",","."),
                    txtToplam.Text.Replace(",",".")
                };


                helper.setSqlCommandForUpdateWithParameters("CEK_GIRIS_BORDROSU_V2", col, val, "ID", ITEM_ID.ToString());
                string lastID = ITEM_ID.ToString();
                helper.setSqlCommand("DELETE FROM CEK_GIRIS_BORDROSU_DETAYLAR WHERE CEK_GIRIS_ID=" + ITEM_ID + "");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[2].Value != null)
                    {
                        string[] col2 =
                        {
                            "CEK_GIRIS_ID",
                            "CINSI",
                            "REFERANS",
                            "VADE",
                            "MEBLAG",
                            "ACIKLAMA"
                        };
                        string[] val2 =
                        {
                            lastID,
                            "Müşteri Çeki",
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                        };
                        helper.setSqlCommandForInsertWithParameters("CEK_GIRIS_BORDROSU_DETAYLAR", col2, val2);

                    }
                }

                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Çek Senet");
            }
        }

        public void calculateTotals()
        {
            double varToplam = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    var meblag = double.Parse(row.Cells[2].Value.ToString());
                    varToplam += meblag;
                }
            }
            txtToplam.Text = varToplam.ToString();
            txtAraToplam.Text = varToplam.ToString();
        }

        private void dataGridView1_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calculateTotals();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                calculateTotals();
            }
        }

        private void bELGEYİSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.setSqlCommand("DELETE FROM CEK_GIRIS_BORDROSU_V2 WHERE ID=" + ITEM_ID + "");
            helper.setSqlCommand("DELETE FROM CEK_GIRIS_BORDROSU_DETAYLAR WHERE CEK_GIRIS_ID=" + ITEM_ID + "");
            this.Close();
        }

    
    }
}
