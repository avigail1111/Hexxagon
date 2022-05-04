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

using System.Windows.Threading;
using Microsoft.Win32;
using System.Media;
using System.IO;
//using WMPLib;
//using System.Media.SystemSounds;


namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for Definition.xaml
    /// </summary>
    public partial class Definition : Window
    {
        public string name1;
        public string name2;
        int xx = 0;
        public int x;// מייצג אם נבחר שחקן אחד או שניים
        int flag = 0;/*music don't work*/
        public Definition()
        {
            InitializeComponent();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path2 = Directory.GetParent(path).FullName;
            //i1.Visibility = System.Windows.Visibility.Hidden;
            //i2.Visibility = System.Windows.Visibility.Hidden;
            //i3.Visibility = System.Windows.Visibility.Hidden;
            //i4.Visibility = System.Windows.Visibility.Hidden;
            //i5.Visibility = System.Windows.Visibility.Hidden;
            //bi1.UriSource = new Uri(path2 + @"/Images/User-icon-setting.png", UriKind.RelativeOrAbsolute);
            //UserIconSettining.Source = bi1;
            //UserIconSettining.Stretch = Stretch.Fill;
            //bi1.UriSource = new Uri(path2 + @"/Images/רמקול 1.png", UriKind.RelativeOrAbsolute);
            //רמקול.Source = bi1;
            //bi1.UriSource = new Uri(path2 + @"/Images/User-Clients-icon.png", UriKind.RelativeOrAbsolute);
            //UserClientsIcon.Source = bi1;
            //bi1.UriSource = new Uri(path2 + @"/Images/PC-icon.png", UriKind.RelativeOrAbsolute);
            //com.Source = bi1;
            //bi1.EndInit();

            BitmapImage bi2 = new BitmapImage();

            bi2.BeginInit();

            bi2.UriSource = new Uri(path2 + @"/Images/definitionmenu.jpg", UriKind.RelativeOrAbsolute);

            bi2.EndInit();
            this.Background = new ImageBrush(bi2);
        }
        //******************************************************************************************//


      


        //void timer_Tick(object sender, EventArgs e)
        //{
        //        if(mediaPlayer.Source != null)
        //                lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        //        else
        //                lblStatus.Content = "No file selected...";
        //}

      
        //משחק ב-2 שחקנים 2
        private void choice1_Checked(object sender, RoutedEventArgs e)
        {//דגל לפציון הפעם ה-1
            if (xx != 0)
            {
                name1 = t_1.Text;
                name2 = t_2.Text;
                //x = 2;
                typegame = 2;
                t_2.Text = "";
                
                t_2.IsEnabled = true; ;
                t_1.IsEnabled = true;
                //label2.Visibility = System.Windows.Visibility.Hidden;
                //radioButton1.Visibility = System.Windows.Visibility.Hidden;
                //radioButton2.Visibility = System.Windows.Visibility.Hidden;
            }
            xx = 1;

        }

        //בלחיצה על כפתור התחל משחק 
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (t_1.Text == "" || t_2.Text == "")
            {
                MessageBox.Show("!יש להקיש שמות שחקנים");
                return;
            }
            PlayWithFriend friend;
            if (typegame==1)
            {
                if(levelchecked==1)
                friend = new PlayWithFriend(1, t_1.Text, "מחשב",1);
                else
                    friend = new PlayWithFriend(1, t_1.Text, "מחשב", 2);
            }
            else
                friend = new PlayWithFriend(2, t_1.Text, t_2.Text,0);
            friend.Show();
            this.Hide();
            EnterWindow.ss.Stop();
            
        }
        //מגדיל את הכיתוב 'התחל' כאשר נכנס לתחום הכפתור
     


        private void music_Click(object sender, RoutedEventArgs e)
        {
            WMPLib.WindowsMediaPlayer a = new WMPLib.WindowsMediaPlayer();
            if (flag == 0)
            {
                a.URL = "song.mp3";
                a.controls.play();
                flag = 1;
            }
            else
            {
                a.controls.stop();
                flag = 0;
            }
        }
        /*בלחיצה על שחקן מול מחשב*/
        private void choice2_Checked_1(object sender, RoutedEventArgs e)
        {
            //x = 1;
            name1 = "מחשב";
            name2 = t_1.Text;
            typegame = 1;
            t_2.IsEnabled = false;
            t_2.Text = "מחשב";
            //label2.Visibility = System.Windows.Visibility.Visible;
            //radioButton1.Visibility = System.Windows.Visibility.Visible;
            //radioButton2.Visibility = System.Windows.Visibility.Visible;
        }

        //להוסיף פקד שנותן אפשרות לבחירת רמת קושי
        //

        private MediaPlayer mediaPlayer = new System.Windows.Media.MediaPlayer();
        int levelchecked = 1;
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (t_1.Text == "" || t_2.Text == "")
            {
                MessageBox.Show("!יש להקיש שמות שחקנים");
                return;
            }
            PlayWithFriend friend;
            if (typegame == 1)
            {
               
                    friend = new PlayWithFriend(1, t_1.Text, "מחשב", levelchecked);
                
            }
            else
                friend = new PlayWithFriend(2, t_1.Text, t_2.Text, 0);
            friend.Show();
            EnterWindow.ss.Stop();
            this.Hide();
        }
        int typegame = 1;
        private void Grid_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            name1 = "מחשב";
            name2 = t_1.Text;
            typegame = 1;
            t_2.IsEnabled = false;
            t_2.Text = "מחשב";
            //label2.Visibility = System.Windows.Visibility.Visible;
            //radioButton1.Visibility = System.Windows.Visibility.Visible;
            //radioButton2.Visibility = System.Windows.Visibility.Visible;
            i1.Visibility = System.Windows.Visibility.Visible;
                 i2.Visibility = System.Windows.Visibility.Visible;
             i3.Visibility = System.Windows.Visibility.Visible;
             i4.Visibility = System.Windows.Visibility.Visible;
             i5.Visibility = System.Windows.Visibility.Visible;
      
        }

        private void Grid_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            //דגל לפציון הפעם ה-1
            if (xx != 0)
            {
                name1 = t_1.Text;
                name2 = t_2.Text;
                //x = 2;

                t_2.Text = "";

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
            xx = 1;
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            levelchecked = 1;
        }

        private void i3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            levelchecked = 2;
        }
        //private void button1_Click(object sender, RoutedEventArgs e)
        //{

        //                //OpenFileDialog openFileDialog = new OpenFileDialog();
        //                //openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
        //                //if(openFileDialog.ShowDialog() == true)
        //                //{
        //                        //mediaPlayer.Open(new Uri());
        //                        //mediaPlayer.Play();
        //                //}
        //     DispatcherTimer timer = new DispatcherTimer();
        //                timer.Interval = TimeSpan.FromSeconds(1);
        //             //   timer.Tick += timer_Tick;
        //                timer.Start();


        //}

    }
      }

    


