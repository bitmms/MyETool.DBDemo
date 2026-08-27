using System.Diagnostics;
using FreeSql.Internal;

namespace WPF_NET8_FreeSQLDemo.Util;

public class DbUtil
{
    private static readonly Lazy<IFreeSql> PostgreSqlLazy = new Lazy<IFreeSql>(() =>
    {
        var freeSql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.PostgreSQL, @"
Host=192.168.1.61;
Port=5432;
Database=test;
Username=postgres;
Password=pg123456;

Pooling=true;
Minimum Pool Size=1;
")
            .UseAdoConnectionPool(true)
            .UseAutoSyncStructure(false)
            .UseMonitorCommand(cmd => Trace.WriteLine($"Sql：{cmd.CommandText}"))
            .UseNameConvert(NameConvertType.None)
            .Build();

        return freeSql;
    });

    private static readonly Lazy<IFreeSql> MySqlLazy = new Lazy<IFreeSql>(() =>
    {
        var freeSql = new FreeSql.FreeSqlBuilder()
            .UseConnectionString(FreeSql.DataType.MySql, @"
Host=mysql5.sqlpub.com;
Port=3310;
Database=rytdhgdfh;
Username=test001_user001;
Password=QwUX7lNunDoIChWB;

Charset=utf8mb4;
SslMode=none;
Min pool size=1")
            .UseAdoConnectionPool(false)
            .UseAutoSyncStructure(false)
            .UseMonitorCommand(cmd => Trace.WriteLine($"Sql：{cmd.CommandText}"))
            .UseNameConvert(NameConvertType.None)
            .Build();
        return freeSql;
    });

    private static readonly Lazy<IFreeSql> SqliteLazy = new Lazy<IFreeSql>(() =>
    {
        var freeSql = new FreeSql.FreeSqlBuilder()
            .UseMonitorCommand(cmd => Trace.WriteLine($"Sql：{cmd.CommandText}"))
            .UseAdoConnectionPool(true)
            .UseConnectionString(FreeSql.DataType.Sqlite, @"
Data Source=.\Data\test.db
")
            .UseAutoSyncStructure(true) //自动同步实体结构到数据库，只有CRUD时才会生成表
            .Build();
        return freeSql;
    });

    public static IFreeSql fsql => SqliteLazy.Value;
}
