using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _5.server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        
        String connectionString = "Data Source=gggggggg.mssql.somee.com;Initial Catalog=gggggggg;Persist Security Info=True;User ID=good_job_Oleg_SQLLogin_1;Password=8aoh3a3zmb";


        public string InsertMethod(string id_exp, string id_h, string date)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"INSERT INTO [transfers] VALUES ({id_exp},{id_h},'{date}')";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
            return "Готово";
        }

        public DataTable GetData()
        {
            var query = "SELECT [transfers].id_tr, [transfers].id_exp_fk, [expanate].name_exp, [transfers].id_h_fk, [hall].name_h, [transfers].date, [transfers].stay " +
                    "FROM [transfers] " +
                    "INNER JOIN [hall] ON [hall].id_h = [transfers].id_h_fk " +
                    "INNER JOIN [expanate] ON [expanate].id_exp = [transfers].id_exp_fk";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "transfers";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable GetExpSelectData()
        {
            string query = "SELECT * FROM expanate";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "expanate";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

   
        public DataTable GetHallSelectData()
        {
            string query = "SELECT * FROM hall";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "hall";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public string RecCheck(string id_exp, string id_h, string date, string stay)
        {
            string query = $"SELECT COUNT(1) FROM [transfers] WHERE [transfers].id_exp_fk = {id_exp} AND [transfers].id_h_fk = {id_h} AND [transfers].date = '{date}' AND [transfers].stay='{stay}'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "transfers";
                            sda.Fill(dt);
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
        }

       
    }
}
