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
            path = @"./Data.txt";
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            progBar.Visibility = Visibility.Visible;
            Prova();
            
        }

        public async void Prova()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 101; i++)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progBar.Value = i;
                    }));
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                }
            });
        }
    }
}
