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
        public MainWindow()
        {
            InitializeComponent();
            progBar.Visibility = Visibility.Hidden;
            lbl_.Visibility = Visibility.Hidden;
            path = @"./Data.txt";
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

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblTot.Content = "Caratteri totali: " + caratteri;
                        lblNoSp.Content = "Senza spazi: " + caratteriNoSpazi;
                    }));
                }
            });
        }

        private async void Progresso()
        {
            await Task.Run(() =>
            {
                

            });
        }
    }
}
