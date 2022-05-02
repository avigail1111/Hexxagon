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
    /// Interaction logic for SecondMenu.xaml
    /// </summary>
    public partial class SecondMenu : Window
    {
        public SecondMenu()
        {
            InitializeComponent();
             string path, path2;
             BitmapImage bi1 = new BitmapImage();
            path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bi1.BeginInit();
            path2 = Directory.GetParent(path).FullName;
            //Icon.Source = bi1;
            bi1.UriSource = new Uri(path2 + @"/Images/logo.png", UriKind.RelativeOrAbsolute);
            image1.Source = bi1;
            bi1.UriSource = new Uri(path2 + @"/Images/רמקול 1.png", UriKind.RelativeOrAbsolute);
            button1.Source = bi1; 
            bi1.EndInit();
        
        }
        MainWindow m = new MainWindow();

        private void button1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
//סוגר את חלון "התפריט המשני"וחוזר למשחק
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        //פותחת משחק חדש
        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();//האם מספיק להחביא אותו או שצריך לסגור אותו
            m.Show();
        }
    }
}
