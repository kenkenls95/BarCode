using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HelloWord
{
    static class Program
    {

        [MTAThread]
        static void Main()
        {
            frmLogin dlgLogin = new frmLogin();
            frmMain dlgMain = new frmMain();
            if (dlgLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(dlgMain);
            }
        }
    }
}