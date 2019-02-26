using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Reflection;
using System.IO;


namespace ExportBarcode.Common
{
    public class DB
    {
        private SQLiteConnection _connection;

        public SQLiteConnection Connection
        {
            get
            {
                if ((this._connection == null))
                {
                    this.InitConnection();
                }
                return this._connection;
            }
        }

        private void InitConnection()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string currentDirectory = Path.GetDirectoryName(assemblyLocation);

            StringBuilder connection = new StringBuilder();
            connection.Append("Data Source=" + currentDirectory.Replace("file:\\", "") + "\\DB.sqlite;");

            _connection = new SQLiteConnection(connection.ToString());

        }

        public string ExecuteScalar(String query)
        {
            object result;
            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                Connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, Connection);
                command.ExecuteNonQuery();

                command.CommandText = "SELECT @@IDENTITY";
                result = command.ExecuteScalar().ToString();
            }
            finally
            {
                Connection.Close();
            }
            return result.ToString();
        }

        public bool ExecuteNonQuery(SQLiteCommand command)
        {
            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                Connection.Open();
                command.Connection = Connection;
                command.ExecuteNonQuery();
                return true;
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CloseConnnection()
        {
            if ((_connection == null))
            {
                _connection.Close();
            }
        }

        public System.Data.DataTable GetTable(SQLiteDataReader _reader)
        {
            System.Data.DataTable _table = _reader.GetSchemaTable();
            System.Data.DataTable _dt = new System.Data.DataTable();
            System.Data.DataColumn _dc;
            System.Data.DataRow _row;
            System.Collections.ArrayList _al = new System.Collections.ArrayList();
            try
            {
                for (int i = 0; i < _table.Rows.Count; i++)
                {
                    try
                    {
                        _dc = new System.Data.DataColumn();
                        if (!_dt.Columns.Contains(_table.Rows[i]["ColumnName"].ToString()))
                        {
                            _dc.ColumnName = _table.Rows[i]["ColumnName"].ToString();
                            _dc.DataType = Type.GetType((_table.Rows[i]["DataType"].ToString()));
                            //if (_table.Rows[i]["IsUnique"] != null)
                            //{
                            //    _dc.Unique = Convert.ToBoolean(_table.Rows[i]["Unique"]);
                            //}
                            _dc.AllowDBNull = Convert.ToBoolean(_table.Rows[i]["AllowDBNull"]);
                            _dc.ReadOnly = Convert.ToBoolean(_table.Rows[i]["IsReadOnly"]);
                            _al.Add(_dc.ColumnName);
                            _dt.Columns.Add(_dc);

                        }
                    }
                    catch
                    { }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            while (_reader.Read())
            {
                _row = _dt.NewRow();
                for (int i = 0; i < _al.Count; i++)
                {
                    _row[((System.String)_al[i])] = _reader[(System.String)_al[i]];
                }
                _dt.Rows.Add(_row);
            }
            return _dt;
        }

        public bool CheckExistRecord(String query)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = query.ToString();

                Connection.Open();
                command.Connection = Connection;
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    if (reader[0].ToString() != "")
                    {
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
            }
            finally
            {
                Connection.Close();
            }
            return false;
        }

        public DataTable GetTable(String query)
        {
            DataTable tbl = new DataTable();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = query.ToString();
            tbl = new DB().LoadObject(command);
            return tbl;
        }

        public DataTable GetTable(SQLiteCommand command)
        {
            DataTable tbl = new DataTable();
            tbl = new DB().LoadObject(command);
            return tbl;
        }

        public DataTable GetTable(String query, ref string MessageError)
        {
            DataTable tbl = new DataTable();
            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = query.ToString();
            tbl = new DB().LoadObject(command, ref MessageError, 0);
            return tbl;
        }

        public DataTable LoadObject(SQLiteCommand sqlCommand)
        {
            DataTable dt = new DataTable();
            SQLiteTransaction transaction;

            SQLiteDataAdapter da = new SQLiteDataAdapter();

            Connection.Open();
            sqlCommand.Connection = Connection;
            transaction = Connection.BeginTransaction();

            try
            {
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                dt = GetTable(reader);
                reader.Close();

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public DataTable LoadObject(SQLiteCommand sqlCommand, ref string MessageError, int checkRetry)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter();
                Connection.Open();
                sqlCommand.Connection = Connection;
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                dt = GetTable(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(MessageError))
                {
                    checkRetry = 1;
                }
                else
                {
                    checkRetry++;
                }
                MessageError = ex.ToString();
                if (checkRetry < 5)
                {
                    LoadObject(sqlCommand, ref MessageError, checkRetry);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static String SQuote(String s)
        {
                Integer len = s.Length + 25;
                StringBuilder tmpS = new StringBuilder(len);
                tmpS.Append("'");
                tmpS.Append(s.Replace("'", "''"));
                tmpS.Append("'");
                return tmpS.ToString();
        }

        public static object checkNull(Object obj) {
            try
            {
                if (obj.Equals(null) || obj.Equals("null")) return DBNull.Value;
                else return obj;
            }catch(Exception e){
                return DBNull.Value;
            }
        }
    }
}
