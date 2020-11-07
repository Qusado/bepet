using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _5.client.ServiceReference1;

namespace _5.client
{
    public partial class Form1 : Form
    {
        Service1Client sessionClient = new Service1Client("NetTcpBinding_IService1");
        static Uri address = new Uri("net.tcp://localhost:8739/Design_Time_Addresses/Service1/");
        NetTcpBinding binding = new NetTcpBinding();
        public Form1()
        {
            InitializeComponent();
        }

        public void Table()
        {
           
            dataGridView1.DataSource = sessionClient.GetData();
            dataGridView1.Columns[0].HeaderText = "ID перемещения";
            dataGridView1.Columns[1].HeaderText = "ID Экспоната";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Название";
            dataGridView1.Columns[3].HeaderText = "ID Зала";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Зал";
            dataGridView1.Columns[6].HeaderText = "Дней после перемещения";
            dataGridView1.Columns[5].HeaderText = "Дата перемещения";
            dataGridView1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_exp = comboBox1.SelectedValue.ToString();
            string id_h = comboBox2.SelectedValue.ToString();
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            DateTime datee = dateTimePicker1.Value;
            var diffdate = (DateTime.Now - datee).Duration().Days.ToString();
            if (DateTime.Now < datee)
            {
                MessageBox.Show("Данная дата не доступна");
            }
            else if(sessionClient.RecCheck(id_exp, id_h, date, diffdate).Equals("1"))
            { 
                MessageBox.Show("Такая Запись уже существует!");
            }
            else
            {
                sessionClient.InsertMethod(id_exp, id_h, date);
                MessageBox.Show("Запись добавлена");
                this.Table();
                sessionClient.CountOfDBRows(dataGridView1.Rows.Count.ToString());
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                address.ToString(), address.Scheme);
            comboBox1.DataSource = sessionClient.GetExpSelectData();
            comboBox1.DisplayMember = "name_exp";
            comboBox1.ValueMember = "id_exp";
            comboBox2.DataSource = sessionClient.GetHallSelectData();
            comboBox2.DisplayMember = "name_h";
            comboBox2.ValueMember = "id_h";
            Table();

        }
    }
}
