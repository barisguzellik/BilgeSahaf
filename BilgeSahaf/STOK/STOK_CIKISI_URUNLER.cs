using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
{
    public partial class STOK_CIKISI_URUNLER : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public STOK_CIKISI_URUNLER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SIPARIS.CARI_SEC frm = new SIPARIS.CARI_SEC();
            frm.ShowDialog();
            txtCariID.Text = frm.lastSelectedUser.ToString();
        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        private void txtCariID_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = helper.getDataTable("SELECT TOP 1 *FROM CARI_KARTLAR_V2 WHERE ID=" + txtCariID.Text.ToString() + "");
            if (dt.Rows.Count > 0)
            {
                txtUnvani.Text = dt.Rows[0]["UNVANI"].ToString();
            }
        }

        private void kAPATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

                            dataGridView1.Rows[e.RowIndex].Cells[1].Value = stokAdi.ToString();

                        }
                    }
                }
                catch
                {

                }


            }

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SIPARIS.STOK_SEC frm = new SIPARIS.STOK_SEC();
                frm.ShowDialog();
                //dataGridView1.SelectedCells[0].Value = frm.lastSelectedProduct.ToString();

                DataGridViewRow dtRow = new DataGridViewRow();
                dtRow.CreateCells(dataGridView1);
                dtRow.Cells[0].Value = frm.lastSelectedProduct.ToString();
                dataGridView1.Rows.Add(dtRow);
            }
        }

        public bool firstProductLoad = false;
        public void getDepo()
        {
            txtDepo.DataSource = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2");
            txtDepo.DisplayMember = "DEPO_ADI";
            txtDepo.ValueMember = "ID";
        }
        private void YENI_SATIS_FATURASI_Load(object sender, EventArgs e)
        {
            getDepo();

            DataTable dt = helper.getDataTable("SELECT*FROM STOK_CIKISLARI_V2 WHERE ID=" + ITEM_ID + "");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    txtCariID.Text = row["CARI"].ToString();
                    txtTarih.Text = row["TARIH"].ToString();
                    txtUnvani.Text = row["CARI_UNVANI"].ToString();
                    txtBelgeNo.Text = row["BELGE_NUMARASI"].ToString();

                    try
                    {
                        txtDepo.SelectedValue = row["DEPO"].ToString();
                    }
                    catch { }

                    DataTable dtProduct = helper.getDataTable("SELECT*FROM STOK_CIKIS_URUNLER WHERE STOK_CIKIS_ID=" + ITEM_ID + "");
                    int rowsCount = 1;
                    dataGridView1.Rows.Clear();
                    foreach (DataRow rowChild in dtProduct.Rows)
                    {
                        DataGridViewRow insertRow = new DataGridViewRow();
                        insertRow.CreateCells(dataGridView1);
                        insertRow.Cells[0].Value = rowChild["URUN_ID"].ToString();
                        insertRow.Cells[2].Value = rowChild["MIKTAR"].ToString();
                        dataGridView1.Rows.Add(insertRow);
                        rowsCount++;
                    }
                    firstProductLoad = true;

                }
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

                        if (firstProductLoad)
                        {
                        }
                        
                    }
                }
            }
            catch
            {

            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dtTime = Convert.ToDateTime(txtTarih.Text);
            string dateFormat = dtTime.Year + "-" + dtTime.Month + "-" + dtTime.Day;
            string[] col =
            {
                "TARIH",
                "EKLENME_TARIHI",
                "CARI",
                "CARI_UNVANI",
                "BELGE_NUMARASI",
                "DEPO"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtCariID.Text,
                txtUnvani.Text,
                txtBelgeNo.Text,
                txtDepo.SelectedValue.ToString()
            };

            try
            {
                helper.setSqlCommandForUpdateWithParameters("STOK_CIKISLARI_V2", col, val, "ID", ITEM_ID.ToString());

                helper.setSqlCommand("DELETE FROM STOK_CIKIS_URUNLER WHERE STOK_CIKIS_ID=" + ITEM_ID + "");
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string[] childCol ={
                            "STOK_CIKIS_ID",
                            "URUN_ID",
                            "MIKTAR"
                        };
                        string[] childVal ={
                            ITEM_ID.ToString(),
                            row.Cells[0].Value.ToString(),
                            row.Cells[2].Value.ToString()
                        };
                        helper.setSqlCommandForInsertWithParameters("STOK_CIKIS_URUNLER", childCol, childVal);

                    }
                }


                MessageBox.Show("Fiş kaydedildi...", "Fiş");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Fiş");
            }

        }

        public int ITEM_ID = 0;
        private void fATURAYISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("Belge silinecek onaylıyor musunuz?", "Belge Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                helper.setSqlCommand("DELETE FROM STOK_CIKISLARI_V2 WHERE ID=" + ITEM_ID + "");
                helper.setSqlCommand("DELETE FROM STOK_CIKIS_URUNLER WHERE STOK_CIKIS_ID=" + ITEM_ID + "");
                this.Close();
            }
        }
    }
}
