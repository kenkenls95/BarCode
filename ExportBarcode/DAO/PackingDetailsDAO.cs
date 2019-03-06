using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using ExportBarcode.Common;
using ExportBarcode.MODEL;

namespace ExportBarcode.DAO
{
    public class PackingDetailsDAO
    {
        public static DataTable LoadScreen(string moduleNo)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM PL_PACKINGDETAILS ");
            query.Append(" WHERE [MODULENO] = " + DB.SQuote(moduleNo));
            DataTable dt = new DB().GetTable(query.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public static DataTable getAll()
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM PL_PACKINGDETAILS ");
            DataTable dt = new DB().GetTable(query.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public static Integer checkPackingDetails()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                //query.Append("SELECT MAX([PACKINGDETAILSID]) PACKINGDETAILSID FROM PL_PACKINGDETAILS");
                query.Append("SELECT MAX([PACKINGDETAILSID]) PACKINGDETAILSID FROM PL_PACKINGDETAILS");
                DataTable dt = new DB().GetTable(query.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Int32.Parse(dt.Rows[0]["PACKINGDETAILSID"].ToString());
                }
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Boolean insert(PackingDetails p)
        {

            try
            {
                DB db = new DB();
                String query = "";
                query += "INSERT INTO PL_PACKINGDETAILS([PACKINGDETAILSID], [MODULENO],[PARTID],[BOX],[PACKINGDATE],";
                query += "[PARTNO],[MINORCODE],[ANDONPACKINGDATE],[LINE],[QTYPERBOX]) VALUES (";
                query += "@packingdetailsid,@moduleno,@partid,@box,@packingdate,@partno,@minorcode,"
                    + "@andonpackingdate,@line,@qtyperbox)";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SQLiteParameter("@packingdetailsid", p.packingDetailsId));
                cmd.Parameters.Add(new SQLiteParameter("@moduleno", p.moduleNo));
                cmd.Parameters.Add(new SQLiteParameter("@partid", p.partId));
                cmd.Parameters.Add(new SQLiteParameter("@box", p.box));
                cmd.Parameters.Add(new SQLiteParameter("@packingdate", p.packingDate));
                cmd.Parameters.Add(new SQLiteParameter("@partno", p.partNo));
                cmd.Parameters.Add(new SQLiteParameter("@minorcode", p.minorCode));
                cmd.Parameters.Add(new SQLiteParameter("@andonpackingdate", p.andOnPackingDate));
                cmd.Parameters.Add(new SQLiteParameter("@line", p.line));
                cmd.Parameters.Add(new SQLiteParameter("@qtyperbox", p.qtyPerBox));
                //cmd.Parameters.AddWithValue("@packingdetailsid", SqlDbType.NVarChar).Value = DB.checkNull(p.packingDetailsId);
                //cmd.Parameters.AddWithValue("@moduleno", SqlDbType.NVarChar).Value = DB.checkNull(p.moduleNo);
                //cmd.Parameters.AddWithValue("@importerseriesname", SqlDbType.NVarChar).Value = DB.checkNull(p.importerSeriesName);
                //cmd.Parameters.AddWithValue("@partid", SqlDbType.NVarChar).Value = DB.checkNull(p.partId);
                //cmd.Parameters.AddWithValue("@box", SqlDbType.NVarChar).Value = DB.checkNull(p.box);
                //cmd.Parameters.AddWithValue("@packingdate", SqlDbType.NVarChar).Value = DB.checkNull(p.packingDate);
                //cmd.Parameters.AddWithValue("@shippingdetailsid", SqlDbType.NVarChar).Value = DB.checkNull(p.shippingDetailsId);
                //cmd.Parameters.AddWithValue("@partno", SqlDbType.NVarChar).Value = DB.checkNull(p.partNo);
                //cmd.Parameters.AddWithValue("@minorcode", SqlDbType.NVarChar).Value = DB.checkNull(p.minorCode);
                //cmd.Parameters.AddWithValue("@carfamilyid", SqlDbType.NVarChar).Value = DB.checkNull(p.carFamilyId);
                //cmd.Parameters.AddWithValue("@containerrenban", SqlDbType.NVarChar).Value = DB.checkNull(p.containerRenBan);
                //cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = DB.checkNull(p.type);
                //cmd.Parameters.AddWithValue("@andonpackingdate", SqlDbType.NVarChar).Value = DB.checkNull(p.andOnPackingDate);
                //cmd.Parameters.AddWithValue("@line", SqlDbType.NVarChar).Value = DB.checkNull(p.line);
                //cmd.Parameters.AddWithValue("@qtyperbox", SqlDbType.NVarChar).Value = DB.checkNull(p.qtyPerBox);
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e) { return false; }
        }

        public static Boolean updateBoxActual(PackingDetailsUpdate p) {
            try
            {
                DB db = new DB();
                String query = "";
                query += "UPDATE PL_PACKINGDETAILS SET [BOXACTUAL] = @B WHERE [MODULENO] = @M and [PARTNO] = @P";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SQLiteParameter("@B", p.boxActual));
                cmd.Parameters.Add(new SQLiteParameter("@M", p.moduleNo));
                cmd.Parameters.Add(new SQLiteParameter("@P", p.partNo));
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e) { return false; }
        }

        public static Boolean deletePackingDetals()
        {
            try
            {
                DB db = new DB();
                String query = "";
                SQLiteCommand cmd = new SQLiteCommand();
                query += "DELETE FROM PL_PACKINGDETAILS";
                cmd.CommandText = query;
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

}
