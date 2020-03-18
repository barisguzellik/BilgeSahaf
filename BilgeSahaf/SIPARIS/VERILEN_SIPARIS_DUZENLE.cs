using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.SIPARIS
{
    public partial class VERILEN_SIPARIS_DUZENLE : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string ITEM_ID = "0";
        public VERILEN_SIPARIS_DUZENLE()
        {
            InitializeComponent();
        }
        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void ALINAN_SIPARIS_DUZENLE_Load(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM VERILEN_SIPARISLER_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    txtCariID.Text = row["CARI"].ToString();
                    txtAciklama.Text = row["ACIKLAMA"].ToString();
                    txtEkAciklama.Text = row["EK_ACIKLAMA"].ToString();
                    txtIlgili.Text = row["AD"].ToString();
                    txtTarih.Text = row["TARIH"].ToString();
                    txtTelefon.Text = row["TELEFON"].ToString();

                    DataTable dtProduct = helper.getDataTable("SELECT*FROM VERILEN_SIPARIS_URUNLER WHERE SIPARIS_ID=" + ITEM_ID + "");
                    int rowsCount = 1;
                    dataGridView1.Rows.Clear();
                    foreach (DataRow rowChild in dtProduct.Rows)
                    {
                        DataGridViewRow insertRow = new DataGridViewRow();
                        insertRow.CreateCells(dataGridView1);
                        insertRow.Cells[0].Value = rowChild["STOK_ID"].ToString();
                        insertRow.Cells[2].Value = rowChild["MIKTAR"].ToString();
                        insertRow.Cells[3].Value = rowChild["DURUM"].ToString();
                        insertRow.Cells[4].Value = rowChild["BEKLEME_NEDENI"].ToString();
                        insertRow.Cells[5].Value = rowChild["TEDARIKCI"].ToString();
                        insertRow.Cells[6].Value = rowChild["TEDARIK_SURESI"].ToString();
                        dataGridView1.Rows.Add(insertRow);
                        rowsCount++;
                    }

                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SIPARIS.STOK_SEC frm = new SIPARIS.STOK_SEC();
                frm.ShowDialog();
                dataGridView1.SelectedCells[0].Value = frm.lastSelectedProduct.ToString();

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (val.ToString() != string.Empty)
                    {
                        DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM STOK_KARTI_V2 WHERE ID=" + val.ToString() + "");
                        if (dt.Rows.Count > 0)
                        {
                            var stokAdi = dt.Rows[0]["STOK_ADI"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = stokAdi.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["MIKTAR"].Value = "1";
                            dataGridView1.Rows[e.RowIndex].Cells["DURUM"].Value = "Hazırlanıyor";
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCariID.Text = frm.lastSelectedUser.ToString();
        }

        private void txtCariID_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtIlgili.Text = dt.Rows[0]["YETKILI_KISI"].ToString();
                txtTelefon.Text = dt.Rows[0]["TELEFON"].ToString();

            }
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sİPARİŞİSİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM VERILEN_SIPARISLER_V2 WHERE ID=" + ITEM_ID + "");
                this.Close();
            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;
            string[] col =
            {
                "TARIH",
                "CARI",
                "ACIKLAMA",
                "AD",
                "TELEFON",
                "EK_ACIKLAMA",
                "EKLENME_TARIHI"
            };

            string[] val =
            {
                dateFormat,
                txtCariID.Text,
                txtAciklama.Text,
                txtIlgili.Text,
                txtTelefon.Text,
                txtEkAciklama.Text,
                DateTime.Now.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("VERILEN_SIPARISLER_V2", col, val, "ID", ITEM_ID);
                string lastID = ITEM_ID;

                helper.setSqlCommand("DELETE FROM VERILEN_SIPARIS_URUNLER WHERE SIPARIS_ID=" + ITEM_ID + "");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[2].Value != null)
                    {
                        string[] childCol ={
                            "SIPARIS_ID",
                            "STOK_ID",
                            "MIKTAR",
                            "DURUM",
                            "BEKLEME_NEDENI",
                            "TEDARIKCI",
                            "TEDARIK_SURESI"
                        };
                        string[] childVal ={
                            lastID,
                            row.Cells[0].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells["DURUM"].Value.ToString(),
                            row.Cells["BEKLEME_NEDENI"].Value.ToString(),
                            row.Cells["TEDARIKCI"].Value.ToString(),
                            row.Cells["TEDARIK_SURESI"].Value.ToString()
                        };
                        helper.setSqlCommandForInsertWithParameters("VERILEN_SIPARIS_URUNLER", childCol, childVal);

                    }
                }


                MessageBox.Show("Sipariş kaydedildi...", "Sipariş");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Sipariş");
            }

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                var val = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                if (val.ToString() != string.Empty)
                {
                    DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM STOK_KARTI_V2 WHERE ID=" + val.ToString() + "");
                    if (dt.Rows.Count > 0)
                    {
                        var stokAdi = dt.Rows[0]["STOK_ADI"].ToString();
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = stokAdi.ToString();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
