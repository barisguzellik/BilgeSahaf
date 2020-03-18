using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf.FATURA
{
    public partial class YENI_SATIS_FATURASI : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_SATIS_FATURASI()
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
                            var fiyat_1 = dt.Rows[0]["FIYAT_1"].ToString();


                            dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                            dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = "";
                            dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value = fiyat_1;
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = "0,00";
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";

                            var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                            var kdv = 0;
                            dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value = kdv;
                            var kdv_toplam = (double.Parse(fiyat_1) * kdv) / 100;

                            var toplam = double.Parse(fiyat_1) + kdv_toplam;
                            dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;

                            var yayinevi = dt.Rows[0]["YAYINEVI"].ToString().Trim();

                            DataTable isIskonto = helper.getDataTable("SELECT TOP 1 ISKONTO_ORANI FROM YAYINEVI_ISKONTO WHERE YAYINEVI='" + yayinevi + "' ORDER BY ID DESC");
                            if (isIskonto.Rows.Count > 0)
                            {
                                var iskonto_orani = isIskonto.Rows[0][0].ToString();
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = iskonto_orani;
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";
                            }
                        }
                    }
                }
                catch
                {

                }


            }

            if (e.ColumnIndex == 1)
            {
                try
                {
                    var val = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (val.ToString() != string.Empty)
                    {

                        DataTable dt = helper.getDataTable("SELECT TOP 1 ID FROM STOK_KARTI_V2 WHERE BARKOD_1='" + val + "' OR BARKOD_2='" + val + "' OR BARKOD_3='" + val + "' ");

                        if (dt.Rows.Count == 1)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["URUN_ID"].Value = dt.Rows[0]["ID"].ToString();
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            DataTable dtBarkod = helper.getDataTable("SELECT TOP 1 STOK_KARTI_V2.ID FROM STOK_KARTI_V2 INNER JOIN STOK_BARKODLARI ON STOK_KARTI_V2.ID=STOK_BARKODLARI.STOK_ID WHERE STOK_BARKODLARI.BARKOD='" + val + "'");
                            if (dtBarkod.Rows.Count == 1)
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["URUN_ID"].Value = dtBarkod.Rows[0]["ID"].ToString();
                            }
                        }

                    }
                }
                catch
                {

                }
            }

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                try
                {
                    var adet = dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value.ToString();
                    var fiyat = dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value.ToString();
                    var kdv = dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value.ToString();
                    var iskonto = dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value.ToString();
                    var iskonto_oran = dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value.ToString();
                    double iskontolu_fiyat = 0;

                    if (iskonto_oran == "0")
                    {
                        iskontolu_fiyat = double.Parse(fiyat) - double.Parse(iskonto);
                    }
                    else
                    {
                        double iskontolubirim = (double.Parse(fiyat) * double.Parse(iskonto_oran)) / 100;
                        iskontolu_fiyat = double.Parse(fiyat) - iskontolubirim;
                        dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = iskontolubirim.ToString();
                    }


                    double tutar = (iskontolu_fiyat) * double.Parse(adet);
                    var kdv_toplam = (tutar * double.Parse(kdv)) / 100;
                    double toplam = ((iskontolu_fiyat) * double.Parse(adet)) + kdv_toplam;
                    dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;

                    calculateTotals();
                }
                catch
                {

                }
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

        public void getDepo()
        {
            txtDepo.DataSource = helper.getDataTable("SELECT*FROM DEPO_KARTLARI_V2");
            txtDepo.DisplayMember = "DEPO_ADI";
            txtDepo.ValueMember = "ID";
        }
        private void YENI_SATIS_FATURASI_Load(object sender, EventArgs e)
        {
            getDepo();
        }

        public void calculateTotals()
        {
            double varToplam = 0;
            double varGenelToplam = 0;
            double varIskonto = 0;
            double kdvToplam = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ADET"].Value != null && row.Cells["BIRIM_FIYAT"].Value != null)
                {
                    var birimFiyat = double.Parse(row.Cells["BIRIM_FIYAT"].Value.ToString());
                    var adet = double.Parse(row.Cells["ADET"].Value.ToString());
                    var iskonto = double.Parse(row.Cells["ISKONTO"].Value.ToString());
                    double insertToplam = (birimFiyat) * adet;
                    varToplam += insertToplam;
                }
                if (row.Cells["ISKONTO"].Value != null)
                {
                    double kalem_adet = double.Parse(row.Cells["ADET"].Value.ToString());
                    double kalem_iskonto = double.Parse(row.Cells["ISKONTO"].Value.ToString());
                    var ekle_iskonto = kalem_adet * kalem_iskonto;
                    varIskonto += ekle_iskonto;
                }
                if (row.Cells["TOPLAM"].Value != null)
                {
                    varGenelToplam += double.Parse(row.Cells["TOPLAM"].Value.ToString());
                }
                if (row.Cells["KDV"].Value != null)
                {
                    var kdv = double.Parse(row.Cells["KDV"].Value.ToString());
                    var birimFiyat = double.Parse(row.Cells["BIRIM_FIYAT"].Value.ToString());
                    var iskonto = double.Parse(row.Cells["ISKONTO"].Value.ToString());
                    var adet = double.Parse(row.Cells["ADET"].Value.ToString());
                    double ekle_kdv = (((birimFiyat - iskonto) * adet) * kdv) / 100;
                    kdvToplam += ekle_kdv;
                }
            }
            txtToplam.Text = varToplam.ToString("N");
            txtGenelToplam.Text = varGenelToplam.ToString("N");
            txtIskonto.Text = varIskonto.ToString("N");

            txtKdv.Text = kdvToplam.ToString("N");
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
                        var fiyat_1 = dt.Rows[0]["FIYAT_1"].ToString();

                        dataGridView1.Rows[e.RowIndex].Cells["STOK_ADI"].Value = stokAdi.ToString();

                        if (!boolAktar)
                        {

                            dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = "";
                            dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                            dataGridView1.Rows[e.RowIndex].Cells["BIRIM_FIYAT"].Value = fiyat_1;
                            dataGridView1.Rows[e.RowIndex].Cells["ISKONTO"].Value = "0,00";

                            var barkod_1 = dt.Rows[0]["BARKOD_1"].ToString();
                            dataGridView1.Rows[e.RowIndex].Cells["BARKOD"].Value = barkod_1;

                            var kdv = 0;
                            dataGridView1.Rows[e.RowIndex].Cells["KDV"].Value = kdv;
                            var kdv_toplam = (double.Parse(fiyat_1) * kdv) / 100;

                            var toplam = double.Parse(fiyat_1) + kdv_toplam;
                            dataGridView1.Rows[e.RowIndex].Cells["TOPLAM"].Value = toplam;

                            var yayinevi = dt.Rows[0]["YAYINEVI"].ToString().Trim();

                            DataTable isIskonto = helper.getDataTable("SELECT TOP 1 ISKONTO_ORANI FROM YAYINEVI_ISKONTO WHERE YAYINEVI='" + yayinevi + "' ORDER BY ID DESC");
                            if (isIskonto.Rows.Count > 0)
                            {
                                var iskonto_orani = isIskonto.Rows[0][0].ToString();
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = iskonto_orani;
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["ISKONTO_ORAN"].Value = "0";
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            calculateTotals();
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
                "TOPLAM",
                "ISKONTO_TOPLAM",
                "KDV_TOPLAM",
                "GENEL_TOPLAM",
                "BELGE_NUMARASI",
                "FATURA_NUMARASI",
                "SATIS_ELEMANI",
                "DEPO",
                "ACIKLAMA"
            };

            string[] val =
            {
                dateFormat,
                DateTime.Now.ToString(),
                txtCariID.Text,
                txtUnvani.Text,
                txtToplam.Text.Replace(".","").Replace(",","."),
                txtIskonto.Text.Replace(".","").Replace(",","."),
                txtKdv.Text.Replace(".","").Replace(",","."),
                txtGenelToplam.Text.Replace(".","").Replace(",","."),
                txtBelgeNo.Text,
                txtFaturaNo.Text,
                txtSatisElemani.Text,
                txtDepo.SelectedValue.ToString(),
                txtBelgeNotu.Text
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("SATIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM SATIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string[] childCol ={
                            "SATIS_FATURA_ID",
                            "URUN_ID",
                            "MIKTAR",
                            "BIRIM_FIYAT",
                            "KDV_ORANI",
                            "TOPLAM",
                            "ISKONTO",
                            "ISKONTO_ORAN",
                            "ACIKLAMA"
                        };
                        string[] childVal ={
                           lastID,
                            row.Cells["URUN_ID"].Value.ToString(),
                            row.Cells["ADET"].Value.ToString(),
                            row.Cells["BIRIM_FIYAT"].Value.ToString().Replace(",","."),
                            row.Cells["KDV"].Value.ToString(),
                            row.Cells["TOPLAM"].Value.ToString().Replace(",","."),
                            row.Cells["ISKONTO"].Value.ToString().Replace(",","."),
                            row.Cells["ISKONTO_ORAN"].Value.ToString().Replace(",","."),
                            row.Cells["ACIKLAMA"].Value.ToString()
                        };
                        helper.setSqlCommandForInsertWithParameters("SATIS_FATURA_URUNLER", childCol, childVal);

                    }
                }


                //MessageBox.Show("Fatura kaydedildi...", "Fatura");
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Fatura");
            }

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateTotals();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public bool boolAktar = false;
        private void kİDAALIŞFATURASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            DataTable data = new DataTable();
            try
            {
                String name = "p1";
                String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                file +
                                ";Extended Properties='Excel 8.0;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);

                sda.Fill(data);
            }
            catch
            {

            }


            int rowCount = data.Rows.Count;
            //data.Rows[0].Delete();
            this.Cursor = Cursors.WaitCursor;
            boolAktar = true;
            foreach (DataRow dr in data.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    string productID = getBarkodToID(dr["BARKOD"].ToString().Trim());
                    if (productID != "0")
                    {


                        DataGridViewRow dtRow = new DataGridViewRow();
                        dtRow.CreateCells(dataGridView1);
                        dtRow.Cells[0].Value = productID;
                        DataTable dt = getIDToProduct(productID);

                        dtRow.Cells[1].Value = dr["BARKOD"].ToString().Trim();
                        dtRow.Cells[5].Value = dr["FIYAT"].ToString().Trim();
                        if (dt.Rows.Count > 0)
                        {
                            dtRow.Cells[2].Value = dt.Rows[0]["STOK_ADI"].ToString();
                            dtRow.Cells[3].Value = " ";
                            dtRow.Cells[4].Value = dr["ADET"].ToString().Trim();
                            dtRow.Cells[6].Value = dr["ISKONTO"].ToString().Trim();


                            var adet = dr["ADET"].ToString().Trim();
                            var fiyat = dr["FIYAT"].ToString().Trim();
                            var kdv = dr["KDV"].ToString().Trim();
                            var iskonto_oran = dr["ISKONTO"].ToString().Trim();
                            double iskontolu_fiyat = 0;

                            if (iskonto_oran == "0")
                            {
                                iskontolu_fiyat = Convert.ToDouble(fiyat);
                                dtRow.Cells[7].Value = 0;
                            }
                            else
                            {
                                double iskontolubirim = (double.Parse(fiyat) * double.Parse(iskonto_oran)) / 100;
                                iskontolu_fiyat = double.Parse(fiyat) - iskontolubirim;
                                dtRow.Cells[7].Value = iskontolubirim.ToString();
                            }


                            double tutar = (iskontolu_fiyat) * double.Parse(adet);
                            var kdv_toplam = (tutar * double.Parse(kdv)) / 100;
                            double toplam = ((iskontolu_fiyat) * double.Parse(adet)) + kdv_toplam;

                            dtRow.Cells[8].Value = dr["KDV"].ToString().Trim();
                            dtRow.Cells[9].Value = toplam;

                            dataGridView1.Rows.Add(dtRow);
                        }
                    }
                }

            }
            boolAktar = false;
            this.Cursor = Cursors.Default;
        }

        public string getBarkodToID(string barkod)
        {
            string retID = "0";
            //BARKOD AKTARIMLARI
            var valBarkod = barkod;
            if (valBarkod.ToString() != string.Empty)
            {

                DataTable dt2 = helper.getDataTable("SELECT TOP 1 ID FROM STOK_KARTI_V2 WHERE BARKOD_1='" + valBarkod + "' OR BARKOD_2='" + valBarkod + "' OR BARKOD_3='" + valBarkod + "' ");

                if (dt2.Rows.Count == 1)
                {
                    retID = dt2.Rows[0]["ID"].ToString();
                }
                else if (dt2.Rows.Count == 0)
                {
                    DataTable dtBarkod = helper.getDataTable("SELECT TOP 1 STOK_KARTI_V2.ID FROM STOK_KARTI_V2 INNER JOIN STOK_BARKODLARI ON STOK_KARTI_V2.ID=STOK_BARKODLARI.STOK_ID WHERE STOK_BARKODLARI.BARKOD='" + valBarkod + "'");
                    if (dtBarkod.Rows.Count == 1)
                    {
                        retID = dtBarkod.Rows[0]["ID"].ToString();
                    }
                }

            }

            return retID;
        }

        public string getStokKoduToID(string barkod)
        {
            string retID = "0";
            //BARKOD AKTARIMLARI
            var valBarkod = barkod;
            if (valBarkod.ToString() != string.Empty)
            {

                DataTable dt2 = helper.getDataTable("SELECT TOP 1 ID FROM STOK_KARTI_V2 WHERE STOK_KODU='" + valBarkod + "'");

                if (dt2.Rows.Count == 1)
                {
                    retID = dt2.Rows[0]["ID"].ToString();
                }
            }

            return retID;
        }

        public DataTable getIDToProduct(string id)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM STOK_KARTI_V2 WHERE ID=" + id + "");
            return dt;
        }

        private void eXCELSTOKKODUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            DataTable data = new DataTable();
            try
            {
                String name = "p1";
                String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                file +
                                ";Extended Properties='Excel 8.0;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);

                sda.Fill(data);
            }
            catch
            {

            }


            int rowCount = data.Rows.Count;
            //data.Rows[0].Delete();
            this.Cursor = Cursors.WaitCursor;
            boolAktar = true;
            foreach (DataRow dr in data.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    string productID = getStokKoduToID(dr["STOKKODU"].ToString().Trim());
                    if (productID != "0")
                    {


                        DataGridViewRow dtRow = new DataGridViewRow();
                        dtRow.CreateCells(dataGridView1);
                        dtRow.Cells[0].Value = productID;
                        DataTable dt = getIDToProduct(productID);


                        dtRow.Cells[5].Value = dr["FIYAT"].ToString().Trim();
                        dtRow.Cells[4].Value = dr["ADET"].ToString().Trim();
                        dtRow.Cells[6].Value = dr["ISKONTO"].ToString().Trim();

                        if (dt.Rows.Count > 0)
                        {
                            try
                            {


                                dtRow.Cells[1].Value = dt.Rows[0]["BARKOD_1"].ToString();

                                dtRow.Cells[2].Value = dt.Rows[0]["STOK_ADI"].ToString();
                                dtRow.Cells[3].Value = " ";



                                var adet = dr["ADET"].ToString().Trim();
                                var fiyat = dr["FIYAT"].ToString().Trim();
                                var kdv = dr["KDV"].ToString().Trim();
                                var iskonto_oran = dr["ISKONTO"].ToString().Trim();
                                double iskontolu_fiyat = 0;

                                if (iskonto_oran == "0")
                                {
                                    iskontolu_fiyat = Convert.ToDouble(fiyat);
                                    dtRow.Cells[7].Value = 0;
                                }
                                else
                                {
                                    double iskontolubirim = (double.Parse(fiyat) * double.Parse(iskonto_oran)) / 100;
                                    iskontolu_fiyat = double.Parse(fiyat) - iskontolubirim;
                                    dtRow.Cells[7].Value = iskontolubirim.ToString();
                                }


                                double tutar = (iskontolu_fiyat) * double.Parse(adet);
                                var kdv_toplam = (tutar * double.Parse(kdv)) / 100;
                                double toplam = ((iskontolu_fiyat) * double.Parse(adet)) + kdv_toplam;

                                dtRow.Cells[8].Value = dr["KDV"].ToString().Trim();
                                dtRow.Cells[9].Value = toplam;

                                dataGridView1.Rows.Add(dtRow);
                            }
                            catch { }
                        }
                    }
                }

            }
            boolAktar = false;
            this.Cursor = Cursors.Default;
        }
    }
}
