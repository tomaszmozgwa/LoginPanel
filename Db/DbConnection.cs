using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanel.Db
{
    public static class DbConnection
    {
        public static SqlConnection GetDbConnection()
        {
            string cn_String = Properties.Settings.Default.ConnectionString;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != System.Data.ConnectionState.Open)
                cn_connection.Open();

            return cn_connection;
        }

        public static DataTable Get_DataTable(string sql)
        {
            SqlConnection cn_connection = GetDbConnection();

            //< get table >
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static void ExecuteSQL(string sql)
        {
            SqlConnection cn_connection = GetDbConnection();

            //<  execute query  >
            SqlCommand cmd_Command = new SqlCommand(sql, cn_connection);
            cmd_Command.ExecuteNonQuery();
        }

        public static void CloseDbConnection()
        {
            string cn_String = Properties.Settings.Default.ConnectionString;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != System.Data.ConnectionState.Closed)
                cn_connection.Close();
        }
    }
}
