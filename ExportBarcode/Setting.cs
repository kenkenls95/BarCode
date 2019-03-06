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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            DataTable dt = PackingDAO.getDB();
            settingDgv.DataSource = dt;
        }

        private void settingDgv_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {

        }

    }
}