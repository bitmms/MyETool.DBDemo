using FreeSql.DataAnnotations;

namespace WPF_NET8_FreeSQLDemo.Model;

/*
create table t_user
(
id       int          not null primary key,
username varchar(100) null,
password varchar(100) null
);
 */


// [Table(Name = "t_schema.t_user")] // PostgreSQL 特殊的表名："schema.table"
[Table(Name = "t_user")]
public class User
{
    [Column(Name = "id", IsIdentity = false, IsPrimary = true)]
    public int Id { get; set; }

    [Column(Name = "username", StringLength = 100)]
    public string Username { get; set; }

    [Column(Name = "password", StringLength = 100)]
    public string Password { get; set; }
}
