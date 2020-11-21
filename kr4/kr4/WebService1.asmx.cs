using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace kr4
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
   // [WebService(Namespace = "http://tempuri.org/")]
  ////  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  //  [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        String connectionString = "Data Source=service.mssql.somee.com;Initial Catalog=service;Persist Security Info=False;User ID=good_job_Oleg_SQLLogin_1;Password=8aoh3a3zmb";


        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public string Insert(string desc, string autor, string datetime)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"INSERT INTO [Table_1] VALUES ('{datetime}','{autor}','{desc}')";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
            return "Ok";
        }


        [WebMethod]
        public DataTable GetData()
        {
            var query = "";
            query = "SELECT * FROM [Table_1]";
          
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
                            dt.TableName = "Table_1";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public string Delete(string id)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"DELETE FROM [Table_1] WHERE id_rec={id};";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
            return "Ok";
        }


        [WebMethod]
        public string RecCheck(string autor, string desc, string datetime)
        {
            string query = $"SELECT COUNT(1) FROM [Table_1] WHERE [Table_1].datetime='{datetime}' AND [Table_1].autor = '{autor}' AND [Table_1].description = '{desc}'";
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
                            dt.TableName = "Table_1";
                            sda.Fill(dt);
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
        }

       


        [WebMethod]
        public string Update(string id_rec, string desc, string autor, string datetime)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"update [Table_1] set datetime = '{datetime}', autor = '{autor}', description = '{desc}' where id_rec = '{id_rec}'";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
            return "Ok";
        }
    }
}
