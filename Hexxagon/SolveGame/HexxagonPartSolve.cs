using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hexxagon.SolveGame
{
    class HexxagonPartSolve
    {
        public int Column { get; set; }
        public int LeftDiagonal { get; set; }
        public int RightDiagonal { get; set; }
        public bool IsEmpty { get; set; }
       // public int IsSigned { get; set; }
        public int HexxagonSoldierId { get; set; }
       // public Board MyBoard { get; set; }

//הפונקציה מקבלת משושה ויזואלי  יוצרת משושה לוגי עם אותם פרמטרים רלוונטים ומחזירה אותו
        public static HexxagonPartSolve ConvertHexxagonPartSolve(HexxagonPart h)
        {
            HexxagonPartSolve newhex = new HexxagonPartSolve();
            newhex.Column = h.Column;
            newhex.LeftDiagonal = h.LeftDiagonal;
            newhex.RightDiagonal = h.RightDiagonal;
            newhex.IsEmpty = h.IsEmpty;
            if (h.HexxagonSoldier != null)
                newhex.HexxagonSoldierId = h.HexxagonSoldier.IDSoldier;
            return newhex;
        }
        //הפונקציה  מייצרת משושה לוגי חדש ומאתחלת את משתניו במשושה ויזואלי ומחזירה  אותו
        public HexxagonPartSolve CopyHexxagonalPartSolve()
        {
            HexxagonPartSolve cpyhex = new HexxagonPartSolve();
            cpyhex.Column = Column;
            cpyhex.LeftDiagonal = LeftDiagonal;
            cpyhex.RightDiagonal = RightDiagonal;
            cpyhex.IsEmpty = IsEmpty;
            cpyhex.HexxagonSoldierId = HexxagonSoldierId;
            return cpyhex;
        }
    }
}
