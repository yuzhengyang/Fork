using Azylee.Core.AppUtils.AppConfigUtils.AppConfigInterfaces;
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.EncryptUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DbUtils;
using Azylee.Core.DbUtils.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.AppUtils.AppConfigUtils.AppConfigModels
{
    /// <summary>
    /// 数据库配置信息
    /// </summary>
    public class AppConfigDbItem : IAppConfigItemModel
    {
        private string PASSWORD_ENC_SIGN = "ENC:::";
        private string PASSWORD_ENC_PWD = "app.db.pwd.20211202";
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 唯一名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 服务器端口号
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 登录用户密码
        /// </summary>
        public string Password { get; set; }
        public void SetPasswordEnc(string value)
        {
            if (Str.Ok(value) && !value.StartsWith(PASSWORD_ENC_SIGN))
            {
                Password = PASSWORD_ENC_SIGN + AesTool.Encrypt(value, PASSWORD_ENC_PWD);
            }
            else
            {
                Password = value ?? "";
            }
        }
        public string GetPasswordEnc()
        {
            if (Str.Ok(Password) && Password.StartsWith(PASSWORD_ENC_SIGN))
            {
                return AesTool.Decrypt(Password.Substring(PASSWORD_ENC_SIGN.Length), PASSWORD_ENC_PWD);
            }
            else
            {
                return Password;
            }
        }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 默认数据库
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// SQL执行超时时间
        /// </summary>
        public int CommandTimeout { get; set; }
        /// <summary>
        /// 系统保留扩展链接字符
        /// </summary>
        public string JoinConnectString { get; set; }
        /// <summary>
        /// 扩展连接字符串
        /// </summary>
        public string ExtConnectString { get; set; }
        /// <summary>
        /// 自定义替换参数
        /// </summary>
        public List<string> CustRepList { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 全参数构造函数
        /// </summary>
        /// <param name="number"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <param name="extConnectString"></param>
        /// <param name="desc"></param>
        /// <param name="commandTimeout"></param>
        public AppConfigDbItem(int number, string type, string name, string server, string port, string userid, string password, string database, string extConnectString, List<string> custRep, string desc, int commandTimeout)
        {
            Number = number;
            Type = type;
            Name = name;
            Server = server;
            Port = port;
            UserId = userid;
            SetPasswordEnc(password);
            Database = database;
            ExtConnectString = extConnectString;
            CustRepList = custRep;
            Desc = desc;
            CommandTimeout = commandTimeout;
        }

        /// <summary>
        /// 获取用户自定义替换参数的对照信息
        /// 示例：{{$HI.CUSREP=>USER.ACCOUNT1}} 1
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetCustRepParams()
        {
            if (!Ls.ok(CustRepList)) return null;
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            foreach (var item in CustRepList)
            {
                string begSign = "{{$HI.CUSREP=>";
                string endSign = "}}";
                int endPos = item.IndexOf(endSign);
                if (item.StartsWith(begSign) && endPos > -1)
                {
                    string key = item.Substring(0, endPos);
                    if (key.Ok()) key = key + endSign;
                    string val = item.Substring(endPos + endSign.Length);
                    if (val.Ok()) val = val.Trim();
                    keyValuePairs[key] = val;
                }
            }
            return keyValuePairs;
        }

        public DatabaseType DbType()
        {
            switch (Type.ToLower())
            {
                case "pg":
                case "postgresql": return DatabaseType.PostgreSQL;

                case "ddm": return DatabaseType.DDM;

                case "starrocks": return DatabaseType.StarRocks;

                case "mysql":
                default:
                    return DatabaseType.Mysql;
            }
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="database">执行连接库</param>
        /// <returns></returns>
        public string ConnectionString(string database = null)
        {
            if (!Str.Ok(database)) database = Database;
            switch (DbType())
            {
                case DatabaseType.PostgreSQL:
                    {
                        return $"Server = {Server}; Port = {(Str.Ok(Port) ? Port : "3306")}; User Id = {UserId}; Password = {GetPasswordEnc()}; Database = {database}; {JoinConnectString} {ExtConnectString}";
                    }

                case DatabaseType.DDM:
                    {
                        return $"server = {Server}; port = {(Str.Ok(Port) ? Port : "3306")}; userid = {UserId}; password = {GetPasswordEnc()}; database = {database}; persistsecurityinfo = True; {JoinConnectString} {ExtConnectString}";
                    }

                case DatabaseType.StarRocks:
                    {
                        return $"server = {Server}; port = {(Str.Ok(Port) ? Port : "9030")}; userid = {UserId}; password = {GetPasswordEnc()}; database = {database}; persistsecurityinfo = True; {JoinConnectString} {ExtConnectString}";
                    }

                case DatabaseType.Mysql:
                default:
                    {
                        return $"server = {Server}; port = {(Str.Ok(Port) ? Port : "3306")}; userid = {UserId}; password = {GetPasswordEnc()}; database = {database}; persistsecurityinfo = True; {JoinConnectString} {ExtConnectString}";
                    }
            }
        }

        /// <summary>
        /// 表空间配置库
        /// </summary>
        /// <returns></returns>
        public string SchemaDatabase()
        {
            switch (DbType())
            {
                case DatabaseType.PostgreSQL:
                    {
                        return "";
                    }
                case DatabaseType.DDM:
                    {
                        return "";
                    }
                case DatabaseType.Mysql:
                default:
                    {
                        return "information_schema";
                    }
            }
        }
        /// <summary>
        /// 测试连接查询语句
        /// </summary>
        /// <returns></returns>
        public string ValidationQuery()
        {
            switch (DbType())
            {
                case DatabaseType.PostgreSQL:
                case DatabaseType.DDM:
                case DatabaseType.Mysql:
                default:
                    {

                        return "select now()";
                    }
            }
        }
        /// <summary>
        /// 表空间查询语句
        /// </summary>
        /// <returns></returns>
        public string SchemaQuery()
        {
            switch (DbType())
            {
                case DatabaseType.PostgreSQL:
                    return "SELECT datname AS schema_name FROM pg_database";

                case DatabaseType.DDM: return "SHOW DATABASES";

                case DatabaseType.Mysql:
                default:
                    return "SELECT schema_name FROM `SCHEMATA`";
            }
        }

        /// <summary>
        /// 排序序号
        /// </summary>
        /// <returns></returns>
        public int GetOrderNumber()
        {
            return this.Number;
        }
        /// <summary>
        /// 唯一名称
        /// </summary>
        /// <returns></returns>
        public string GetUniqueName()
        {
            return this.Name;
        }
    }
}
