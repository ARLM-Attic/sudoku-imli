using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    /// <summary>
    /// class that calculates a position of number in one dimensional array of 9x9 sudoku
    /// based on given cell/row/coll and position in them
    /// </summary>
    public static class PositionCalc
    {
        public static int RowPosition(int row, int number)
        {
            if (row > 8 || number > 8)
            {
                throw new ArgumentOutOfRangeException();
            }
            return row*10 + number;
        }

        public static int CollPosition(int coll, int number)
        {
            if(coll > 8 || number > 8)
            {
                throw new ArgumentOutOfRangeException();
            }
            return number * 10 + coll;
        }

        public static int CellPosition(int cell, int number)
        {

            if (cell > 8 || number > 8)
            {
                throw new ArgumentOutOfRangeException();
            }

            int row = 0;
            int coll = 0;
            int index = 0;

            //determine starting row
            if (cell < 3) row = 0;
            else if (cell > 3 && cell < 6) row = 3;
            else row = 6;

            //determine starting coll
            if (cell%3 == 0) coll = 0;
            if (cell%3 == 1) coll = 3;
            if (cell%3 == 2) coll = 6;

            //determine how much we add to row
            if (number / 3 == 1) row += 1;
            if (number / 3 == 2) row += 2;

            //determine how much we add to coll
            if (number % 3 == 1) coll += 1;
            if (number % 3 == 2) coll += 2;


            return row*10 + coll;
        }


        /// <summary>
        /// returns number of coll/row/cell of given position in sudoku numbers
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static int[] ReturnPositions(int position)
        {
            int[] positions = new int[3];

            positions[0] = position/9;
            positions[1] = position%9;


            if (positions[0] > 2 && positions[0] < 6) positions[2] += 3;
            else if (positions[0] > 5) positions[2] += 6;
            else positions[2] = 0;

            if (positions[1] > 2 && positions[1] < 6) positions[2] += 1;
            else if (positions[1] > 5) positions[2] += 2;

            return positions;

        }

    }
}
