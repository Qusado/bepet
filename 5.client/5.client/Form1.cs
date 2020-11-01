using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _5.client.ServiceReference1;

namespace _5.client
{
    public partial class Form1 : Form
    {
        private ServiceReference1.Service1Client sessionClient;
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
            var client = new ServiceReference1.Service1Client();
            string id_exp = comboBox1.SelectedValue.ToString();
            string id_h = comboBox2.SelectedValue.ToString();
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            DateTime datee = dateTimePicker1.Value;
            var diffdate = (DateTime.Now - datee).Duration().Days.ToString();
            if (DateTime.Now < datee)
            {
                MessageBox.Show("Данная дата не доступна");
            }
            else if(client.RecCheck(id_exp, id_h, date, diffdate).Equals("1"))
            { 
                MessageBox.Show("Такая Запись уже существует!");
            }
            else
            {
                client.InsertMethod(id_exp, id_h, date);
                MessageBox.Show("Запись добавлена");
                this.Table();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sessionClient = new ServiceReference1.Service1Client();
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
