using System;
using System.Collections.Generic;
using System.Windows;
using WPF_NET48_FreeSQLDemo.Model;
using WPF_NET48_FreeSQLDemo.Util;

namespace WPF_NET48_FreeSQLDemo
{
    public partial class MainWindow
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
                int deleteRow1 = await DbUtil.fsql
                    .Delete<User>()
                    .Where(u => u.Id > 0)
                    .ExecuteAffrowsAsync();
                LogTextBox.AppendText(deleteRow1 + Environment.NewLine);

                LogTextBox.AppendText("\n增加一个" + Environment.NewLine);
                User tuser1 = new User() { Id = 1, Username = "tom", Password = "tom123456" };
                User tuser2 = new User() { Id = 2, Username = "jack", Password = "jack123456" };
                User tuser3 = new User() { Id = 3, Username = "marry", Password = "marry123456" };
                int addRow1 = await DbUtil.fsql
                    .Insert<User>(tuser1)
                    .ExecuteAffrowsAsync();
                int addRow2 = await DbUtil.fsql
                    .Insert<User>(tuser2)
                    .ExecuteAffrowsAsync();
                int addRow3 = await DbUtil.fsql
                    .Insert<User>(tuser3)
                    .ExecuteAffrowsAsync();
                LogTextBox.AppendText(addRow1 + Environment.NewLine);
                LogTextBox.AppendText(addRow2 + Environment.NewLine);
                LogTextBox.AppendText(addRow3 + Environment.NewLine);

                LogTextBox.AppendText("\n删除一个" + Environment.NewLine);
                int deleteRow2 = await DbUtil.fsql
                    .Delete<User>()
                    .Where(u => u.Id == tuser1.Id)
                    .ExecuteAffrowsAsync();
                LogTextBox.AppendText(deleteRow2 + Environment.NewLine);

                LogTextBox.AppendText("\n修改一个" + Environment.NewLine);
                tuser2.Password = "jack123456...";
                int updateRow1 = await DbUtil.fsql
                    .Update<User>()
                    .Set(u => u.Password, tuser2.Password)
                    .Where(u => u.Id == tuser2.Id)
                    .ExecuteAffrowsAsync();
                LogTextBox.AppendText(updateRow1 + Environment.NewLine);

                LogTextBox.AppendText("\n查询一个" + Environment.NewLine);
                User firstAsync = await DbUtil.fsql
                    .Select<User>()
                    .Where(u => u.Id == 2)
                    .FirstAsync();
                LogTextBox.AppendText(firstAsync.Id + " " + firstAsync.Username + " " + firstAsync.Password + Environment.NewLine);

                LogTextBox.AppendText("\n查询全部" + Environment.NewLine);
                List<User> list = await DbUtil.fsql
                    .Select<User>()
                    .ToListAsync();
                LogTextBox.AppendText(list.Count + Environment.NewLine);
                list.ForEach(u => LogTextBox.AppendText(u.Id + " " + u.Username + " " + u.Password + Environment.NewLine));
            }
            catch (Exception e)
            {
                LogTextBox.AppendText(e.Message + Environment.NewLine);
            }
        }
    }
}
