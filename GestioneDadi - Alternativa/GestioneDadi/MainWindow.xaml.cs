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

namespace GestioneDadi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool stop;
        public Random r;

        public int i, l;

        readonly Uri uri1 = new Uri("d1.png", UriKind.Relative);
        readonly Uri uri2 = new Uri("d2.png", UriKind.Relative);
        readonly Uri uri3 = new Uri("d3.png", UriKind.Relative);
        readonly Uri uri4 = new Uri("d4.png", UriKind.Relative);
        readonly Uri uri5 = new Uri("d5.png", UriKind.Relative);
        readonly Uri uri6 = new Uri("d6.png", UriKind.Relative);

        ImageSource imm1;
        ImageSource imm2;
        ImageSource imm3;
        ImageSource imm4;
        ImageSource imm5;
        ImageSource imm6;

        public MainWindow()
        {
            InitializeComponent();
            r = new Random();

            imm1 = new BitmapImage(uri1);
            imm2 = new BitmapImage(uri2);
            imm3 = new BitmapImage(uri3);
            imm4 = new BitmapImage(uri4);
            imm5 = new BitmapImage(uri5);
            imm6 = new BitmapImage(uri6);

            stop = true;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (stop)
            {
                stop = false;
                btnStart.Content = "Ferma";
                lblRis.Content = "";
                Sorteggia();
                GiraDadi();
            }
            else
            {
                stop = true;
                btnStart.Content = "Inizia";
                lblRis.Content = i + " + " + l + " = " + (i + l);
            }
        }

        public async void Sorteggia()
        {
            await Task.Run(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lstNum.Items.Clear();
                }));
                while (!stop)
                {
                    i = r.Next(1, 7);
                    l = r.Next(1, 7);
                    int v = i + l;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lstNum.Items.Add(v);
                    }));

                    

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            });
        }

        public async void GiraDadi()
        {
            await Task.Run(()=>
            {
                while (!stop)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        int n = r.Next(1, 7);
                        int m = r.Next(1, 7);

                        switch (n)
                        {
                            case 1:
                                imgDado1.Source = imm1;
                                break;
                            case 2:
                                imgDado1.Source = imm2;
                                break;
                            case 3:
                                imgDado1.Source = imm3;
                                break;
                            case 4:
                                imgDado1.Source = imm4;
                                break;
                            case 5:
                                imgDado1.Source = imm5;
                                break;
                            case 6:
                                imgDado1.Source = imm6;
                                break;
                        }

                        switch (m)
                        {
                            case 1:
                                imgDado2.Source = imm1;
                                break;
                            case 2:
                                imgDado2.Source = imm2;
                                break;
                            case 3:
                                imgDado2.Source = imm3;
                                break;
                            case 4:
                                imgDado2.Source = imm4;
                                break;
                            case 5:
                                imgDado2.Source = imm5;
                                break;
                            case 6:
                                imgDado2.Source = imm6;
                                break;
                        }
                    }));
                    
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                }

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    switch (i)
                    {
                        case 1:
                            imgDado1.Source = imm1;
                            break;
                        case 2:
                            imgDado1.Source = imm2;
                            break;
                        case 3:
                            imgDado1.Source = imm3;
                            break;
                        case 4:
                            imgDado1.Source = imm4;
                            break;
                        case 5:
                            imgDado1.Source = imm5;
                            break;
                        case 6:
                            imgDado1.Source = imm6;
                            break;
                    }

                    switch (l)
                    {
                        case 1:
                            imgDado2.Source = imm1;
                            break;
                        case 2:
                            imgDado2.Source = imm2;
                            break;
                        case 3:
                            imgDado2.Source = imm3;
                            break;
                        case 4:
                            imgDado2.Source = imm4;
                            break;
                        case 5:
                            imgDado2.Source = imm5;
                            break;
                        case 6:
                            imgDado2.Source = imm6;
                            break;
                    }
                }));
                
            });
        }
    }
}
