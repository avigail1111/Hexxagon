using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hexxagon.SolveGame
{
    class BoardSolve
    {
        List<HexxagonPartSolve> hexxagonalParts = new List<HexxagonPartSolve>();
        public   HexxagonPartSolve PutHex;
        public HexxagonPartSolve SourcePutHex;
        public int Nikud1 { get; set; }
        public int Nikud2 { get; set; }
// פונקציה שמקבלת לוח ויזואלי ומעתיקה את התוכן הספציפי ללוח חדש לוגי ומחזירה אותו
        public static BoardSolve ConvertToBoardSolve(Board b)
        {
            BoardSolve newb = new BoardSolve();
            foreach (HexxagonPart  item in b.HexxagonalParts)
            {
                newb.hexxagonalParts.Add(HexxagonPartSolve.ConvertHexxagonPartSolve(item));
            }
            newb.Nikud1 = GameAdministration.Nikud1;
            newb.Nikud2 = GameAdministration.Nikud2;
            return newb;
        }
        //  פונקציה שמייצרת לוח לוגי ומעתיקה אליו את הלוח הלוגי שהעתיק מהלוח הויזואלי 
        public BoardSolve CopyBoardSolve()
        {
            BoardSolve cpybrd = new BoardSolve();
            foreach (HexxagonPartSolve  item in hexxagonalParts)
            {
                cpybrd.hexxagonalParts.Add(item.CopyHexxagonalPartSolve());
            }
            cpybrd.Nikud1 = Nikud1;
            cpybrd.Nikud2 = Nikud2;
            return cpybrd;
        }
//פונקציה המקבלת סוג שחקן ומחזירה רשימה של לוחות לוגיים 
        public List<BoardSolve> AllOptions(int idSoldier)
        { 
           // hexxagonalParts.Select(x=> x.IsEmpty==true)
            List<BoardSolve> lstAllOptions = new List<BoardSolve>();
            //רשימה של משושים לוגים שמלאים בסוג שחקן ששלחתי לפונקציה
            var hexOfSoldier = hexxagonalParts.Where(x => x.IsEmpty == false).Where(y => y.HexxagonSoldierId == idSoldier);
            // עובר על רשימת המשושים הנ"ל  
            for (int i = 0; i < hexOfSoldier.Count(); i++)
            {
                // ובונה רשימה של משושים לוגים שנמצאים מסביב למשושה ברשימה הנ"ל 
                List<HexxagonPartSolve> around = AroundHexaagonals(hexOfSoldier.ElementAt(i));
                //עובר על רשימת המשושים הלוגים שסביב כל משושה שהסוג שחקן שבו זהה לסוג שחקן שנשלח לפונקציה
                foreach (HexxagonPartSolve item in around)
                {//לוח לוגי שהועתק מומר מויזואלי
                    BoardSolve copyBoard = CopyBoardSolve();
                    // שם במשושה לוגי את המשושה הנוכחי 
                   //מכניס למשושה לוגי את המשושה שנמצא באותו מקום    
                   var putHex= copyBoard.hexxagonalParts.Where(x => x.Column == item.Column).Where(y => y.LeftDiagonal == item.LeftDiagonal);
                   // הנחת החייל במשושה
                   putHex.ElementAt(0).HexxagonSoldierId = idSoldier;
                   putHex.ElementAt(0).IsEmpty = false ;
                   copyBoard.ExchangeinHex(putHex.ElementAt(0));
                   copyBoard.PutHex = putHex.ElementAt(0);
                   copyBoard.SourcePutHex = hexOfSoldier.ElementAt(i);
                    //מוסיפה לרשימה של הלוחות הלוגים את הלוח לאחר השינויים
                   lstAllOptions.Add(copyBoard);
                }
            }

            return lstAllOptions;
        }
//הפונקציה מקבלת סוג שחקן ומחזירה את הפרש הניקוד בינו לבין השחקן השני(בשביל לאמוד את ההפרש הגבוה-השווה ביות)ר
        public int EvalBoard(int idSoldier)
        {
            if (idSoldier == 1)
                return Nikud1 - Nikud2;
            return Nikud2 - Nikud1;
           // int counter1=0,counter2=0
        }
        //הפונקציה אוספת את כל השישה משושים סביבו, ואם יש בהם משושים שונים מהמשושה שנלחץ אז הם משתנים לצבעו
        public void ExchangeinHex(HexxagonPartSolve hex)
        {
            List<HexxagonPartSolve> lstin = new List<HexxagonPartSolve>();
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
            foreach (HexxagonPartSolve item in lstin)
            {//אם מלא וגם הזהות של המשושים סביבו הם שונים מהזהות שלו
                if (item.IsEmpty == false && item.HexxagonSoldierId != hex.HexxagonSoldierId)
                {
                    item.HexxagonSoldierId = hex.HexxagonSoldierId;
                    mone++;
                }
            }
            //הפונקציה מעדכנת את הניקוד לפי סוג שחקן שנשלח
            if (hex.HexxagonSoldierId == 1)
            {
                Nikud1 += mone;
                Nikud2 -= mone;
            }
            else
            {
                Nikud2 += mone;
                Nikud1 -= mone;
            }

           
        }
        //הפונקציה מקבלת משושה לוגי ומחזירה רשימה של משושים לוגים שנמצאים סביבו
        public List<HexxagonPartSolve> AroundHexaagonals(HexxagonPartSolve hex)
        {
            List<HexxagonPartSolve> lstAroound = new List<HexxagonPartSolve>();
           
            var h1 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);

            if (h1 != null && h1.Count() > 0 && h1.ElementAt(0).IsEmpty)
                lstAroound.Add(h1.ElementAt(0));
            var h2 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h2 != null && h2.Count() > 0 && (h2.ElementAt(0)).IsEmpty)
                lstAroound.Add(h2.ElementAt(0));
            var h3 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h3 != null && h3.Count() > 0 && (h3.ElementAt(0)).IsEmpty)
                lstAroound.Add(h3.ElementAt(0));
            var h4 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h4 != null && h4.Count() > 0 && (h4.ElementAt(0)).IsEmpty)
                lstAroound.Add(h4.ElementAt(0));
            var h5 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h5 != null && h5.Count() > 0 && h5.Count() > 0 && (h5.ElementAt(0)).IsEmpty)
                lstAroound.Add(h5.ElementAt(0));
            var h6 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h6 != null && h6.Count() > 0 && (h6.ElementAt(0)).IsEmpty)
                lstAroound.Add(h6.ElementAt(0));
            var h7 = hexxagonalParts.Where(x => x.Column == hex.Column - 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 2);
            if (h7 != null && h7.Count() > 0 && (h7.ElementAt(0)).IsEmpty)
                lstAroound.Add(h7.ElementAt(0));
            var h8 = hexxagonalParts.Where(x => x.Column == hex.Column - 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h8 != null && h8.Count() > 0 && (h8.ElementAt(0)).IsEmpty)
                lstAroound.Add(h8.ElementAt(0));
            var h9 = hexxagonalParts.Where(x => x.Column == hex.Column - 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h9 != null && h9.Count() > 0 && (h9.ElementAt(0)).IsEmpty)
                lstAroound.Add(h9.ElementAt(0));
            var h10 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h10 != null && h10.Count() > 0 && (h10.ElementAt(0)).IsEmpty)
                lstAroound.Add(h10.ElementAt(0));
            var h11 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 2);
            if (h11 != null && h11.Count() > 0 && (h11.ElementAt(0)).IsEmpty)
                lstAroound.Add(h11.ElementAt(0));
            var h12 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 2);
            if (h12 != null && h12.Count() > 0 && (h12.ElementAt(0)).IsEmpty)
                lstAroound.Add(h12.ElementAt(0));
            var h13 = hexxagonalParts.Where(x => x.Column == hex.Column + 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 2);
            if (h13 != null && h13.Count() > 0 && (h13.ElementAt(0)).IsEmpty)
                lstAroound.Add(h13.ElementAt(0));
            var h14 = hexxagonalParts.Where(x => x.Column == hex.Column + 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal + 1);
            if (h14 != null && h14.Count() > 0 && (h14.ElementAt(0)).IsEmpty)
                lstAroound.Add(h14.ElementAt(0));
            var h15 = hexxagonalParts.Where(x => x.Column == hex.Column + 2).Where(y => y.LeftDiagonal == hex.LeftDiagonal);
            if (h15 != null && h15.Count() > 0 && (h15.ElementAt(0)).IsEmpty)
                lstAroound.Add(h15.ElementAt(0));
            var h16 = hexxagonalParts.Where(x => x.Column == hex.Column + 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 1);
            if (h16 != null && h16.Count() > 0 && (h16.ElementAt(0)).IsEmpty)
                lstAroound.Add(h16.ElementAt(0));
            var h17 = hexxagonalParts.Where(x => x.Column == hex.Column).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 2);
            if (h17 != null && h17.Count() > 0 && (h17.ElementAt(0)).IsEmpty)
                lstAroound.Add(h17.ElementAt(0));
            var h18 = hexxagonalParts.Where(x => x.Column == hex.Column - 1).Where(y => y.LeftDiagonal == hex.LeftDiagonal - 2);
            if (h18 != null && h18.Count() > 0 && (h18.ElementAt(0)).IsEmpty)
                lstAroound.Add(h18.ElementAt(0));

            return lstAroound;
        }

    }
}
