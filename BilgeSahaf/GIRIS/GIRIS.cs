using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.Net.NetworkInformation;

namespace BilgeSahaf.GIRIS
{
    public partial class GIRIS :ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public GIRIS()
        {
            InitializeComponent();
        }


        public void generateComboItem()
        {
            var xDoc = XDocument.Load(Application.StartupPath.ToString() + "/configApp.xml");

            /*var subeName = from key in xDoc.Descendants("SUBE_ADI")
                            select key.Value;

            var dbName = from key in xDoc.Descendants("DB_NAME")
                           select key.Value;

            comboBox1.DataSource = subeName.ToList();*/

            var q = from b in xDoc.Descendants("SUBE")
                    select new
                    {
                        TYPE = (string)b.Element("TYPE"),
                        SUBE_ID = (string)b.Element("SUBE_ID"),
                        SUBE_ADI = (string)b.Element("SUBE_ADI"),
                        DB_NAME = (string)b.Element("DB_NAME"),
                        SERVER_IP = (string)b.Element("SERVER_IP"),
                        USER_ID = (string)b.Element("USER_ID"),
                        USER_PWD = (string)b.Element("USER_PWD")
                    };


            comboBox1.DataSource = q.ToList();

            comboBox1.DisplayMember = "SUBE_ADI";
            comboBox1.ValueMember = "SUBE_ID";

        }
        private void GIRIS_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUser;

            generateComboItem();

            //bool networkUp= System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
            _isNetworkOnline = NetworkInterface.GetIsNetworkAvailable();

            if (_isNetworkOnline)
            {
                connectionFalse.Visible = false;
                connectionTrue.Visible = true;
            }
            else
            {
                connectionFalse.Visible = true;
                connectionTrue.Visible = false;
            }


        }
        bool _isNetworkOnline;
        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            _isNetworkOnline = e.IsAvailable;

            if (_isNetworkOnline)
            {
                connectionFalse.Visible = false;
                connectionTrue.Visible = true;
            }
            else
            {
                connectionFalse.Visible = true;
                connectionTrue.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        public void processLogin()
        {
            this.Cursor = Cursors.WaitCursor;

            kryptonButton1.Enabled = false;

            string text = comboBox1.SelectedItem.ToString();

            string store_name = getBetween(text, "SUBE_ADI =", ",").Trim();

            string server_type = getBetween(text, "TYPE =", ",").Trim();
            string server_ip = getBetween(text, "SERVER_IP =", ",").Trim();
            string db_name = getBetween(text, "DB_NAME =", ",").Trim();
            string user_id = getBetween(text, "USER_ID =", ",").Trim();
            string user_pwd = getBetween(text, "USER_PWD =", "*PWD*").Trim();


            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            if (server_type == "REMOTE")
            {
                connectionStringsSection.ConnectionStrings["carkMsSQLHelper"].ConnectionString = @"data source=" + server_ip + ";initial catalog=" + db_name + ";User Id=" + user_id + ";Password=" + user_pwd + ";";
            }
            if (server_type == "LOCAL")
            {
                connectionStringsSection.ConnectionStrings["carkMsSQLHelper"].ConnectionString = @"data source=" + server_ip + ";initial catalog=" + db_name + ";integrated security=True;";
            }
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            carkSQLHelper.carkMsSQLHelper helper = new carkSQLHelper.carkMsSQLHelper();


            string sql = "SELECT*FROM KULLANICILAR WHERE AKTIF=1 AND EPOSTA_ADRESI=@USERNAME AND PAROLA=@PASSWORD";
            string[] param = { "@USERNAME", "@PASSWORD" };
            string[] values = { txtUser.Text, txtPwd.Text };

            DataTable dt = helper.getDataTableWithParameters(sql, param, values);
            if (dt.Rows.Count == 1)
            {
                string user_name = dt.Rows[0]["AD"].ToString();
                string user_last_name = dt.Rows[0]["SOYAD"].ToString();

                MDI.MDI_FORM frm = new MDI.MDI_FORM();
                frm.Text = store_name;
                frm.toolStripStatusLabel1.Text = "MAĞAZA : " + store_name;
                frm.toolStripStatusLabel2.Text = " KULLANICI : " + user_name + " " + user_last_name;
                frm.Show();
                this.Hide();
            }
            else
            {
                kryptonButton1.Enabled = true;
                label4.Text = "Hatalı giriş...";
            }

            this.Cursor = Cursors.Default;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            processLogin();
        }
    }
}
