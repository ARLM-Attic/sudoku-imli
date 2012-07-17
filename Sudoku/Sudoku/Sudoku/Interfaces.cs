using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    internal interface ISolver
    {
        //one step in solving sudoku
        void Step();
        //step back in solving sudoku
        void StepBack();
        //solve sudoku
        void Solve();
        //return sudoku numbers
        SudokuNumbers ReturnSudoku();
    }

    internal interface ICreator
    {
        //create sudoku puzzle with set number of blank spots
        void Create(int NumberOfBlanks);
        //return sudoku numbers
        SudokuNumbers ReturnSudoku();
    }
}
