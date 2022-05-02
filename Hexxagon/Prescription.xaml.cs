using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for Prescription.xaml
    /// </summary>
    public partial class Prescription : Window
    {
        public Prescription()
        {
            InitializeComponent();
            string path, path2;
             BitmapImage bi1 = new BitmapImage();
            path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bi1.BeginInit();
            path2 = Directory.GetParent(path).FullName;
            //Icon.Source = bi1;
            bi1.UriSource = new Uri(path2 + @"/Images/logo.png", UriKind.RelativeOrAbsolute);
              bi1.EndInit();


            

            BitmapImage bi2 = new BitmapImage();

            bi2.BeginInit();

            bi2.UriSource = new Uri(path2 + @"/Images/instructions.jpg", UriKind.RelativeOrAbsolute);

            bi2.EndInit();
            this.Background = new ImageBrush(bi2);
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Hide();
            m.Show();
        }

        private void continue_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Definition d = new Definition();
            d.Show();
            this.Close();
           
        }

        private void Grid_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            foreach (Window window in Application.Current.Windows.OfType<MainWindow>())
                ((MainWindow)window).Show();
            this.Close();
            
        }

       
    }
}
