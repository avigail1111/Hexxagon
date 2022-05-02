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
    /// Interaction logic for Winner.xaml
    /// </summary>
    public partial class Winner : Window
    {
        public Winner(int numplayer,string nameplayer)
        {
            InitializeComponent();
            string path, path2;
            BitmapImage bi1 = new BitmapImage();
            path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bi1.BeginInit();
            path2 = Directory.GetParent(path).FullName;
            //Icon.Source = bi1;
            if (numplayer == 1)
            {
                bi1.UriSource = new Uri(path2 + @"/Images/02-lion-icon.png", UriKind.RelativeOrAbsolute);
                //bi1.UriSource = new Uri(@"C:\Users\מירי ויוסי כהן\Desktop\swish\תמונות\c" + Color(circle) + ".png", UriKind.Absolute);
                
            }
            else
            {
                bi1.UriSource = new Uri(path2 + @"/Images/Tiger-icon.png", UriKind.RelativeOrAbsolute);
                //לשים תמונה לבנה
              
               
            }
           // bi1.UriSource = new Uri(path2 + @"/Images/גביע.png", UriKind.RelativeOrAbsolute);
         
           
            bi1.EndInit();
            gvia.Source = bi1;
            lbname.Content = nameplayer;

        }
    }
}
