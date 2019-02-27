using System;
using System.Text;
using ExportBarcode.Common;
using System.Data;
using ExportBarcode.MODEL;
using System.Data.SQLite;

namespace ExportBarcode.DAO
{
    public class PackingDAO
    {
        public static DataTable LoadScreen(string moduleNo)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM PL_PACKING ");
            query.Append(" WHERE [MODULENO] = " + DB.SQuote(moduleNo));
            query.Append(" AND [BEGINACTUALPACKING] IS NOT NULL AND [ENDACTUALPACKING] IS NOT NULL AND [PENDING] <> 1 ");
            DataTable dt = new DB().GetTable(query.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public static DataTable getById(string moduleNo)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT * FROM PL_PACKING ");
            query.Append(" WHERE [MODULENO] = " + DB.SQuote(moduleNo));
            DataTable dt = new DB().GetTable(query.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public static Integer checkPacking()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT MAX([PACKINGID]) PACKINGID FROM PL_PACKING");
                DataTable dt = new DB().GetTable(query.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Int32.Parse(dt.Rows[0]["PACKINGID"].ToString());
                }
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Boolean insert(Packing p)
        {
            try
            {
                DB db = new DB();
                String query = "";
                query += "INSERT INTO PL_PACKING([PACKINGID],[MODULENO],[IMPORTERSERIESNAME],[BOX],[PACKINGDATE],[PENDING],";
                query += "[ANDONPACKINGDATE],[LINE]) VALUES (";
                query += "@packingid,@moduleno,@impseriesname,@box,@packingdate,@pending,@andonpackingdate,@line)";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SQLiteParameter("@packingid", p.packingId));
                cmd.Parameters.Add(new SQLiteParameter("@moduleno", p.moduleNo));
                cmd.Parameters.Add(new SQLiteParameter("@impseriesname", p.importerSeriesName));
                cmd.Parameters.Add(new SQLiteParameter("@box", p.box));
                cmd.Parameters.Add(new SQLiteParameter("@packingdate", p.packingDate));
                cmd.Parameters.Add(new SQLiteParameter("@pending", p.pending));
                cmd.Parameters.Add(new SQLiteParameter("@andonpackingdate", p.andOnPackingDate));
                cmd.Parameters.Add(new SQLiteParameter("@line", p.line));
                //cmd.Parameters.AddWithValue("@packingid", SqlDbType.Text).Value = DB.checkNull(p.packingId);
                //cmd.Parameters.AddWithValue("@moduleno", SqlDbType.Text).Value = DB.checkNull(p.moduleNo);
                //cmd.Parameters.AddWithValue("@impseriesname", SqlDbType.Text).Value = DB.checkNull(p.importerSeriesName);
                //cmd.Parameters.AddWithValue("@box", SqlDbType.Text).Value = DB.checkNull(p.box);
                //cmd.Parameters.AddWithValue("@packingdate", SqlDbType.Text).Value = DB.checkNull(p.packingDate);
                //cmd.Parameters.AddWithValue("@pending", SqlDbType.Text).Value = DB.checkNull(p.pending);
                //cmd.Parameters.AddWithValue("@type", SqlDbType.Text).Value = DB.checkNull(p.type);
                //cmd.Parameters.AddWithValue("@andonpackingdate", SqlDbType.Text).Value = DB.checkNull(p.andOnPackingDate);
                //cmd.Parameters.AddWithValue("@line", SqlDbType.Text).Value = DB.checkNull(p.line);
                //return db.ExecuteNonQuery(cmd);
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e) { 
                return false; 
            }
        }

        public static Boolean update(DateTime begin, DateTime end, String moduleNo, String packingId)
        {
            try
            {
                DB db = new DB();
                String query = "";
                SQLiteCommand cmd = new SQLiteCommand();
                query += "UPDATE PL_PACKING SET [BEGINACTUALPACKING] = @b, [ENDACTUALPACKING] = @e, [PENDING] = @pen WHERE [MODULENO] = @M and [PACKINGID] = @P";
                cmd.CommandText = query;
                cmd.Parameters.Add(new SQLiteParameter("@b", begin.ToString("yyyy-MM-dd HH:mm:ss")));
                cmd.Parameters.Add(new SQLiteParameter("@e", end.ToString("yyyy-MM-dd HH:mm:ss")));
                cmd.Parameters.Add(new SQLiteParameter("@pen", 0));
                cmd.Parameters.Add(new SQLiteParameter("@M", moduleNo));
                cmd.Parameters.Add(new SQLiteParameter("@P", packingId));
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Boolean skipCase(DateTime begin, DateTime end, String moduleNo, Int32 pending)
        {
            try
            {
                DB db = new DB();
                String query = "";
                SQLiteCommand cmd = new SQLiteCommand();
                query += "UPDATE PL_PACKING SET [BEGINACTUALPACKING] = @b, [ENDACTUALPACKING] = @e, [PENDING] = @pen WHERE [MODULENO] = @M";
                cmd.CommandText = query;
                cmd.Parameters.Add(new SQLiteParameter("@b", begin.ToString("yyyy-MM-dd HH:mm:ss")));
                cmd.Parameters.Add(new SQLiteParameter("@e", end.ToString("yyyy-MM-dd HH:mm:ss")));
                cmd.Parameters.Add(new SQLiteParameter("@pen", pending));
                cmd.Parameters.Add(new SQLiteParameter("@M", moduleNo));
                return db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataTable getDB()
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM PL_PACKING ");
                query.Append("WHERE [BEGINACTUALPACKING] IS NOT NULL AND [ENDACTUALPACKING] IS NOT NULL AND [PENDING] IS NOT NULL");
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

        public static DataTable getPackingByModuleNo(String moduleNo)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM PL_PACKING ");
                query.Append(" WHERE [MODULENO] = " + DB.SQuote(moduleNo));
                DataTable dt = new DB().GetTable(query.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Boolean deletePacking() {
            try
            {
                DB db = new DB();
                String query = "";
                SQLiteCommand cmd = new SQLiteCommand();
                query += "DELETE FROM PL_PACKING";
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
