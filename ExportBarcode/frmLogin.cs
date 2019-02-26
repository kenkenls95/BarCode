using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ExportBarcode.DAO;
using ExportBarcode.SERVICE;
using ExportBarcode.MODEL;
using System.Collections.Generic;
using ExportBarcode.Common;
using ExportBarcode.Constant;
using CodeBetter.Json;

namespace HelloWord
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Service.getData(null, null) == null) MessageBox.Show("No Connection!");
            else MessageBox.Show("Connected!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                string assemblyLocation = Assembly.GetExecutingAssembly().GetName().CodeBase;
                string currentDirectory = Path.GetDirectoryName(assemblyLocation);
                string s = "data source = " + currentDirectory + "\\DB.sqlite";
                

                if (!string.IsNullOrEmpty(txtUser.Text))
                {
                    if (User.Login(txtUser.Text))
                    {
                        this.DialogResult = DialogResult.OK;
                        Service.syncDB();
                        Service.sendData();
                        return;
                    }
                    MessageBox.Show("Thông tên đăng nhập không đúng.");
                }
                else MessageBox.Show("Thông tin đăng nhập đang rỗng.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }
    }
}