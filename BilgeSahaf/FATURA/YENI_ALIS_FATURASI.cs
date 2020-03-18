using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BilgeSahaf.FATURA
{
    public partial class YENI_ALIS_FATURASI : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public YENI_ALIS_FATURASI()
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
                            dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = " ";
                            dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
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
            double toplamAdet = 0;

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

                if (row.Cells["ADET"].Value != null)
                {
                    toplamAdet += double.Parse(row.Cells["ADET"].Value.ToString());
                }

            }
            txtToplam.Text = varToplam.ToString("N");
            txtGenelToplam.Text = varGenelToplam.ToString("N");
            txtIskonto.Text = varIskonto.ToString("N");

            txtKdv.Text = kdvToplam.ToString("N");
            txtToplamAdet.Text = toplamAdet.ToString();
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

                            dataGridView1.Rows[e.RowIndex].Cells["ADET"].Value = "1";
                            dataGridView1.Rows[e.RowIndex].Cells["ACIKLAMA"].Value = " ";
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
                txtDepo.SelectedValue.ToString(),
                txtBelgeNotu.Text
            };

            try
            {
                helper.setSqlCommandForInsertWithParameters("ALIS_FATURALARI_V2", col, val);
                string lastID = helper.getTableColumnData("SELECT TOP 1 ID FROM ALIS_FATURALARI_V2 ORDER BY ID DESC", "ID");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string[] childCol ={
                            "ALIS_FATURA_ID",
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
                        helper.setSqlCommandForInsertWithParameters("ALIS_FATURA_URUNLER", childCol, childVal);

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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    int iRow = dataGridView1.CurrentCell.RowIndex;

                    if (iColumn == dataGridView1.Columns.Count - 2)
                    {
                        dataGridView1.CurrentCell = dataGridView1[1, iRow + 1];
                    }
                    else
                    {
                        dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
                    }

                    if (iRow == dataGridView1.RowCount)
                    {
                        dataGridView1.Rows.Add();
                    }

                }
            }
            catch { }

            if (e.KeyData == (Keys.Control | Keys.V))
            {
                int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                int iRow = dataGridView1.CurrentCell.RowIndex;
                if (!dataGridView1.Rows[iRow].Cells[iColumn].ReadOnly)
                {

                    dataGridView1.Rows[iRow].Cells[iColumn].Value = Clipboard.GetText();
                    dataGridView1.Rows.Add();
                }

            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[0];
            }
            else
            {
                if (e.ColumnIndex != 1)
                {
                    SendKeys.Send("{UP}");
                    SendKeys.Send("{right}");
                }

            }
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

        public DataTable getIDToProduct(string id)
        {
            DataTable dt = helper.getDataTable("SELECT*FROM STOK_KARTI_V2 WHERE ID=" + id + "");
            return dt;
        }

        private void aKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {


            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            this.Cursor = Cursors.WaitCursor;


            XElement doc = RemoveAllNamespaces(XElement.Load(file));

            txtCariID.Text = "129";

            try
            {
                txtBelgeNotu.Text = doc.Element("ID").Value;
                txtBelgeNo.Text = doc.Element("ID").Value;
                txtTarih.Text = doc.Element("IssueDate").Value;
            }
            catch { }

            /*var fat = from b in doc.Descendants("AdditionalDocumentReference")
                      select new
                      {
                          INVOICE_ID=(string)b.Element("ID").Value,
                          DATE=(string)b.Element("IssueDate").Value
                      };

            

            DataTable dataInvoice = ToDataTable(fat.ToList());
            if (dataInvoice.Rows.Count > 0)
            {
                txtBelgeNotu.Text = dataInvoice.Rows[0]["INVOICE_ID"].ToString();
                txtBelgeNo.Text = dataInvoice.Rows[0]["INVOICE_ID"].ToString();
                txtTarih.Text = dataInvoice.Rows[0]["DATE"].ToString();
            }*/


            var test = from b in doc.Descendants("InvoiceLine")
                       select new
                       {
                           BARCODE = (string)b.Element("Item").Element("SellersItemIdentification").Element("ID").Value,
                           QTY = (double)double.Parse(b.Element("InvoicedQuantity").Value.Replace(".", ",")),
                           PRICE = (double)double.Parse(b.Element("Price").Element("PriceAmount").Value.Replace(".", ",")),
                           //TAX = (string)b.Element("TaxTotal").Element("TaxSubtotal").Element("Percent").Value,
                           TAX = (string)"0",
                           DSC = (double)double.Parse(b.Element("AllowanceCharge").Element("MultiplierFactorNumeric").Value.Replace(".", ",")) * 100
                       };

            DataTable data = ToDataTable(test.ToList());

            int rowCount = data.Rows.Count;
            //data.Rows[0].Delete();

            boolAktar = true;
            foreach (DataRow dr in data.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    string productID = getBarkodToID(dr["BARCODE"].ToString().Trim());
                    DataGridViewRow dtRow = new DataGridViewRow();
                    dtRow.CreateCells(dataGridView1);
                    dtRow.Cells[0].Value = productID;
                    DataTable dt = getIDToProduct(productID);

                    dtRow.Cells[1].Value = dr["BARCODE"].ToString().Trim();
                    dtRow.Cells[5].Value = dr["PRICE"].ToString().Trim();
                    if (dt.Rows.Count > 0)
                    {
                        dtRow.Cells[2].Value = dt.Rows[0]["STOK_ADI"].ToString();
                        dtRow.Cells[3].Value = " ";
                        dtRow.Cells[4].Value = dr["QTY"].ToString().Trim();
                        dtRow.Cells[6].Value = dr["DSC"].ToString().Trim();


                        var adet = dr["QTY"].ToString().Trim();
                        var fiyat = dr["PRICE"].ToString().Trim();
                        var kdv = dr["TAX"].ToString().Trim();
                        var iskonto_oran = dr["DSC"].ToString().Trim();
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

                        dtRow.Cells[8].Value = dr["TAX"].ToString().Trim();
                        dtRow.Cells[9].Value = toplam;

                        dataGridView1.Rows.Add(dtRow);
                    }

                }

            }
            boolAktar = false;
            this.Cursor = Cursors.Default;


        }

        public static XElement RemoveAllNamespaces(XElement e)
        {
            return new XElement(e.Name.LocalName,
              (from n in e.Nodes()
               select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
                  (e.HasAttributes) ?
                    (from a in e.Attributes()
                     where (!a.IsNamespaceDeclaration)
                     select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        public double returnPrefixDiscount(string note)
        {
            double retD = 0;
            try
            {
                string[] vals = note.Split('#');
                string discount = vals.LastOrDefault();
                discount = discount.Replace("ISK:", "");

                retD = double.Parse(discount.Replace(".", ","));
            }
            catch
            {
                retD = 0;
            }

            return retD;


        }

        public double returnPrefixEtiketFiy(string note)
        {
            double retD = 0;
            try
            {
                string[] vals = note.Split('#');
                string price = vals[2];
                price = price.Replace("ET:", "").Replace("!", "");

                retD = double.Parse(price.Replace(".", ","));
            }
            catch
            {
                retD = 0;
            }

            return retD;


        }
        private void eFATXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            this.Cursor = Cursors.WaitCursor;


            XElement doc = RemoveAllNamespaces(XElement.Load(file));

            txtCariID.Text = "385";

            try
            {
                txtBelgeNotu.Text = doc.Element("ID").Value;
                txtBelgeNo.Text = doc.Element("ID").Value;
                txtTarih.Text = doc.Element("IssueDate").Value;
            }
            catch { }

            /*var fat = from b in doc.Descendants("AdditionalDocumentReference")
                      select new
                      {
                          INVOICE_ID = (string)b.Element("ID").Value,
                          DATE = (string)b.Element("IssueDate").Value
                      };

            

            DataTable dataInvoice = ToDataTable(fat.ToList());
            if (dataInvoice.Rows.Count > 0)
            {
                txtBelgeNotu.Text = dataInvoice.Rows[0]["INVOICE_ID"].ToString();
                txtBelgeNo.Text = dataInvoice.Rows[0]["INVOICE_ID"].ToString();
                txtTarih.Text = dataInvoice.Rows[0]["DATE"].ToString();
            }*/


            var test = from b in doc.Descendants("InvoiceLine")
                       select new
                       {
                           BARCODE = (string)b.Element("Item").Element("BuyersItemIdentification").Element("ID").Value,
                           QTY = (double)double.Parse(b.Element("InvoicedQuantity").Value.Replace(".", ",")),
                           PRICE = (double)returnPrefixEtiketFiy(b.Element("Note").Value),
                           //TAX = (string)b.Element("TaxTotal").Element("TaxSubtotal").Element("Percent").Value,
                           TAX = (string)"0",
                           DSC = (double)returnPrefixDiscount(b.Element("Note").Value)
                       };

            DataTable data = ToDataTable(test.ToList());

            int rowCount = data.Rows.Count;
            //data.Rows[0].Delete();

            boolAktar = true;
            foreach (DataRow dr in data.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    string productID = getBarkodToID(dr["BARCODE"].ToString().Trim());
                    DataGridViewRow dtRow = new DataGridViewRow();
                    dtRow.CreateCells(dataGridView1);
                    dtRow.Cells[0].Value = productID;
                    DataTable dt = getIDToProduct(productID);

                    dtRow.Cells[1].Value = dr["BARCODE"].ToString().Trim();
                    dtRow.Cells[5].Value = dr["PRICE"].ToString().Trim();
                    if (dt.Rows.Count > 0)
                    {
                        dtRow.Cells[2].Value = dt.Rows[0]["STOK_ADI"].ToString();
                        dtRow.Cells[3].Value = " ";
                        dtRow.Cells[4].Value = dr["QTY"].ToString().Trim();
                        dtRow.Cells[6].Value = dr["DSC"].ToString().Trim();


                        var adet = dr["QTY"].ToString().Trim();
                        var fiyat = dr["PRICE"].ToString().Trim();
                        var kdv = dr["TAX"].ToString().Trim();
                        var iskonto_oran = dr["DSC"].ToString().Trim();
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

                        dtRow.Cells[8].Value = dr["TAX"].ToString().Trim();
                        dtRow.Cells[9].Value = toplam;

                        dataGridView1.Rows.Add(dtRow);
                    }

                }

            }
            boolAktar = false;
            this.Cursor = Cursors.Default;
        }
    }
}
