using SqlSugar;

namespace WPF_NET8_SqlSugarDemo.Model;

[SugarTable(TableName = "t_user")]
public class User
{
    [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = false)]
    public int Id { get; set; }

    [SugarColumn(ColumnName = "username")] public string Username { get; set; }

    [SugarColumn(ColumnName = "password")] public string Password { get; set; }
}
