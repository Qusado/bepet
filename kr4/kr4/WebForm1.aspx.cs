using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kr4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack) return;
            var s = new ServiceReference1.WebService1SoapClient();
            GridView1.DataSource = s.GetData();
            GridView1.DataBind();
        }

        public void rewrite()
        {
            var s = new ServiceReference1.WebService1SoapClient();
            GridView1.DataSource = s.GetData();
            GridView1.DataBind();
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var s = new ServiceReference1.WebService1SoapClient();
            var autor = TextBox2.Text;
            var datetime = TextBox1.Text;
            var desc = TextBox3.Text;
            string dt = datetime.Substring(0, 10) + " " + datetime.Substring(11, 5);
            if (autor == "" || datetime == "" || desc == "")
            {
                Label20.Visible = true;
            }
            else //2020-15-80T12:12
            {
                var check = s.RecCheck(autor, desc, dt);
                if (check == "1")
                {
                    Label5.Visible = true;
                }
                else
                {
                    s.Insert(desc, autor, dt);
                    rewrite();
                }
            }
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
                    s.Delete(customAttr1);
                    rewrite();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var s = new ServiceReference1.WebService1SoapClient();
            int index = GridView1.SelectedIndex;
            DataTable dt = s.GetData();
            int id_rec_sel = Convert.ToInt32(dt.Rows[index][0]);
            DateTime date = DateTime.Parse(dt.Rows[index][1].ToString());

            TextBox4.Text = date.ToString("yyyy-MM-ddTHH:mm");
            
            TextBox5.Text = dt.Rows[index][2].ToString();
            TextBox6.Text = dt.Rows[index][3].ToString();




        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var s = new ServiceReference1.WebService1SoapClient();
            string updatetime = TextBox4.Text;
            string upautor= TextBox5.Text;
            string updesc = TextBox6.Text;

            int index = GridView1.SelectedIndex;
            DataTable dt = s.GetData();
            int upid_rec_sel = Convert.ToInt32(dt.Rows[index][0]);

            string updt = updatetime.Substring(0, 10) + " " + updatetime.Substring(11, 5);
            if (upautor == "" || updt == "" || updesc == "")
            {
                Label21.Enabled = true;
            }
            else //2020-15-80 12:12
            {
                s.Update(upid_rec_sel.ToString(), updesc, upautor, updt);
                rewrite();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
