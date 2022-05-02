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
using WMPLib;
using Hexxagon.SolveGame;
using System.IO;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for PlayWithFriend.xaml
    /// </summary>
    public partial class PlayWithFriend : Window
    {
        Definition d = new Definition();
        SecondMenu s = new SecondMenu();
        Board bb;
        public int TypeGame { get; set; }
        public PlayWithFriend(int typeGame,string player1name, string player2name, int level)
        {
            InitializeComponent();
            string path, path2;
            BitmapImage bi1 = new BitmapImage();
            path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bi1.BeginInit();
            path2 = Directory.GetParent(path).FullName;
            //Icon.Source = bi1;
            bi1.UriSource = new Uri(path2 + @"/Images/play-8-icon.png", UriKind.RelativeOrAbsolute);
            this.Icon = bi1;
            bi1.EndInit();
            //TextBlock txt = new TextBlock();
            //// txt.FlowDirection = RightToLeft;
            ////txt.Visibility = Visibility.Visible;
            //txt.Text = "שלום רב ל-" + " " + d.name1 + " " + "ו" + d.name2;
            //Image img1 = new Image();
            //Image img2 = new Image();
            TypeGame = typeGame;
             bb = new Board();
             bb.Level = level;
            grdMain.Children.Add(bb);
            Grid.SetRow(bb, 1);
            GameAdministration.Tor = 1;
            GameAdministration.Nikud2 = 3;
            GameAdministration.Nikud1 = 3;
            GameAdministration.mmm = this;
            GameAdministration.brd = bb;
            GameAdministration.TypeGame = TypeGame;
            GameAdministration.Player1Name = player1name;
            GameAdministration.Player2Name = player2name;
            GameAdministration.grdP1 = grdplr1;
            GameAdministration.grdP2 = grdplr2;
            lblplayer1.Content = player1name;
            lblplayer2.Content = player2name;


            BitmapImage bi2 = new BitmapImage();
           
            bi2.BeginInit();
            path2 = Directory.GetParent(path).FullName;
            //Icon.Source = bi1;
            bi2.UriSource = new Uri(path2 + @"/Images/reka.jpg", UriKind.RelativeOrAbsolute);
            this.Background = new ImageBrush(bi2) ;
            bi2.EndInit();

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(path2 + @"/Images/nikud.png", UriKind.RelativeOrAbsolute);
            logo.EndInit();
            BitmapImage logob = new BitmapImage();
            logob.BeginInit();
            logob.UriSource = new Uri(path2 + @"/Images/nikudb.png", UriKind.RelativeOrAbsolute);
            logob.EndInit();
            grdplr1.Source = logob;
            grdplr2.Source = logo;

            logob = new BitmapImage();
            logob.BeginInit();
            logob.UriSource = new Uri(path2 + @"/Images/reddiamond.png", UriKind.RelativeOrAbsolute);
            logob.EndInit();
            image1.Source = logob;
            logob = new BitmapImage();
            logob.BeginInit();
            logob.UriSource = new Uri(path2 + @"/Images/whitediamond.png", UriKind.RelativeOrAbsolute);
            logob.EndInit();
            image2.Source = logob;
            
            BitmapImage ii1 = new BitmapImage();

            ii1.BeginInit();
            ii1.UriSource = new Uri(path2 + @"/Images/רמז.png", UriKind.RelativeOrAbsolute);
            ii1.EndInit();
            imgHint.Source = ii1;


        }

        private void Second_Menu_Click(object sender, RoutedEventArgs e)
        {
            s.ShowDialog();
      
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Solve s = new Solve(bb, GameAdministration.Tor, 2);
            int colSolve = s.ColumnSolve, leftDSolve = s.LeftDiagonalSolve, colSolveSrc = s.ColumnSolveSource, leftDSolvesrc = s.LeftDiagonalSolveSource;
            bb.SignSolve(colSolve, leftDSolve);
        }

     

        //private void music_Click(object sender, RoutedEventArgs e)הפעלת מוזיקה
        //{
        //    WMPLib.WindowsMediaPlayer a = new WMPLib.WindowsMediaPlayer();
        //    a.URL = "song.mp3";
        //    a.controls.play();
        //}
        // בזמן שאחד מבניהם חושב יש תמונה
        //private void fun()
        //{
            ////if(d.x==1) 
            //{
            //img1.Source="C:\Users\Lea\Desktop\Hexxagon\Hexxagon\Hexxagon\Hexxagon\Resources\PC-icon.png";
            // img2.Source="C:\Users\Lea\Desktop\Hexxagon\Hexxagon\Hexxagon\Hexxagon\Resources\Users-icon.png";
            //}
            //else
            //{
            //    //img.Source="C:\Users\Lea\Desktop\Hexxagon\Hexxagon\Hexxagon\Hexxagon\Resources\חושב.png";
            //    //img2.Source.C:\Users\Lea\Desktop\Hexxagon\Hexxagon\Hexxagon\Hexxagon\Resources\User-Clients-icon.png;
            //}
        //}
       
    }
}
