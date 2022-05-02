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
using Hexxagon.SolveGame;
using System.Windows.Threading;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        List<HexxagonPart> hexxagonalParts = new List<HexxagonPart>();
        public int Level { get; set; }
        DispatcherTimer tmr = new DispatcherTimer();
        public List<HexxagonPart> HexxagonalParts
        {
            get { return hexxagonalParts; }
            set { hexxagonalParts = value; }
        }
        public HexxagonPart LastChecked { get; set; }

        public Board()
        {
            InitializeComponent();
            LastChecked = null;
            BuildBoard();
            InitSix();
            tmr.Interval = new TimeSpan(1000);
            tmr.Tick += new EventHandler(tmr_Tick);
            ttt.Interval = new TimeSpan(1000000);
            ttt.Tick += new EventHandler(ttt_Tick);
        }

       

     
        //מקבלת מספר שחקן מנצח, ועוברת על כל רשימת המשושים ,ובודקת מי ריק-ואליו מציבה את החייל המנצח
        public void FineGame(int MisWin)
        {
            for (int i = 0; i < hexxagonalParts.Count; i++)
            {
                if (hexxagonalParts[i].IsEmpty == true)
                {
                    Soldier s = new Soldier(MisWin);
                    hexxagonalParts[i].PutSoldier(s);
                }
            }
        }
        //*****////
        private void InitSix()
        {
            //לגשת לשש המשוושים מתוך הרשימה שבקצצות
            Soldier s1 = new Soldier(1);
            Soldier s2 = new Soldier(2);
            Soldier s3 = new Soldier(2);
            Soldier s4 = new Soldier(1);
            Soldier s5 = new Soldier(1);
            Soldier s6 = new Soldier(2);
            // var p1 = hexxagonalParts.Where(x => x.Column == 1).Where(y => y.LeftDiagonal == 1);
            // HexxagonPart p11 = p1 as HexxagonPart;
            // p11.PutSoldier(s1);
            hexxagonalParts[0].PutSoldier(s1);
            hexxagonalParts[4].PutSoldier(s2);
            hexxagonalParts[26].PutSoldier(s3);
            hexxagonalParts[34].PutSoldier(s4);
            hexxagonalParts[56].PutSoldier(s5);
            hexxagonalParts[60].PutSoldier(s6);
            hexxagonalParts[22].Visibility = Visibility.Collapsed;
            hexxagonalParts[29].Visibility = Visibility.Collapsed;
            hexxagonalParts[39].Visibility = Visibility.Collapsed;
            //var p2 = hexxagonalParts.Where(x => x.Column == 1).Where(y => y.LeftDiagonal == 5);
            //HexxagonPart p22 = p2 as HexxagonPart;
            //p22.PutSoldier(s2);
            //var p3 = hexxagonalParts.Where(x => x.Column == 5).Where(y => y.RightDiagonal == 9);
            //HexxagonPart p33 = p3 as HexxagonPart;
            //p33.PutSoldier(s3);
            //var p4 = hexxagonalParts.Where(x => x.Column == 5).Where(y => y.LeftDiagonal == 1);
            //HexxagonPart p44 = p4 as HexxagonPart;
            //p44.PutSoldier(s4);
            //var p5 = hexxagonalParts.Where(x => x.Column == 9).Where(y=>y.RightDiagonal==1);
            //HexxagonPart p55 = p5 as HexxagonPart;
            //p55.PutSoldier(s5);
            //var p6 = hexxagonalParts.Where(x => x.Column == 9).Where(y => y.RightDiagonal == 9);
            //HexxagonPart p66 = p6 as HexxagonPart;
            //p66.PutSoldier(s6);
        }
        // StackPanel stp;
       // Winner win = new Winner();

        public void BuildBoard()
        {
            int n = 5, LeftD = 1, RightD = 5;
            int xloc = 1, yloc = 5;
            for (int col = 1; col <= 9; col++)
            {
                //  stp = new StackPanel();
                // stp.Margin = new Thickness(0, 43, 0, 0);                
                BuildColumn(n, col, LeftD, RightD, xloc, yloc);
                xloc += 2;
                // stpAll.Children.Add(stp);
                if (col < 5)
                {
                    n++;
                    yloc--;
                }
                else
                {
                    n--;
                    yloc++;
                }
                if (col >= 5)
                    LeftD++;
                else
                    RightD--;


                // drowColumn(4, 3, 1);



            }
        }

        ///****////
        private void BuildColumn(int n, int col, int LeftD, int RightD, int xloc, int yloc)
        {
            for (int i = 0; i < n; i++)
            {
                HexxagonPart hex = new HexxagonPart(col, LeftD, RightD);
                hex.MyBoard = this;
                hexxagonalParts.Add(hex);
                grdBoard.Children.Add(hex);
                Grid.SetColumn(hex, xloc);
                Grid.SetRow(hex, yloc);
                Grid.SetRowSpan(hex, 2);
                Grid.SetColumnSpan(hex, 2);
                yloc += 2;
                //   stp.Children.Add(hex);
                LeftD++;
                RightD++;

                // הוספת המשושה ויזואלית ללוח
            }
        }
        List<HexxagonPart> inHex = new List<HexxagonPart>();
        List<HexxagonPart> outHex = new List<HexxagonPart>();
        public void SignHexaagonals(HexxagonPart hex)
        {
            LastChecked = hex;
            inHex = new List<HexxagonPart>();
            outHex = new List<HexxagonPart>();
            var h1 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);

            if (h1 != null && h1.Count() > 0 && h1.ElementAt(0).IsEmpty)
                inHex.Add(h1.ElementAt(0));
            var h2 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal);//
            if (h2 != null && h2.Count() > 0 && (h2.ElementAt(0)).IsEmpty)
                inHex.Add(h2.ElementAt(0));
            var h3 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h3 != null && h3.Count() > 0 && (h3.ElementAt(0)).IsEmpty)
                inHex.Add(h3.ElementAt(0));
            var h4 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h4 != null && h4.Count() > 0 && (h4.ElementAt(0)).IsEmpty)
                inHex.Add(h4.ElementAt(0));
            var h5 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h5 != null && h5.Count() > 0 && h5.Count() > 0 && (h5.ElementAt(0)).IsEmpty)
                inHex.Add(h5.ElementAt(0));
            var h6 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h6 != null && h6.Count() > 0 && (h6.ElementAt(0)).IsEmpty)
                inHex.Add(h6.ElementAt(0));
            var h7 = hexxagonalParts.Where(x => x.Column == hex.Column - 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 2);
            if (h7 != null && h7.Count() > 0 && (h7.ElementAt(0)).IsEmpty)
                outHex.Add(h7.ElementAt(0));
            var h8 = hexxagonalParts.Where(x => x.Column == hex.Column - 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h8 != null && h8.Count() > 0 && (h8.ElementAt(0)).IsEmpty)
                outHex.Add(h8.ElementAt(0));
            var h9 = hexxagonalParts.Where(x => x.Column == hex.Column - 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h9 != null && h9.Count() > 0 && (h9.ElementAt(0)).IsEmpty)
                outHex.Add(h9.ElementAt(0));
            var h10 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h10 != null && h10.Count() > 0 && (h10.ElementAt(0)).IsEmpty)
                outHex.Add(h10.ElementAt(0));
            var h11 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 2);
            if (h11 != null && h11.Count() > 0 && (h11.ElementAt(0)).IsEmpty)
                outHex.Add(h11.ElementAt(0));
            var h12 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 2);
            if (h12 != null && h12.Count() > 0 && (h12.ElementAt(0)).IsEmpty)
                outHex.Add(h12.ElementAt(0));
            var h13 = hexxagonalParts.Where(x => x.Column == hex.Column + 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 2);
            if (h13 != null && h13.Count() > 0 && (h13.ElementAt(0)).IsEmpty)
                outHex.Add(h13.ElementAt(0));
            var h14 = hexxagonalParts.Where(x => x.Column == hex.Column + 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h14 != null && h14.Count() > 0 && (h14.ElementAt(0)).IsEmpty)
                outHex.Add(h14.ElementAt(0));
            var h15 = hexxagonalParts.Where(x => x.Column == hex.Column + 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h15 != null && h15.Count() > 0 && (h15.ElementAt(0)).IsEmpty)
                outHex.Add(h15.ElementAt(0));
            var h16 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h16 != null && h16.Count() > 0 && (h16.ElementAt(0)).IsEmpty)
                outHex.Add(h16.ElementAt(0));
            var h17 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 2);
            if (h17 != null && h17.Count() > 0 && (h17.ElementAt(0)).IsEmpty)
                outHex.Add(h17.ElementAt(0));
            var h18 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 2);
            if (h18 != null && h18.Count() > 0 && (h18.ElementAt(0)).IsEmpty)
                outHex.Add(h18.ElementAt(0));

            for (int i = 0; i < inHex.Count; i++)
            {
                inHex[i].SignHexxagonal(1);
            }
            for (int i = 0; i < outHex.Count; i++)
            {
                outHex[i].SignHexxagonal(2);
            }
        }

        public void UnSignHexaagonals()
        {
            for (int i = 0; i < inHex.Count; i++)
            {
                inHex[i].UnSignHexxagonal();
            }
            for (int i = 0; i < outHex.Count; i++)
            {
                outHex[i].UnSignHexxagonal();
            }
        }
        //הפונקציה אוספת את כל השישה משושים סביבו, ואם יש בהם משושים שונים מהמשושה שנלחץ אז הם משתנים לצבעו
        public int ExchangeinHex(HexxagonPart hex)
        {
            List<HexxagonPart> lstin = new List<HexxagonPart>();
            var h1 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h1 != null && h1.Count() > 0 && !(h1.ElementAt(0).IsEmpty))
                lstin.Add(h1.ElementAt(0));
            var h2 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h2 != null && h2.Count() > 0 && !(h2.ElementAt(0)).IsEmpty)
                lstin.Add(h2.ElementAt(0));
            var h3 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h3 != null && h3.Count() > 0 && !(h3.ElementAt(0)).IsEmpty)
                lstin.Add(h3.ElementAt(0));
            var h4 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h4 != null && h4.Count() > 0 && !(h4.ElementAt(0)).IsEmpty)
                lstin.Add(h4.ElementAt(0));
            var h5 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h5 != null && h5.Count() > 0 && !(h5.ElementAt(0)).IsEmpty)
                lstin.Add(h5.ElementAt(0));
            var h6 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h6 != null && h6.Count() > 0 && !(h6.ElementAt(0)).IsEmpty)
                lstin.Add(h6.ElementAt(0));
            int mone = 0;
            foreach (HexxagonPart item in lstin)
            {//אם מלא וגם הזהות של המשושים סביבו הם שונים מהזהות שלו
                if (item.IsEmpty == false && item.HexxagonSoldier.IDSoldier != hex.HexxagonSoldier.IDSoldier)
                {
                    item.ReplaceSoldier();
                    mone++;
                }
            }
            return mone;
        }
        DispatcherTimer ttt = new DispatcherTimer();
        HexxagonPart hextimer;
        int monetmr;
        public void SignSolve(int colSolve, int leftDSolve)
        {
            var puthex = hexxagonalParts.Where(x => x.Column == colSolve).Where(y => y.LeftDiagonal == leftDSolve);
           // var src = hexxagonalParts.Where(x => x.Column == colSolveSrc).Where(y => y.LeftDiagonal == leftDSolvesrc);
            hextimer =  puthex.ElementAt(0);
            monetmr = 0;
            ttt.Start();

        }
        void ttt_Tick(object sender, EventArgs e)
        {
            if (monetmr % 2 == 0)
            {
                hextimer.Visibility = System.Windows.Visibility.Hidden;
               
            }
            else
            {
                hextimer.Visibility = System.Windows.Visibility.Visible;
            }
            monetmr++;
            if (monetmr == 12)
                ttt.Stop();
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            Solve s = new Solve(this, 2,Level);
            int colSolve = s.ColumnSolve, leftDSolve = s.LeftDiagonalSolve, colSolveSrc = s.ColumnSolveSource, leftDSolvesrc = s.LeftDiagonalSolveSource;

            var puthex = hexxagonalParts.Where(x => x.Column == colSolve).Where(y => y.LeftDiagonal == leftDSolve);
            var src = hexxagonalParts.Where(x => x.Column == colSolveSrc).Where(y => y.LeftDiagonal == leftDSolvesrc);
            puthex.ElementAt(0).PutComputer(src.ElementAt(0));
            tmr.Stop();
        }
      
        public void ComputerPlay()
        {
            tmr.Start();
           
        }

        public void FillBoard(int numplayer)
        {
            foreach (HexxagonPart  item in hexxagonalParts)
            {
                if (item.IsEmpty)
                {
                    item.PutSoldier(new Soldier(numplayer));
                }
            }
        }

        //internal void UnSignHexxagonal()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
