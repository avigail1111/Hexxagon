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
using System.IO;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for Soldier.xaml
    /// </summary>
    public partial class Soldier : UserControl
    {
        public int IDSoldier { get; set; }

        ///****////
        public Soldier(int Id)
        {
            InitializeComponent();
            IDSoldier = Id;
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path2 = Directory.GetParent(path).FullName;// path.Substring(0, path.LastIndexOf('\\'));
            if (IDSoldier == 1)
            {

                bi1.UriSource = new Uri(path2 + @"/Images/reddiamond.png", UriKind.RelativeOrAbsolute);
                //bi1.UriSource = new Uri(@"C:\Users\מירי ויוסי כהן\Desktop\swish\תמונות\c" + Color(circle) + ".png", UriKind.Absolute);

            }
            else
            {
                //לשים תמונה לבנה
                bi1.UriSource = new Uri(path2 + @"/Images/whitediamond.png", UriKind.RelativeOrAbsolute);
            }
            bi1.EndInit();
            image1.Stretch = Stretch.Fill;
            image1.Source = bi1;
            //   grdSoldier.Children.Add(image1);
        }

        ///****///
        //החלפת צבע חייל
        public void ChangeSoldier()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path2 = Directory.GetParent(path).FullName;
            if (IDSoldier == 1)
            {
                bi1.UriSource = new Uri(path2 + @"/Images/whitediamond.png", UriKind.RelativeOrAbsolute);
                //bi1.UriSource = new Uri(@"C:\Users\מירי ויוסי כהן\Desktop\swish\תמונות\c" + Color(circle) + ".png", UriKind.Absolute);
                IDSoldier = 2;
            }
            else
            {
                //לשים תמונה לבנה
                bi1.UriSource = new Uri(path2 + @"/Images/reddiamond.png", UriKind.RelativeOrAbsolute);
                IDSoldier = 1;
            }
            bi1.EndInit();
            image1.Stretch = Stretch.Fill;
            image1.Source = bi1;
        }
    }
}
