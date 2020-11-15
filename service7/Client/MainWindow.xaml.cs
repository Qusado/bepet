using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.ServiceReference1;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IService1Callback
    {
        bool isConnected = false;
        Service1Client client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new Service1Client(new System.ServiceModel.InstanceContext(this));
        }

        private void lbChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new Service1Client(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                if (File.Exists(tbUserName.Text + ".txt"))
                {
                    string[] readText = File.ReadAllLines(tbUserName.Text + ".txt");
                    foreach (string s in readText)
                    {
                        lbChat.Items.Add(s);
                    }
                }

                tbUserName.IsEnabled = false;
                bConnect.Content = "Disconnect";
                isConnected = true;
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                using (File.Create(tbUserName.Text+".txt"));
                string[] string_array = (from object item in lbChat.Items select item.ToString()).ToArray<string>(); 
                string_array.ToList().ForEach(str => File.AppendAllText(tbUserName.Text + ".txt", str + "\r\n"));
                lbChat.Items.Clear();
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                bConnect.Content = "Connect";
                isConnected = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }

        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count-1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void tbMess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client!=null)
                {
                    client.SendMess(tbMess.Text, ID);
                    tbMess.Text = string.Empty;
                }

               
            }
        }
    }
}
