using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ExportBarcode.Common;


namespace ExportBarcode.DAO
{
    public class User
    {
        public static Boolean Login(string userName)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM tblUsers ");
                query.Append(" WHERE [User] = " + DB.SQuote(userName));
                DataTable dt = new DB().GetTable(query.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
