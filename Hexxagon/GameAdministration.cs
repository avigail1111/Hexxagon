using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace Hexxagon
{
    public class GameAdministration
    {
        public static string Player1Name { get; set; }
        public static string Player2Name { get; set; }
        public static int Nikud1 { get; set; }
        public static int Nikud2 { get; set; }
        public static int Tor { get; set; }
        public static int TypeGame  { get; set; }
        public static Board brd { get; set; }
        public static PlayWithFriend mmm;

        public static Image grdP1;
        public static Image grdP2;
        public static void CahngeTor(int addNikud, int subNikud)
        {
            string path, path2;
            Board b = new Board();
          //  Winner win = new Winner();
            BitmapImage bi1 = new BitmapImage();
            //mone_mousedown = 1;
            path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bi1.BeginInit();
            path2 = Directory.GetParent(path).FullName;
            if (Tor == 1)
            {
                Nikud1 += addNikud;
                Nikud2 -= subNikud;
                mmm.lbl1.Content = Nikud1.ToString();
                mmm.lbl2.Content = Nikud2.ToString();
                Tor = 2;
                //לשנות לתמונות המודגשות
              //jjj
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(path2 + @"/Images/nikud.png", UriKind.RelativeOrAbsolute);
                logo.EndInit();
                BitmapImage logob = new BitmapImage();
                logob.BeginInit();
                logob.UriSource = new Uri(path2 + @"/Images/nikudb.png", UriKind.RelativeOrAbsolute);
                logob.EndInit();
                grdP2.Source = logob;
                grdP1.Source = logo;
                    if (Nikud2 == 0)
                    {
                        brd.FillBoard(1);
                        Nikud1 = 58;
                        mmm.lbl1.Content = Nikud1.ToString();
                        SystemSounds.Asterisk.Play();
                        Winner ww = new Winner(1,Player1Name);
                        ww.Show();
                    }
                    else 
                        if (TypeGame == 1)//משחק מול מחשב
                            brd.ComputerPlay();
            }
            else
            {
                Nikud2 += addNikud;
                Nikud1 -= subNikud;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(path2 + @"/Images/nikud.png", UriKind.RelativeOrAbsolute);
                logo.EndInit();
                BitmapImage logob = new BitmapImage();
                logob.BeginInit();
                logob.UriSource = new Uri(path2 + @"/Images/nikudb.png", UriKind.RelativeOrAbsolute);
                logob.EndInit();
                grdP2.Source = logo;
                grdP1.Source = logob;
               
                mmm.lbl1.Content = Nikud1.ToString();
                mmm.lbl2.Content = Nikud2.ToString();
                Tor = 1;
                if (Nikud1 == 0)
                    {
                        brd.FillBoard(2);
                        Nikud2 = 58;
                        mmm.lbl2.Content = Nikud2.ToString();
                        SystemSounds.Asterisk.Play();
                        Winner ww = new Winner(2,Player2Name);
                        ww.Show();
                    }
                 
              
                //win.winner.Source = bi1;
                //win.winner.Stretch = Stretch.Fill;
                //win.Show();//את זה הוספתי כדי שיציג את חלון המנצח
            }
        }

        public static GameAdministration Instance { get; private set; }

        static GameAdministration()
        {
            Instance = new GameAdministration();

        }

    }
}
