using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {

        DispatcherTimer tmr = new DispatcherTimer();
      public static  Sound1 ss;// = new Sound1();
        public EnterWindow()
        {
            InitializeComponent();
              string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
              ss = new Sound1();
            string path2 = Directory.GetParent(path).FullName;


            BitmapImage bi2 = new BitmapImage();

            bi2.BeginInit();
       
            bi2.UriSource = new Uri(path2 + @"/Images/logo.png", UriKind.RelativeOrAbsolute);
           
            bi2.EndInit();
            this.Background = new ImageBrush(bi2);
            ss.Search(path2 + @"/Music/01 - A Way of Life.mp3");
            ss.Start();
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Interval = new TimeSpan(10000000);
            tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            Thread.Sleep(2000);
            mw.Show();
            
            this.Hide();
            tmr.Stop();
        }
    }
}
