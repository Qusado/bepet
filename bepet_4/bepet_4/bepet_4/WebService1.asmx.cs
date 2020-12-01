using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace bepet_4
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public string InsertMethod(string id_exp, string id_h, string date)
        {
            using (var context = new qqq1Entities())
            {
                var records = context.transfers;
                transfers transfers = new transfers
                {
                    id_exp_fk = Int32.Parse(id_exp),
                    id_h_fk = Int32.Parse(id_h),
                    date = Convert.ToDateTime(date)
                };
                context.transfers.Add(transfers);
                context.SaveChanges();
            }
            return "Готово";
        }

        [WebMethod]
        public DataTable GetData(string dateFirst, string dateSecond)
        {
            using (var context = new qqq1Entities())
            {
                using (DataTable dt = new DataTable())
                {
                    var trans = context.transfers;
                    dt.TableName = "transfers";
                    var col = new List<string>() { "id_tr", "id_exp_fk", "name_exp", "id_h_fk", "name_h", "date", "stay" };

                    foreach (var c in col)
                        dt.Columns.Add(c);

                    foreach (var e in trans)
                    {
                        if (string.IsNullOrEmpty(dateFirst) || string.IsNullOrEmpty(dateSecond))
                        {

                            dt.Rows.Add(
                                e.id_tr,
                                e.id_exp_fk,
                                e.expanate.name_exp,
                                e.id_h_fk,
                                e.hall.name_h,
                                e.date,
                                e.stay
                            );
                        }
                        else
                        {
                            if (DateTime.Parse(dateFirst) <= e.date && DateTime.Parse(dateSecond)>= e.date)
                            {
                                dt.Rows.Add(
                                    e.id_tr,
                                    e.id_exp_fk,
                                    e.expanate.name_exp,
                                    e.id_h_fk,
                                    e.hall.name_h,
                                    e.date,
                                    e.stay
                                );
                            }
                        }

                    } 
                    return dt;
                }

            }   
        }

        [WebMethod]
        public string DeleteRec(string id)
        {
            using (var context = new qqq1Entities())
            {
                int idd = Convert.ToInt32(id);
                transfers deletRec = context.transfers.Where(e => e.id_tr == idd).FirstOrDefault();
                if (deletRec != null)
                {
                    context.transfers.Remove(deletRec);
                    context.SaveChanges();
                }
                return "Ok";

            }
                
        }

        [WebMethod]
        public DataTable GetExpSelectData()
        {
            using (var context = new qqq1Entities())
            {
                using (DataTable dt = new DataTable())
                {
                    var exp = context.expanate;
                    dt.TableName = "expanate";
                    var col = new List<string>() { "id_exp", "name_exp", "autor_exp" };

                    foreach (var c in col)
                        dt.Columns.Add(c);

                    foreach (var e in exp)
                    { 
                           dt.Rows.Add(
                                e.id_exp,
                                e.name_exp,
                                e.autor_exp
                            );
                    }
                    return dt;
                }
            }
        }

        [WebMethod]
        public DataTable GetHallSelectData()
        {
            using (var context = new qqq1Entities())
            {
                using (DataTable dt = new DataTable())
                {
                    var h = context.hall;
                    dt.TableName = "hall";
                    var col = new List<string>() { "id_h", "name_h", "space_h" };

                    foreach (var c in col)
                        dt.Columns.Add(c);

                    foreach (var e in h)
                    {
                        dt.Rows.Add(
                             e.id_h,
                             e.name_h,
                             e.space_h
                         );
                    }
                    return dt;
                }
            }
        }


        [WebMethod]
        public string RecCheck(string id_exp, string id_h, string date, string stay)
        {
            using (var context = new qqq1Entities())
            {
                var exp = Int32.Parse(id_exp);
                var h = Int32.Parse(id_h);
                var dat = DateTime.Parse(date);
                transfers SearchRec = context.transfers.Where(t => t.id_exp_fk == exp && t.id_h_fk == h && t.date == dat).FirstOrDefault();
                if (SearchRec != null)
                {
                    return "1";
                }
                else return null;
            }
        }

       // String connectionString = "Data Source=gggggggg.mssql.somee.com;Initial Catalog=gggggggg;Persist Security Info=True;User ID=good_job_Oleg_SQLLogin_1;Password=8aoh3a3zmb";
    }
}
