using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _5.web.ServiceReference1;

namespace _5.web
{
    public partial class SiteMaster : MasterPage
    {
        Service1Client sessionClient = new Service1Client("BasicHttpBinding_IService1");
        static Uri address = new Uri("http://localhost:8732/Design_Time_Addresses/Service1/");
        NetTcpBinding binding = new NetTcpBinding();
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                address.ToString(), address.Scheme);
            Rewrite();
        }

        public void Rewrite()
        {
            GridView1.DataSource = sessionClient.GetData();
            GridView1.DataBind();
            DropDownList1.DataSource = sessionClient.GetExpSelectData();
            DropDownList1.DataTextField = "name_exp";
            DropDownList1.DataValueField = "id_exp";
            DropDownList1.DataBind();
            DropDownList3.DataSource = sessionClient.GetExpSelectData();
            DropDownList3.DataTextField = "name_exp";
            DropDownList3.DataValueField = "id_exp";
            DropDownList3.DataBind();
            DropDownList2.DataSource = sessionClient.GetHallSelectData();
            DropDownList2.DataTextField = "name_h";
            DropDownList2.DataValueField = "id_h";
            DropDownList2.DataBind();
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label8.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id_exp = DropDownList1.Text;
            string id_h = DropDownList2.SelectedValue;
            string date = TextBox1.Text;
            if (date == "")
            {
                Label4.Visible = true;
            }
            else
            {
                var year = Int32.Parse(date.Substring(0, 4));
                var months = Int32.Parse(date.Substring(5, 2));
                var dat = Int32.Parse(date.Substring(8, 2));
                DateTime dateTime = new DateTime(year, months, dat, 0, 0, 0);
                var diffdate = (DateTime.Now - dateTime).Duration().Days.ToString();
                if(DateTime.Now < dateTime)
                { 
                    Label5.Visible = true;
                }
                else if(sessionClient.RecCheck(id_exp, id_h, date, diffdate).Equals("1"))
                { 
                    Label8.Visible = true;
                }
                else
                { 
                    sessionClient.InsertMethod(id_exp, id_h, date); 
                    Label6.Visible = true;
                    this.Rewrite();
                    sessionClient.CountOfDBRows(GridView1.Rows.Count.ToString());
                }
            }

            
        }
    }
}