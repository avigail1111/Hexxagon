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
using System.Media;

namespace Hexxagon
{
    /// <summary>
    /// Interaction logic for HexxagonPart.xaml
    /// </summary>
    public partial class HexxagonPart : UserControl
    {

        public int Column { get; set; }
        public int LeftDiagonal { get; set; }
        public int RightDiagonal { get; set; }
        public bool IsEmpty { get; set; }
        public int IsSigned { get; set; }
        public Soldier HexxagonSoldier { get; set; }
        public Board MyBoard { get; set; }


        public HexxagonPart(int col, int leftd, int rightd)
        {
            InitializeComponent();
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path2 = Directory.GetParent(path).FullName;
            bi1.UriSource = new Uri(path2 + @"/Images/HexxagonEmpty.png", UriKind.RelativeOrAbsolute);
            bi1.EndInit();
            this.Background = new ImageBrush(bi1);
            IsEmpty = true;
            HexxagonSoldier = null;
            Column = col;
            LeftDiagonal = leftd;
            RightDiagonal = rightd;
            IsSigned = 0;
        }

        // הנחת החייל במשושה
        ///***////
        public void PutSoldier(Soldier s)
        {
            // הנחה ויזואלית

            IsEmpty = false;
            HexxagonSoldier = s;
            grdHex.Children.Add(s);// איך הוא יודע לאיזה מיקום להוסיף אותו בגריד

        }

        public void ReplaceSoldier()
        {
            HexxagonSoldier.ChangeSoldier();
        }
        public void DeleteSoldier()
        {
            if (HexxagonSoldier != null)
            {
                IsEmpty = true;
                grdHex.Children.Remove(HexxagonSoldier);
                HexxagonSoldier = null;
            }
        }
        // סימון
        public void SignHexxagonal(int outOrIn)
        {

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path2 = Directory.GetParent(path).FullName;
            // 1= in
            if (outOrIn == 1)
            {
                //לשים תמונה של משושה עם מסגרת ירוקה
                bi1.UriSource = new Uri(path2 + @"/Images/העתק.png", UriKind.RelativeOrAbsolute);
                IsSigned = 1;
            }
            // 2= out
            //add picture of copy
            else
            {
                bi1.UriSource = new Uri(path2 + @"/Images/שכפול.png", UriKind.RelativeOrAbsolute);
                IsSigned = 2;

            }
            bi1.EndInit();
            this.Background = new ImageBrush(bi1);

        }

        public void UnSignHexxagonal()
        {

            IsSigned = 0;
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            string path2 = Directory.GetParent(path).FullName;
            bi1.UriSource = new Uri(path2 + @"/Images/HexxagonEmpty.png", UriKind.RelativeOrAbsolute);
            bi1.EndInit();
            this.Background = new ImageBrush(bi1);

        }
        // public static int mone_mousedown=1;
        public void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (mone_mousedown % 2 == 0)//אם זה לא פעם ראשונה שהוא לוחץ הוא מסמן או לא מסמן את האפשרויות
            //{
            //    MyBoard.UnSignHexaagonals();
            //}
            //else
            //{
            //    MyBoard.SignHexaagonals(this);
            //}
            //mone_mousedown++;

            int nik = 0;
            if (IsSigned != 0)
            {
                // IsEmpty=false;
                int idSol = MyBoard.LastChecked.HexxagonSoldier.IDSoldier;
                PutSoldier(new Soldier(idSol));
                if (IsSigned == 2)
                {

                    MyBoard.LastChecked.DeleteSoldier();
                }
                else
                    nik++;
                MyBoard.UnSignHexaagonals();
                int nikChanged = MyBoard.ExchangeinHex(this);
                //קול כאשר מעביר את השחקן
                SystemSounds.Asterisk.Play();
                GameAdministration.CahngeTor(nik + nikChanged, nikChanged);


            }
            else
            {
                if (!IsEmpty && HexxagonSoldier.IDSoldier == GameAdministration.Tor)
                {
                    if (MyBoard.LastChecked == this)
                    {
                        MyBoard.UnSignHexaagonals();
                    }
                    else
                    {
                        MyBoard.UnSignHexaagonals();
                        MyBoard.SignHexaagonals(this);
                        //קול כאשר מסמן סביבו
                        SystemSounds.Asterisk.Play();
                    }
                }
            }
            // if(mone_mousedown>1)

        }

        public void PutComputer(HexxagonPart src)
        {
            int nik = 0;
            PutSoldier(new Soldier(2));
            if (Math.Abs(double.Parse((Column - src.Column).ToString())) == 2 || Math.Abs(double.Parse((LeftDiagonal - src.LeftDiagonal).ToString())) == 2)
                src.DeleteSoldier();
            else
                nik++;
            int nikChanged = MyBoard.ExchangeinHex(this);
            GameAdministration.CahngeTor(nik + nikChanged, nikChanged);
        }
    }
}
