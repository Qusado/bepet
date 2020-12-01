using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bepet_4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var s = new ServiceReference1.WebService1SoapClient();
                DropDownList1.DataSource = s.GetExpSelectData();
                DropDownList1.DataTextField = "name_exp";
                DropDownList1.DataValueField = "id_exp";
                DropDownList1.DataBind();
                DropDownList2.DataSource = s.GetHallSelectData();
                DropDownList2.DataTextField = "name_h";
                DropDownList2.DataValueField = "id_h";
                DropDownList2.DataBind();
            }

        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var s = new ServiceReference1.WebService1SoapClient();
            var id_Client = DropDownList1.Text;
            var id_Bus = DropDownList2.Text;
            var date = this.TextBox1.Text;
            if (date == "")
            {
                Label20.Visible = true;
            }
            else
            {
                var year = Int32.Parse(date.Substring(0, 4));
                var months = Int32.Parse(date.Substring(5, 2));
                var dat = Int32.Parse(date.Substring(8, 2));
                DateTime dateTime = new DateTime(year, months, dat, 0, 0, 0);
                var diffdate = (DateTime.Now - dateTime).Duration().Days;
                var check = s.RecCheck(id_Client, id_Bus, date, diffdate.ToString());
                if (check == "1")
                {
                    Label5.Visible = true;
                }
                else
                {
                    var ch = s.InsertMethod(id_Client, id_Bus, date);
                    Response.Redirect("/WebForm1");
                }
            }

           
        }
    }
}