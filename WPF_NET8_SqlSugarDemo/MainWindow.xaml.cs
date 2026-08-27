using System.Windows;
using WPF_NET8_SqlSugarDemo.Model;
using WPF_NET8_SqlSugarDemo.Util;

namespace WPF_NET8_SqlSugarDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs routedEventArgs)
    {
        try
        {
            LogTextBox.AppendText("\n删除 id > 0 的数据" + Environment.NewLine);
            int deleteRow1 = await DbUtil.SqlSugarClient
                .Deleteable<User>()
                .Where(u => u.Id > 0)
                .ExecuteCommandAsync();
            LogTextBox.AppendText(deleteRow1 + Environment.NewLine);

            LogTextBox.AppendText("\n增加一个" + Environment.NewLine);
            User tuser1 = new User() { Id = 1, Username = "tom", Password = "tom123456" };
            User tuser2 = new User() { Id = 2, Username = "jack", Password = "jack123456" };
            User tuser3 = new User() { Id = 3, Username = "marry", Password = "marry123456" };
            int addRow1 = await DbUtil.SqlSugarClient
                .Insertable<User>(tuser1)
                .ExecuteCommandAsync();
            int addRow2 = await DbUtil.SqlSugarClient
                .Insertable<User>(tuser2)
                .ExecuteCommandAsync();
            int addRow3 = await DbUtil.SqlSugarClient
                .Insertable<User>(tuser3)
                .ExecuteCommandAsync();
            LogTextBox.AppendText(addRow1 + Environment.NewLine);
            LogTextBox.AppendText(addRow2 + Environment.NewLine);
            LogTextBox.AppendText(addRow3 + Environment.NewLine);


            LogTextBox.AppendText("\n删除一个" + Environment.NewLine);
            int deleteRow2 = await DbUtil.SqlSugarClient
                .Deleteable<User>()
                .Where(u => u.Id == tuser1.Id)
                .ExecuteCommandAsync();
            LogTextBox.AppendText(deleteRow2 + Environment.NewLine);

            LogTextBox.AppendText("\n修改一个" + Environment.NewLine);
            tuser2.Password = "jack123456...";
            int updateRow1 = await DbUtil.SqlSugarClient
                .Updateable<User>(tuser2)
                .WhereColumns(u => new { u.Password })
                .Where(u => u.Id == tuser2.Id)
                .ExecuteCommandAsync();
            LogTextBox.AppendText(updateRow1 + Environment.NewLine);

            LogTextBox.AppendText("\n查询一个" + Environment.NewLine);
            User firstAsync = await DbUtil.SqlSugarClient
                .Queryable<User>()
                .Where(u => u.Id == 2)
                .FirstAsync();
            LogTextBox.AppendText(firstAsync.Id + " " + firstAsync.Username + " " + firstAsync.Password + Environment.NewLine);

            LogTextBox.AppendText("\n查询全部" + Environment.NewLine);
            List<User> list = DbUtil.SqlSugarClient.Queryable<User>().ToList();
            list.ForEach(u => LogTextBox.AppendText(u.Id + " " + u.Username + " " + u.Password + Environment.NewLine));
        }
        catch (Exception e)
        {
            LogTextBox.AppendText(e.Message + Environment.NewLine);
        }
    }
}
