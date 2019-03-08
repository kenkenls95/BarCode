using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExportBarcode.DAO;

namespace ExportBarcode
{
    public partial class frmPopup : Form
    {
        public frmPopup()
        {
            InitializeComponent();
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {

        }

        public void loadScreen(String palletNo) {
            txtCode.Focus();
            DataTable dt = ReceivingDAO.LoadScreen(palletNo);
            DateTime receivingDate = DateTime.Parse(dt.Rows[0]["RECEIVINGDATE"].ToString());
            lblDate.Text = receivingDate.ToString("yyyy/MMM/dd");
            lblPackingMonth.Text = dt.Rows[0]["PACKINGMONTH"].ToString();
            lblPalletNo.Text = palletNo;
            lblSupplierCode.Text = dt.Rows[0]["SUPPLIERCODE"].ToString();
            String[] listPart = dt.Rows[0]["LISTPART"].ToString().Split(new char[] { ';' });
                
            DataTable list = new DataTable();
            for (int i = 0; i < listPart.Length; i++ ) {
                list.Rows[i]["No"] = i.ToString();
                list.Rows[i]["Part No"] = listPart[i].ToString();
            }

            tblData.DataSource = list;

        }


        
    }
}