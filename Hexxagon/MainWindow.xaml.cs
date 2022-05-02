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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        public MainWindow()
        {
            InitializeComponent();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path2 = Directory.GetParent(path).FullName;
            bi1.UriSource = new Uri(path2 + @"/Images/mainmenu.jpg", UriKind.RelativeOrAbsolute);

            
            bi1.EndInit();
            this.Background = new ImageBrush(bi1);

        }
        //הפנייה לחלון של הוראות
     
      
  //      Bitmap bmp = new Bitmap(
  //System.Reflection.Assembly.GetEntryAssembly().
  //  GetManifestResourceStream("Hexxagon.Resources.logo.png"));
        
        // Display a message box asking users if they  want to exit the application.
        // if יש טעות ב
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("?האם אתה בטוח שברצונך לצאת מהמשחק", "יציאה", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
                //this.Close();
        }
        //מציג את החלון של ההוראות
        private void button3_Click(object sender, RoutedEventArgs e)
        {
           
        }
        //.def.מפנה לחלון של ההגדרות
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
/* בהטענת הדף הראשי מיד יופעל המוסיקה*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("?האם אתה בטוח שברצונך לצאת מהמשחק", "יציאה", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void Grid_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Prescription presc = new Prescription();
            presc.Show();
            this.Hide();
        }

        private void Grid_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Definition2 defi = new Definition2();
            defi.Show();
            this.Hide();
        }

       
    }
}
