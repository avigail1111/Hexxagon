using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for Definition2.xaml
    /// </summary>
    public partial class Definition2 : Window
    {
        public string name1;
        public string name2;
        int levelchecked=1;
        int typegame;
        int xx = 0;
        public int x;// מייצג אם נבחר שחקן אחד או שניים
        int flag = 0;/*music don't work*/
        public Definition2()
        {
            InitializeComponent();

            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path2 = Directory.GetParent(path).FullName;
           

            BitmapImage bi2 = new BitmapImage();
            BitmapImage bi3 = new BitmapImage();
            BitmapImage bi4 = new BitmapImage();
            bi2.BeginInit();

            bi2.UriSource = new Uri(path2 + @"/Images/definitionmenu.jpg", UriKind.RelativeOrAbsolute);

            bi2.EndInit();
            this.Background = new ImageBrush(bi2);

            bi3.BeginInit();
            bi3.UriSource = new Uri(path2 + @"/Images/p1.png", UriKind.RelativeOrAbsolute);
            bi3.EndInit();

            imgp1.Source = bi3;

            bi4.BeginInit();
            bi4.UriSource = new Uri(path2 + @"/Images/p2.png", UriKind.RelativeOrAbsolute);
            bi4.EndInit();

            imgp2.Source = bi4;


            BitmapImage ii1 = new BitmapImage();
            BitmapImage ii2 = new BitmapImage();
            BitmapImage ii3 = new BitmapImage();
            BitmapImage ii4 = new BitmapImage();
            BitmapImage ii5 = new BitmapImage();

            ii1.BeginInit();
            ii1.UriSource = new Uri(path2 + @"/Images/levelgame.png", UriKind.RelativeOrAbsolute);
            ii1.EndInit();
            i1.Source = ii1;

            ii2.BeginInit();
            ii2.UriSource = new Uri(path2 + @"/Images/level1t.png", UriKind.RelativeOrAbsolute);
            ii2.EndInit();
            i2.Source = ii2;

            ii3.BeginInit();
            ii3.UriSource = new Uri(path2 + @"/Images/level2t.png", UriKind.RelativeOrAbsolute);
            ii3.EndInit();
            i3.Source = ii3;

            ii4.BeginInit();
            ii4.UriSource = new Uri(path2 + @"/Images/level1.png", UriKind.RelativeOrAbsolute);
            ii4.EndInit();
            i4.Source = ii4;

            ii5.BeginInit();
            ii5.UriSource = new Uri(path2 + @"/Images/level2.png", UriKind.RelativeOrAbsolute);
            ii5.EndInit();
            i5.Source = ii5;
            
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            name1 = "מחשב";
            //name2 = t_1.Text;
            typegame = 1;
            t_2.IsEnabled = false;
            t_2.Text = "מחשב";
            ////label2.Visibility = System.Windows.Visibility.Visible;
            ////radioButton1.Visibility = System.Windows.Visibility.Visible;
            ////radioButton2.Visibility = System.Windows.Visibility.Visible;
            i1.Visibility = System.Windows.Visibility.Visible;
            i2.Visibility = System.Windows.Visibility.Visible;
            i3.Visibility = System.Windows.Visibility.Visible;
            i4.Visibility = System.Windows.Visibility.Visible;
            i5.Visibility = System.Windows.Visibility.Visible;
        }

        private void Rectangle_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            name1 = t_1.Text;
            name2 = t_2.Text;
            //x = 2;
            typegame = 2;
            t_2.Text = "";
            t_1.Text = "";
            t_2.IsEnabled = true; ;
            t_1.IsEnabled = true;
            //label2.Visibility = System.Windows.Visibility.Hidden;
            //radioButton1.Visibility = System.Windows.Visibility.Hidden;
            //radioButton2.Visibility = System.Windows.Visibility.Hidden;

            i1.Visibility = System.Windows.Visibility.Hidden;
            i2.Visibility = System.Windows.Visibility.Hidden;
            i3.Visibility = System.Windows.Visibility.Hidden;
            i4.Visibility = System.Windows.Visibility.Hidden;
            i5.Visibility = System.Windows.Visibility.Hidden;
          
        }

        private void i4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            levelchecked = 1;
        }

        private void i5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            levelchecked = 2;
        }

        private void Rectangle_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            if (t_1.Text == "" || t_2.Text == "")
            {
                MessageBox.Show("!יש להקיש שמות שחקנים");
                return;
            }
            PlayWithFriend friend;
            if (typegame == 1)
            {
                if (levelchecked == 1)
                    friend = new PlayWithFriend(1, t_1.Text, "מחשב", 1);
                else
                    friend = new PlayWithFriend(1, t_1.Text, "מחשב", 2);
            }
            else
                friend = new PlayWithFriend(2, t_1.Text, t_2.Text, 0);
            friend.Show();
            EnterWindow.ss.Stop();
           // this.Hide();
        }
    }
}
