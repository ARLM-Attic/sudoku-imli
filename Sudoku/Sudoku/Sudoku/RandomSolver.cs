using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class RandomSolver : ISolver
    {
        #region private fields
        List<Tuple<int,int>> _usedNumbers = new List<Tuple<int,int>>();
        SudokuNumbers numbers = new SudokuNumbers();
        #endregion

        #region public properities
        #endregion

        #region public methods

        //return all current sudoku numbers
        public SudokuNumbers ReturnSudoku()
        {
            return numbers;
        }

        //one step in sudoku solving
        public void Step()
        {
            
        }

        //step back in sudoku solving
        public void StepBack()
        {
            
        }

        //solve sudoku
        public void Solve()
        {
            
        }
        #endregion

#region constructors

        public RandomSolver(int[]setNumbers)
        {
            if (setNumbers.Count() < 81 || setNumbers.Count() > 81)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < 81; i++)
            {
                numbers.SetNumber(i, setNumbers[i]);
            } 
        }
#endregion

    }
}
