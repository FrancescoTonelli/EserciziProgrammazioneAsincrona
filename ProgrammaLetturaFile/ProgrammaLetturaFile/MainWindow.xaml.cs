using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;
using System.IO;

namespace ProgrammaLetturaFile
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        int i;
        bool blocco;
        public MainWindow()
        {
            InitializeComponent();
            progBar.Visibility = Visibility.Hidden;
            lbl_.Visibility = Visibility.Hidden;
            path = @"./Data.txt";
            blocco = false;
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            progBar.Visibility = Visibility.Visible;
            lbl_.Visibility = Visibility.Visible;
            btnCount.Visibility = Visibility.Hidden;
            Conta();
            Progresso();
        }

        private async void Conta()
        {
            await Task.Run(() =>
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadToEnd();
                    double caratteri = text.Length;
                    string[] c = text.Split(' ');
                    double caratteriNoSpazi = 0;
                    foreach(string g in c)
                    {
                        caratteriNoSpazi += g.Length;
                    }
                    blocco = true;
                    int i = 100;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progBar.Value = i;
                        lblPrc.Content = i;
                    }));

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblTot.Content = "Caratteri totali: " + caratteri;
                        lblNoSp.Content = "Senza spazi: " + caratteriNoSpazi;
                    }));
                }
            });
        }

        Random r;

        private async void Progresso()
        {
            await Task.Run(() =>
            {
                r = new Random();
                for (int i = 0; i < 100 && !blocco; i += r.Next(1, 10))
                {
                    if(i >= 100)
                    {
                        i = 99;
                    }
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progBar.Value = i;
                        lblPrc.Content = i;
                    }));
                    Thread.Sleep(TimeSpan.FromMilliseconds(300));
                }

            });
        }
    }
}
