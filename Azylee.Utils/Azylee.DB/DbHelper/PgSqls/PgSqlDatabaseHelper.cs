using Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels;
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DbUtils.DbInterface;
using Azylee.Core.IOUtils.TxtUtils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.DB.DbHelper.PgSqls

{
    public class PgSqlDatabaseHelper : IDatabaseHelper, IDisposable
    {
        private AppConfigDbItem Config;
        private string Database;

        private NpgsqlConnection dbConn = null;
        private NpgsqlCommand dbCmd = null;
        private NpgsqlDataReader dbDataReader = null;

        public PgSqlDatabaseHelper(AppConfigDbItem _config, string _database)
        {
            Config = _config;
            Database = _database;

            // 处理扩展参数
            if (Config.CommandTimeout > 0) Config.JoinConnectString = $"CommandTimeout={Config.CommandTimeout};" + Config.JoinConnectString;
            else Config.JoinConnectString = $"CommandTimeout=1800;" + Config.JoinConnectString;


            if (OpenConnect()) { }
            else
            {
                //ToastForm.Display("数据库连接失败", "未能打开当前数据连接，请检查地址和数据库是否选择正确", ToastForm.ToastType.error);
            }
        }


        public bool OpenConnect()
        {
            try
            {
                dbConn = new NpgsqlConnection(Config.ConnectionString(Database));
                dbCmd = new NpgsqlCommand();

                dbCmd.Connection = dbConn;

                dbConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TestConnect()
        {
            DataTable table = Select(Config.ValidationQuery());
            if (table != null && table.Rows != null && table.Rows.Count > 0) return true;
            return false;

        }
        public DataTable SchemaList()
        {
            return Select(Config.SchemaQuery());
        }

        public DataTable SelectWithException(string sql)
        {
            DataTable result = new DataTable();
            dbCmd.CommandText = sql;
            NpgsqlDataReader dataReader = dbCmd.ExecuteReader();

            if (dataReader != null)
            {
                result.Load(dataReader);
                dataReader.Close();
                return result;
            }
            return null;
        }

        public DataTable Select(string sql)
        {
            DataTable result = new DataTable();
            NpgsqlDataReader dataReader = ExecuteReader(sql);
            if (dataReader != null)
            {
                result.Load(dataReader);
                dataReader.Close();
                return result;
            }
            return null;
        }

        public NpgsqlDataReader ExecuteReader(string sql)
        {
            try
            {
                dbCmd.CommandText = sql;
                dbDataReader = dbCmd.ExecuteReader();
                return dbDataReader;
            }
            catch (Exception ex)
            {
                //ToastForm.Display("数据库查询失败", ex.Message, ToastForm.ToastType.error);
                return null;
            }
        }

        public Tuple<bool, int, string> ExecuteFile(string SqlFile, Action<string, bool, int, string> action)
        {
            if (!File.Exists(SqlFile)) return new Tuple<bool, int, string>(false, 100, "文件不存在");
            if (!Path.GetExtension(SqlFile).Contains("sql")) return new Tuple<bool, int, string>(false, 200, "文件格式不正确");

            List<string> lines = TxtTool.ReadLine(SqlFile);
            if (!Ls.ok(lines)) return new Tuple<bool, int, string>(false, 300, "文件为空");

            StringBuilder sql = new StringBuilder();
            foreach (var line in lines) { sql.AppendLine(line); }

            // 执行语句
            Tuple<bool, int, string> flag = ExecuteFileSql(sql.ToString());
            action.Invoke(sql.ToString(), flag.Item1, flag.Item2, flag.Item3);

            if (!flag.Item1)
            {
                return new Tuple<bool, int, string>(false, 400, "异常中断");
            }

            return new Tuple<bool, int, string>(true, 0, "运行完毕");
        }
        private Tuple<bool, int, string> ExecuteFileSql(string sql)
        {
            try
            {

                if (dbConn.State.Equals(ConnectionState.Closed))
                {
                    OpenConnect();
                }

                int flag = 0;
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = dbConn;
                    cmd.CommandText = sql;
                    try
                    {
                        flag = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //Commons.Log.e(ex.InnerException);
                        return new Tuple<bool, int, string>(false, 0, ex.Message);
                    }
                }
                return new Tuple<bool, int, string>(true, flag, "");
            }
            catch (PostgresException ex)
            {
                return new Tuple<bool, int, string>(false, 0, ex.Message + " Hint: " + ex.Hint ?? "");
            }

        }
        public int ExecuteNonQuery(string sqlStr_Insert)
        {
            dbCmd.CommandText = sqlStr_Insert;
            int result = dbCmd.ExecuteNonQuery();

            return result;
        }
        public void Dispose()
        {
            dbConn?.Close();
        }

        public DataTable ColumnList(string database, string schema, string table)
        {
            throw new NotImplementedException();
        }

        ~PgSqlDatabaseHelper()
        {
            dbConn?.Close();
        }
    }
}