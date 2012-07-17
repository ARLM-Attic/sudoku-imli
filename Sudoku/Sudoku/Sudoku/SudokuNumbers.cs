using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class SudokuNumbers
    {
        #region private fields
        
        private int[] numbers = new int[81]; //9 x 9 numbers of sudoku
        private int filledNumbers = 0;

        //count of filled numbers in each row/cell/coll 
        private int[] _rowNumbersCount = new int[9];
        private int[] _collNumbersCount = new int[9];
        private int[] _cellumbersCount = new int[9];

        //key = 0-8 rows, 9-17 -colls, 18-26 cells 
        private Dictionary<int,int> numberCount = new Dictionary<int, int>();


        #endregion

        #region public properities

        //filled numbers count
        public int FilledNumbers
        {
            get { return filledNumbers; }
        }

        #endregion


        #region public methods

        public int GetNumber(int position)
        {

            if (position > 80)//81 numbers in sudoku
            {
                throw new ArgumentOutOfRangeException();
            }
            return numbers[position];

        }

        public void SetNumber(int position, int number)
        {
            if (position > 80)//81 numbers in sudoku
            {
                throw new ArgumentOutOfRangeException();
            }

            //if its newly filled number, we add counter
            if(numbers[position] == 0)
            {
                filledNumbers++;
            }
            numbers[position] = number;

            if(number == 0)
            {
                deductFromCounts(position);
            }
            else
            {
                addToCounts(position);
            }
        }

        //return row/coll/cell with highest number of numbers filled, relative position 2 means it will pick
        // second highest value
        public int ReturnHighestNumber(int relativePosition)
        {
            //sorting dictionary by highest value 
            numberCount = numberCount.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

           return numberCount.ElementAt(relativePosition).Key; //returning row/coll/cell with highest number count
        }

        #endregion


        #region private methods

        //increasing count in row/coll/cell
        private void addToCounts(int position)
        {
            //calculate in what row/coll/cell given position is
            int[] positions = PositionCalc.ReturnPositions(position);

            numberCount[positions[0]]++;
            numberCount[positions[1]+9]++;
            numberCount[positions[2]+18]++;
        }
        //decreasing count in row/coll/cell
        private void deductFromCounts(int position)
        {
            //calculate in what row/coll/cell given position is
            int[] positions = PositionCalc.ReturnPositions(position);

            numberCount[positions[0]]--;
            numberCount[positions[1] + 9]--;
            numberCount[positions[2] + 18]--;
    
        }

        #endregion

        public SudokuNumbers()
        {
            //initializing count of numbers in rows/colls/cells
            for (int i = 0; i < 27; i++)
            {
                numberCount.Add(i,0);
            }

        }
    }
}
