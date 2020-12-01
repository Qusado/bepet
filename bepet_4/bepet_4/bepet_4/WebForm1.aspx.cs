using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bepet_4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) return;
            var s = new ServiceReference1.WebService1SoapClient();
            GridView1.DataSource = s.GetData(null, null);
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            var s = new ServiceReference1.WebService1SoapClient();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    String customAttr1 = cb.Attributes["data-Value"].ToString();
                    s.DeleteRec(customAttr1);
                }
            }

            Response.Redirect("/WebForm1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "") 
            { 
                if (DateTime.Parse(TextBox1.Text) < DateTime.Parse(TextBox2.Text))
                {
                    var s = new ServiceReference1.WebService1SoapClient();
                    GridView1.DataSource = s.GetData(TextBox1.Text, TextBox2.Text);
                    GridView1.DataBind();
                }
            }
            


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (DateTime.Parse(TextBox1.Text) > DateTime.Parse(TextBox2.Text))
            //{
            //    Label1.Text = "Невозможный формат даты";
            //    Label1.Visible = true;
            //}
            //else Label1.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}