using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using LoginPanel.Db;

namespace LoginPanel.Windows
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbox_email.Text;
            string password = txtbox_password.Text;
            string sql;
            sql = $"SELECT TOP 1 1 FROM LOGINS WHERE Login = '{login}'";
            DataTable result = DbConnection.Get_DataTable(sql);
            if (result.Rows.Count != 0)
            {
                MessageBox.Show("Podany email już istnieje w bazie danych");
            }
            else
            {
                sql = $"INSERT INTO LOGINS (Login, Password) VALUES ('{login}', '{password}')";
                DbConnection.ExecuteSQL(sql);
                MessageBox.Show("Dodano nowego użytkownika");
                Close();
            }
        }
        
        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
