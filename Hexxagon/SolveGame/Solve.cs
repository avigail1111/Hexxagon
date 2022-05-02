
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hexxagon.SolveGame
{
    class Solve
    {
        BoardSolve newBoard;
        public int Level { get; set; }
        int IdSoldierSolve, IdSoldierOther;
        //הבנאי מקבל לוח ויזואלי וסוג שחקן  ומעדכן את המשתנים
        public Solve(Board brd,int idSoldierSolve,int level)
        {
            newBoard = BoardSolve.ConvertToBoardSolve(brd);
            Level = level;
            IdSoldierSolve = idSoldierSolve;
            if (IdSoldierSolve == 1)
                IdSoldierOther = 2;
            else
                IdSoldierOther = 1;
            SolveTheGame();

        }

        int columnSolve = 0, leftDiagonalSolve = 0;
        int columnSolveSource = 0, leftDiagonalSolveSource = 0;

        public int LeftDiagonalSolveSource
        {
            get { return leftDiagonalSolveSource; }
            set { leftDiagonalSolveSource = value; }
        }

        public int ColumnSolveSource
        {
            get { return columnSolveSource; }
            set { columnSolveSource = value; }
        }
        public int LeftDiagonalSolve
        {
          get { return leftDiagonalSolve; }
          set { leftDiagonalSolve = value; }
        }

        public int ColumnSolve
        {
          get { return columnSolve; }
          set { columnSolve = value; }
        }

       
       //הפונקציה מציבה במשתנה 
        public void SolveTheGame()
        {
            //firstBoard.AllOptions();
            int res = Max(newBoard, Level);
        }

        //הפונקציה מקבלת לוח לוגי ועומק ומחזירה את הערך המקסימלי של הניקוד
        private int Max(BoardSolve brd, int depth)
        {
            int max = int.MinValue;
            //  רשימה של לוחות לוגיים
            List<BoardSolve> options = brd.AllOptions(IdSoldierSolve);
            //אם נגמר העומק או שאין לוחות אפשריים אז מחזיר את הפרש הלוחות 
            if (depth == 0 || options.Count == 0)
                return brd.EvalBoard(IdSoldierSolve);
            //עובר על רשימת הלוחות 
            foreach (BoardSolve option in options)
            {
                int res = Min(option, depth - 1);
                if (res > max)
                {
                    max = res;
                    if (depth == Level)
                    {
                        ColumnSolve = option.PutHex.Column;
                        leftDiagonalSolve = option.PutHex.LeftDiagonal;
                        LeftDiagonalSolveSource = option.SourcePutHex.LeftDiagonal;
                        ColumnSolveSource = option.SourcePutHex.Column;
                    }
                }
            }
            return max;

        }
//הפונקציה מקבלת לוח לוגי ועומק ומחזירה את הערך המינמלי של הניקוד
        private int Min(BoardSolve brd, int depth)
        {
            int min = int.MaxValue;
            List<BoardSolve> options = brd.AllOptions(IdSoldierOther);
            //אם נגמר העומק או שאין לוחות אפשריים אז מחזיר את הפרש הלוחות 
            if (depth == 0 || options.Count == 0)
                return brd.EvalBoard(IdSoldierSolve);
            foreach (BoardSolve option in options)
            {
                int res = Max(option, depth - 1);
                if (res < min)

                    min = res;
            }
            return min;
        }

    }
}
