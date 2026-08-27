using System;
using SqlSugar;

namespace WPF_NET48_SqlSugarDemo.Util
{
    public class DbUtil
    {
        private static readonly Lazy<SqlSugarScope> PostgreSQLLazy = new Lazy<SqlSugarScope>(() =>
        {
            SqlSugarScope sqlSugarClient = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = @"
HOST=192.168.1.61;
PORT=5432;
DATABASE=test;
searchpath=t_schema;
USER ID=postgres;
PASSWORD=pg123456;
",
                DbType = DbType.PostgreSQL,
                IsAutoCloseConnection = true
            });
            return sqlSugarClient;
        });

        private static readonly Lazy<SqlSugarScope> MySqlConnectorLazy = new Lazy<SqlSugarScope>(() =>
        {
            SqlSugarScope sqlSugarClient = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = @"
server=mysql5.sqlpub.com;
Port=3310;
Database=rytdhgdfh;
Uid=test001_user001;
Pwd=QwUX7lNunDoIChWB
",
                DbType = DbType.MySqlConnector,
                IsAutoCloseConnection = true
            });
            return sqlSugarClient;
        });

        private static readonly Lazy<SqlSugarScope> SqliteLazy = new Lazy<SqlSugarScope>(() =>
        {
            SqlSugarScope sqlSugarClient = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = @"
DataSource=.\Data\test.db
",
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
            });
            return sqlSugarClient;
        });

        public static SqlSugarScope SqlSugarClient => SqliteLazy.Value;
    }
}
