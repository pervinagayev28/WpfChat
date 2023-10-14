using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Writing
{

    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            StartTimer();
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Button_Click_1(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MessageContext())
            {
                var newMessage = new Message { check="1", Content = SendMessage.Text.ToString() ,date = DateTime.Now};
                db.Message.Add(newMessage);
                db.SaveChanges();
                Button_Click_1(default, default);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            messages.Items.Clear();
            using (var db = new MessageContext())
            {

                var data = db.Message.ToList().OrderBy(m=>m.date);
                foreach (var item in data)
                {
                    if (item.check=="1")
                    {
                        messages.Items.Add(item.Content);
                    }
                    else
                    {
                        messages.Items.Add("\t\t" + item.Content);
                    }

                }

            }
        }
    }
}
