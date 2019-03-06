using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExportBarcode.MODEL;
using System.Data;
using ExportBarcode.Common;
using System.Data.SQLite;

namespace ExportBarcode.DAO
{
    public class ReceivingDAO
    {
        public static Boolean insert(ReceivingDTO p)
        {
            try
            {
                DB db = new DB();
                String query = "";
                query += "INSERT INTO PL_RECEIVING([SEQ],[PALLETNO],[LISTPART],[PACKINGMONTH],[PACKINGDATE],";
                query += "[RECEIVINGDATE],[PALLETQTY],[MAXPALLETQTY],[SUPPLIERCODE]) VALUES (";
                query += "@SEQ,@PALLETNO,@LISTPART,@PACKINGMONTH,@PACKINGDATE,@RECEIVINGDATE,@PALLETQTY,@MAXPALLETQTY,@SUPPLIERCODE)";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SQLiteParameter("@SEQ", p.seq));
                cmd.Parameters.Add(new SQLiteParameter("@PALLETNO", p.palletNo));
                cmd.Parameters.Add(new SQLiteParameter("@LISTPART", p.listPart));
                cmd.Parameters.Add(new SQLiteParameter("@PACKINGMONTH", p.packingMonth));
                cmd.Parameters.Add(new SQLiteParameter("@PACKINGDATE", p.packingDate));
                cmd.Parameters.Add(new SQLiteParameter("@RECEIVINGDATE", p.receivingDate));
                cmd.Parameters.Add(new SQLiteParameter("@PALLETQTY", p.palletQty));
                cmd.Parameters.Add(new SQLiteParameter("@MAXPALLETQTY", p.maxPalletQty));
                cmd.Parameters.Add(new SQLiteParameter("@SUPPLIERCODE", p.supplierCode));
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataTable LoadScreen(string palletNo)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM PL_RECEIVING ");
            query.Append(" WHERE [PALLETNO] = " + DB.SQuote(palletNo));
            DataTable dt = new DB().GetTable(query.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public static Integer checkReceiving()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT MAX([SEQ]) SEQ FROM PL_RECEIVING");
                DataTable dt = new DB().GetTable(query.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Int32.Parse(dt.Rows[0]["SEQ"].ToString());
                }
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable getDB()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM PL_RECEIVING ");
                query.Append("WHERE [CHECK] IS NOT NULL AND [CHECK] = 1");
                DataTable dt = new DB().GetTable(query.ToString());
                if (dt != null && dt.Rows.Count > 0)
                    return dt;
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
