using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgeSahaf
{
    class CommonClass
    {
        public void openFormOnMdi(Form frm, Form mdi)
        {
            frm.MdiParent = mdi;
            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            frm.Show();
        }
        public void openInTabs(Form frm)
        {

            frm.WindowState = FormWindowState.Maximized;
            frm.ControlBox = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
        public void openFormOnForm(Form frm)
        {
            frm.BringToFront();
            frm.ShowDialog();
        }
        public bool checkOpened(Form name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == name.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void closeForm(string name)
        {
            FormCollection fc = Application.OpenForms;

            try
            {
                foreach (Form frm in fc)
                {
                    if (frm.Name == name)
                    {
                        frm.Close();

                    }
                }
            }
            catch { }
        }

        public void closeAllForm()
        {
            FormCollection fc = Application.OpenForms;

            try
            {
                foreach (Form frm in fc)
                {
                    if (frm.Name != "MDI_FORM" && frm.Name!="GIRIS")
                    {
                        frm.Close();
                    }
                    

                }
            }
            catch { }
        }

        public int getCalculateGiris(int id)
        {
            int count = 0;
            DataTable dt = helper.getDataTable("SELECT SUM(MIKTAR) FROM STOK_GIRIS_URUNLER WHERE URUN_ID=" + id + "");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(MIKTAR) FROM ALIS_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt2.Rows[0][0].ToString());
                }
            }

            DataTable dt3 = helper.getDataTable("SELECT SUM(MIKTAR) FROM SATIS_IADE_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() != "" && dt3.Rows[0][0].ToString() != string.Empty && dt3.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt3.Rows[0][0].ToString());
                }
            }



            return count;

        }

        carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();

        public int getCalculateCikis(int id)
        {
            int count = 0;
            DataTable dt = helper.getDataTable("SELECT SUM(MIKTAR) FROM STOK_CIKIS_URUNLER WHERE URUN_ID=" + id + "");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(MIKTAR) FROM SATIS_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt2.Rows[0][0].ToString());
                }
            }

            DataTable dt3 = helper.getDataTable("SELECT SUM(MIKTAR) FROM ALIS_IADE_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() != "" && dt3.Rows[0][0].ToString() != string.Empty && dt3.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt3.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public double getMaliyet(int id)
        {
            double count = 0;

            DataTable dt = helper.getDataTable("SELECT SUM(TOPLAM) FROM ALIS_FATURA_URUNLER WHERE URUN_ID=" + id + "");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(TOPLAM) FROM ALIS_IADE_FATURA_URUNLER WHERE URUN_ID=" + id + "");

            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count -= double.Parse(dt2.Rows[0][0].ToString());
                }
            }


            return count;
        }
        public int getCalculateMaliyetGiris(int id)
        {
            int count = 0;

            DataTable dt2 = helper.getDataTable("SELECT SUM(MIKTAR) FROM ALIS_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt2.Rows[0][0].ToString());
                }
            }

            DataTable dt3 = helper.getDataTable("SELECT SUM(MIKTAR) FROM ALIS_IADE_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() != "" && dt3.Rows[0][0].ToString() != string.Empty && dt3.Rows[0][0].ToString() != null)
                {
                    count -= int.Parse(dt3.Rows[0][0].ToString());
                }
            }

            return count;

        }
        public double getSatisKazanc(int id)
        {
            double count = 0;

            DataTable dt = helper.getDataTable("SELECT SUM(TOPLAM) FROM SATIS_FATURA_URUNLER WHERE URUN_ID=" + id + "");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(TOPLAM) FROM SATIS_IADE_FATURA_URUNLER WHERE URUN_ID=" + id + "");

            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count -= double.Parse(dt2.Rows[0][0].ToString());
                }
            }


            return count;
        }
        public int getCalculateMaliyetCikis(int id)
        {
            int count = 0;

            DataTable dt2 = helper.getDataTable("SELECT SUM(MIKTAR) FROM SATIS_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += int.Parse(dt2.Rows[0][0].ToString());
                }
            }

            DataTable dt3 = helper.getDataTable("SELECT SUM(MIKTAR) FROM SATIS_IADE_FATURA_URUNLER WHERE URUN_ID=" + id + "");
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() != "" && dt3.Rows[0][0].ToString() != string.Empty && dt3.Rows[0][0].ToString() != null)
                {
                    count -= int.Parse(dt3.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public double getCariBorc(int id)
        {
            double count = 0;

            DataTable dt = helper.getDataTable("SELECT SUM(ODEMELER_V2.TUTAR) FROM ODEMELER_V2 WHERE CARI="+id+"");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt6 = helper.getDataTable("SELECT SUM(GONDERILEN_HAVALE_V2.TUTAR) FROM GONDERILEN_HAVALE_V2 WHERE CARI=" + id + "");
            if (dt6.Rows.Count > 0)
            {
                if (dt6.Rows[0][0].ToString() != "" && dt6.Rows[0][0].ToString() != string.Empty && dt6.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt6.Rows[0][0].ToString());
                }
            }


            DataTable dt2 = helper.getDataTable("SELECT SUM(GENEL_TOPLAM) FROM SATIS_FATURALARI_V2 WHERE CARI=" + id + "");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt2.Rows[0][0].ToString());
                }
            }

            DataTable dt5 = helper.getDataTable("SELECT SUM(GENEL_TOPLAM) FROM ALIS_IADE_FATURALARI_V2 WHERE CARI=" + id + "");
            if (dt5.Rows.Count > 0)
            {
                if (dt5.Rows[0][0].ToString() != "" && dt5.Rows[0][0].ToString() != string.Empty && dt5.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt5.Rows[0][0].ToString());
                }
            }

            DataTable dt3 = helper.getDataTable("SELECT SUM(TOPLAM) FROM CEK_CIKIS_BORDROSU_V2 WHERE CARI=" + id + "");
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() != "" && dt3.Rows[0][0].ToString() != string.Empty && dt3.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt3.Rows[0][0].ToString());
                }
            }

            DataTable dt4 = helper.getDataTable("SELECT SUM(TOPLAM) FROM SENET_CIKIS_BORDROSU_V2 WHERE CARI=" + id + "");
            if (dt4.Rows.Count > 0)
            {
                if (dt4.Rows[0][0].ToString() != "" && dt4.Rows[0][0].ToString() != string.Empty && dt4.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt4.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public double getCariAlacak(int id)
        {
            double count = 0;

            DataTable dt = helper.getDataTable("SELECT SUM(TAHSILATLAR_V2.TUTAR) FROM TAHSILATLAR_V2 WHERE CARI=" + id + "");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            

            DataTable dt2 = helper.getDataTable("SELECT SUM(GENEL_TOPLAM) FROM ALIS_FATURALARI_V2 WHERE CARI=" + id + "");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt2.Rows[0][0].ToString());
                }
            }

            DataTable dt8 = helper.getDataTable("SELECT SUM(GENEL_TOPLAM) FROM SATIS_IADE_FATURALARI_V2 WHERE CARI=" + id + "");
            if (dt8.Rows.Count > 0)
            {
                if (dt8.Rows[0][0].ToString() != "" && dt8.Rows[0][0].ToString() != string.Empty && dt8.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt8.Rows[0][0].ToString());
                }
            }

            DataTable dt3 = helper.getDataTable("SELECT SUM(BANKA_GIRISLER_V2.TUTAR) FROM CARI_KARTLAR_V2 INNER JOIN SATIS_FATURALARI_V2 ON CARI_KARTLAR_V2.ID=SATIS_FATURALARI_V2.CARI INNER JOIN BANKA_GIRISLER_V2 ON SATIS_FATURALARI_V2.ID=BANKA_GIRISLER_V2.FATURA_ID WHERE CARI_KARTLAR_V2.ID="+id+"");
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() != "" && dt3.Rows[0][0].ToString() != string.Empty && dt3.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt3.Rows[0][0].ToString());
                }
            }

            DataTable dt4 = helper.getDataTable("SELECT SUM(GELEN_HAVALE_V2.TUTAR) FROM GELEN_HAVALE_V2 WHERE CARI=" + id + "");
            if (dt4.Rows.Count > 0)
            {
                if (dt4.Rows[0][0].ToString() != "" && dt4.Rows[0][0].ToString() != string.Empty && dt4.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt4.Rows[0][0].ToString());
                }
            }

            DataTable dt5 = helper.getDataTable("SELECT SUM(TOPLAM) FROM CEK_GIRIS_BORDROSU_V2 WHERE CARI=" + id + "");
            if (dt5.Rows.Count > 0)
            {
                if (dt5.Rows[0][0].ToString() != "" && dt5.Rows[0][0].ToString() != string.Empty && dt5.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt5.Rows[0][0].ToString());
                }
            }

            DataTable dt6 = helper.getDataTable("SELECT SUM(TOPLAM) FROM SENET_GIRIS_BORDROSU_V2 WHERE CARI=" + id + "");
            if (dt6.Rows.Count > 0)
            {
                if (dt6.Rows[0][0].ToString() != "" && dt6.Rows[0][0].ToString() != string.Empty && dt6.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt6.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public double getSatisFaturalariTotal(string date1,string date2)
        {
            double count = 0;

            DataTable dt = helper.getDataTable("SELECT SUM(KDV_TOPLAM) FROM SATIS_FATURALARI_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(KDV_TOPLAM) FROM SATIS_IADE_FATURALARI_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");

            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count -= double.Parse(dt2.Rows[0][0].ToString());
                }
            }


            return count;
        }

        public double getAlisFaturalariTotal(string date1, string date2)
        {
            double count = 0;

            DataTable dt = helper.getDataTable("SELECT SUM(KDV_TOPLAM) FROM ALIS_FATURALARI_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(KDV_TOPLAM) FROM ALIS_IADE_FATURALARI_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");

            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count -= double.Parse(dt2.Rows[0][0].ToString());
                }
            }


            return count;
        }

        public double getCalculateKasaGiris(string date1,string date2)
        {
            double count = 0;
            DataTable dt = helper.getDataTable("SELECT SUM(TUTAR) FROM TAHSILATLAR_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            
            DataTable dt2 = helper.getDataTable("SELECT SUM(TUTAR) FROM GELIRLER_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt2.Rows[0][0].ToString());
                }
            }
            

            return count;

        }

        public double getCalculateKasaCikis(string date1, string date2)
        {
            double count = 0;
            DataTable dt = helper.getDataTable("SELECT SUM(TUTAR) FROM ODEMELER_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(TUTAR) FROM GIDERLER_V2 WHERE TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt2.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public double getCalculateBankaGiris(int banka,string date1, string date2)
        {
            double count = 0;
            DataTable dt = helper.getDataTable("SELECT SUM(TUTAR) FROM BANKA_GIRISLER_V2 WHERE BANKA="+banka+" AND TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(TUTAR) FROM GELEN_HAVALE_V2 WHERE BANKA=" + banka + " AND TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt2.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public double getCalculateBankaCikis(int banka,string date1, string date2)
        {
            double count = 0;
            DataTable dt = helper.getDataTable("SELECT SUM(TUTAR) FROM BANKA_CIKISLAR_V2 WHERE BANKA=" + banka + " AND TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt.Rows[0][0].ToString());
                }
            }

            DataTable dt2 = helper.getDataTable("SELECT SUM(TUTAR) FROM GONDERILEN_HAVALE_V2 WHERE BANKA=" + banka + " AND TARIH BETWEEN CONVERT(datetime, '" + date1 + "') AND CONVERT(datetime, '" + date2 + "')");
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0][0].ToString() != "" && dt2.Rows[0][0].ToString() != string.Empty && dt2.Rows[0][0].ToString() != null)
                {
                    count += double.Parse(dt2.Rows[0][0].ToString());
                }
            }

            return count;

        }

        public string getSonAlisFiyati(int id)
        {
            string ret = "0";
            DataTable dt = helper.getDataTable("SELECT TOP 1 BIRIM_FIYAT FROM ALIS_FATURA_URUNLER WHERE URUN_ID=" + id+" ORDER BY ID DESC");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != string.Empty && dt.Rows[0][0].ToString() != null)
                {
                    ret = dt.Rows[0][0].ToString();
                }
            }

            return ret;
        }

    }
}
