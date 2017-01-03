using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Y.Utils.Net20.MysqlUtils
{
    /// <summary>
    /// MySQL数据库操作
    /// author:hhm
    /// date:2012-2-22
    /// </summary>
    public class MysqlTool
    {
        #region 私有变量
        //private const string defaultConfigKeyName = "DbHelper";//连接字符串 默认Key
        private string ConnectionString;
        private string ProviderName;

        #endregion

        #region 构造函数
        public MysqlTool(string connstr, string prostr = "MySql.Data.MySqlClient")
        {
            ConnectionString = connstr;
            ProviderName = prostr;
        }

        /// <summary>
        /// 默认构造函数(DbHelper)
        /// </summary>
        //public MysqlTool()
        //{
        //    this.connectionString = ConfigurationManager.ConnectionStrings["DbHelper"].ConnectionString;
        //    this.providerName = ConfigurationManager.ConnectionStrings["DbHelper"].ProviderName;
        //}

        /// <summary>
        /// DbHelper构造函数
        /// </summary>
        /// <param name="keyName">连接字符串名</param>
        //public MysqlTool(string keyName)
        //{
        //    this.connectionString = ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
        //    this.providerName = ConfigurationManager.ConnectionStrings[keyName].ProviderName;
        //}

        #endregion

        public int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            foreach (MySqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            int res = 0;
            try
            {
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = -1;
            }
            cmd.Dispose();
            con.Close();
            return res;
        }

        public object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            foreach (MySqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            object res = cmd.ExecuteScalar();
            cmd.Dispose();
            con.Close();
            return res;
        }

        public DataTable ExecuteDataTable(string sql, params MySqlParameter[] parameters)
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            foreach (MySqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            DataSet dataset = new DataSet();//dataset放执行后的数据集合
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dataset);
            cmd.Dispose();
            con.Close();
            return dataset.Tables[0];
        }
        //Test
        public void ExecuteDataTable2(string sql, params MySqlParameter[] parameters)
        {
            

            MySqlConnection sqlCon = new MySqlConnection(ConnectionString);
            //设置查询命令
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            //查询结果读取器
            MySqlDataReader reader = null;

            //获取查询结果代码：
            try
            {
                //打开连接
                sqlCon.Open();
                //执行查询，并将结果返回给读取器
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string x = "ID=" + reader[0].ToString() + " ,TITLE=" + reader[1].ToString() + " ,KEYWORD=" +
                    reader[2].ToString() + " ,CONTENT=" + reader[3].ToString() + ".";
                }

            }
            catch (Exception ex) { }
            finally
            {
                reader.Close();
                sqlCon.Close();
            }
        }
    }
}
