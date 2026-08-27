# C# 操作数据库
# WPF_NET48_FreeSQLDemo
```plain
FreeSql

FreeSql.Provider.MySqlConnector

FreeSql.Provider.PostgreSQL

FreeSql.Provider.Sqlite
```

```bash
MSBuild ".\WPF_NET48_FreeSQLDemo\WPF_NET48_FreeSQLDemo.csproj" /t:Clean,Build /p:Configuration="Release" /p:Platform="AnyCPU"
```

# WPF_NET48_SqlSugarDemo
```plain
SqlSugar

MySqlConnector
SqlSugar.MySqlConnector

# Npgsql 9.x、10.x 不再支持 net48，不能装到 WPF .NET Framework 4.8 项目
Npgsql -Version 8.0.9

System.Data.SQLite
System.Data.SQLite.Core

Newtonsoft.Json
```

```bash
MSBuild ".\WPF_NET48_SqlSugarDemo\WPF_NET48_SqlSugarDemo.csproj" /t:Clean,Build /p:Configuration="Release" /p:Platform="AnyCPU"
```

# WPF_NET8_FreeSQLDemo
```plain
FreeSql

FreeSql.Provider.MySqlConnector

FreeSql.Provider.PostgreSQL

FreeSql.Provider.Sqlite
```

```bash
dotnet build ".\WPF_NET8_FreeSQLDemo\WPF_NET8_FreeSQLDemo.csproj" -t:Clean -c Release -p:Platform=AnyCPU
```

```bash
dotnet build ".\WPF_NET8_FreeSQLDemo\WPF_NET8_FreeSQLDemo.csproj" -t:Build -c Release -p:Platform=AnyCPU
```

# WPF_NET8_SqlSugarDemo
```plain
SqlSugarCoreNoDrive

MySqlConnector

Npgsql

Microsoft.Data.Sqlite
```

```bash
dotnet build ".\WPF_NET8_SqlSugarDemo\WPF_NET8_SqlSugarDemo.csproj" -t:Clean -c Release -p:Platform=AnyCPU
```

```bash
dotnet build ".\WPF_NET8_SqlSugarDemo\WPF_NET8_SqlSugarDemo.csproj" -t:Build -c Release -p:Platform=AnyCPU
```
