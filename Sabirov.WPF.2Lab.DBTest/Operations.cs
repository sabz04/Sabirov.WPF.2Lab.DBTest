using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sabirov.WPF._2Lab.DBTest
{
    public static class Operations
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sabirov;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);
        static DataTable table =new DataTable("Users");
        public static void OpenDBSQL(SqlConnection conn,SqlDataAdapter binder,DataTable table)
        {
            try
            {
                conn.Open();
                binder.Fill(table);
                //MessageBox.Show("Connection Open ! " + "Database name = " + sqlConnection.Database);
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cant open "+ex.Message);
            }
        }
        public static void OpenDBSQL(SqlConnection conn)
        {
            try
            {
                conn.Open();
                //MessageBox.Show("Connection Open ! " + "Database name = " + sqlConnection.Database);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant open " + ex.Message);
            }
        }
        public static void CreateZaprosSQL(string zapros,string tableName)
        {
            table = new DataTable($"{tableName}");
            //string sqlCom = $"CREATE TABLE {tableName}({tableName}ID int identity(1,1) primary key, Name varchar(100), " +
            //    "Pass varchar(100)); ";
            SqlCommand createCom = sqlConnection.CreateCommand();
            createCom.CommandText= zapros;
            SqlDataAdapter sqlBinder = new SqlDataAdapter(createCom);
            OpenDBSQL(sqlConnection,sqlBinder,table);
        }
        public static void CreateZaprosSQL(string zapros)
        {
            //string sqlCom = $"CREATE TABLE {tableName}({tableName}ID int identity(1,1) primary key, Name varchar(100), " +
            //    "Pass varchar(100)); ";
            SqlCommand createCom = sqlConnection.CreateCommand();
            createCom.CommandText = zapros;
            SqlDataAdapter sqlBinder = new SqlDataAdapter(createCom);
            OpenDBSQL(sqlConnection, sqlBinder, table);
        }
        public static DataTable CreateZaprosSQLWITHRES(string zapros)
        {
            DataTable tb = new DataTable();
            SqlCommand createCom = sqlConnection.CreateCommand();
            createCom.CommandText = zapros;
            SqlDataAdapter sqlBinder = new SqlDataAdapter(createCom);
            OpenDBSQL(sqlConnection, sqlBinder, table);
            sqlBinder.Fill(tb);
            return tb;
        }

    }
}
