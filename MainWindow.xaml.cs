using LoginPanel.Db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using LoginPanel.Windows;

namespace LoginPanel
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtbox_email.Focus();
            txtbox_email.TabIndex = 1;
            txtbox_password.TabIndex = 2;
        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbox_email.Text;
            string password = txtbox_password.Password;
            string sql;
            if (login.Length > 0 && password.Length > 0)
            {
                sql = $"SELECT TOP 1 1 FROM LOGINS WHERE Login = '{login}'";
                DataTable result = DbConnection.Get_DataTable(sql);
                if (result.Rows.Count != 0 && login.Length > 0)
                {
                    if (txtbox_password.Password.Length > 0)
                    {
                        sql = $"SELECT Top 1 Password from LOGINS WHERE Login = '{login}'";
                        result.Clear();
                        result = DbConnection.Get_DataTable(sql);

                        if (result.Rows[0].Field<string>("Password") == password)
                        {
                            MessageBox.Show("Zalogowano");
                        }
                        else
                        {
                            MessageBox.Show("Błędne hasło");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Musisz podać haslo");
                    }
                }
                else
                {
                    MessageBox.Show("Nie odnaleziono adresu email");
                }
            }
            else
            {
                MessageBox.Show("Musisz podać login i hasło");
            }
        }

        private void Btn_register__Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
