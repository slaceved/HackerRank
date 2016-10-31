using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MatrixLayerRotation
{
    public class Solution
    {
        public void Main(string[] args)
        {
            var input = Console.ReadLine();
            Debug.Assert(input != null, "input != null");
            var rowcols = input.Split(' ');
            var rowIdx = 0;
            var rotation = new MatrixRotation
            {
                RowNumber = Convert.ToInt32(rowcols[0]),
                ColumnNumber = Convert.ToInt32(rowcols[1]),
                RotationNumer = Convert.ToInt32(rowcols[2])
            };

            rotation.CreateEmptyMatrix();
            var inputRow = Console.ReadLine();
            while (!string.IsNullOrEmpty(inputRow))
            {
                rotation.CreateMatrix(rowIdx, inputRow);

                inputRow = Console.ReadLine();
                rowIdx++;
            }
            rotation.PrintMatrixRotation();
            rotation.PrintMatrix(rotation.Rotation);
        }
    }
    
    public class MatrixRotation
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int RotationNumer { get; set; }
        public int[,] Matrix;
        public int[,] Rotation;
        public List<Tuple<int, int>> DiagonalNumber { get; set; }

        public void PrintMatrix(int[,] matrix)
            {
                var lengthX = matrix.GetLength(1);
                var lengthY = matrix.GetLength(0);
                for (var y = 0; y < lengthY; y++)
                {
                    for (var x = 0; x < lengthX; x++)
                    {
                        if (x == lengthX - 1)
                            Console.Write(matrix[y, x]);
                        else
                        {
                            Console.Write(matrix[y, x] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }

        public void CreateEmptyMatrix()
        {
            Matrix = new int[RowNumber, ColumnNumber];
            Rotation = new int[RowNumber, ColumnNumber];
        }

        public void CreateMatrix(int rowIdx, string s)
        {
            var rowStringList = s.Split(' ');
            for (var i = 0; i < ColumnNumber; i++)
            {
                Matrix[rowIdx, i] = Convert.ToInt32(rowStringList[i]);
                Rotation[rowIdx, i] = Convert.ToInt32(rowStringList[i]);
            }
        }

    public void PrintMatrixRotation()
    {
        if (Matrix.Length <= 0 || RowNumber <= 0 || ColumnNumber <= 0) return;
        DiagonalNumber = new List<Tuple<int, int>>();
        for (int rowIdx = 0, colIdx = 0; rowIdx < RowNumber && colIdx < ColumnNumber; rowIdx++, colIdx++)
        {
            if (DiagonalNumber.Count(x => x.Item1 == rowIdx && x.Item2 == colIdx) == 0)
            {
                DiagonalNumber.Add(new Tuple<int, int>(rowIdx, colIdx));
                var currentRotation = new List<Tuple<int, int>>();
                var colNumInCurrentRoation = ColumnNumber - 2 * colIdx;
                var rowNumInCurrentRotation = RowNumber - 2 * rowIdx;
                //Move Right
                for (var col = colIdx; col <= ColumnNumber - colIdx - 1; col++)
                {
                    if (col == rowIdx && DiagonalNumber.Count(x => x.Item1 == rowIdx && x.Item2 == colIdx) == 0)
                        DiagonalNumber.Add(new Tuple<int, int>(rowIdx, col));
                    currentRotation.Add(new Tuple<int, int>(rowIdx, col));
                }

                //Move Down
                for (var row = rowIdx + 1; row <= RowNumber - rowIdx - 1; row++)
                {
                    if (currentRotation.Any(x => x.Item1 == row &&
                                                 x.Item2 == ColumnNumber - colIdx - 1)) continue;
                    {
                        currentRotation.Add(new Tuple<int, int>(row, ColumnNumber - colIdx - 1));
                        if (ColumnNumber - colIdx - 1 == row &&
                            DiagonalNumber.Count(x => x.Item1 == rowIdx && x.Item2 == ColumnNumber - colIdx - 1) == 0)
                            DiagonalNumber.Add(new Tuple<int, int>(row, ColumnNumber - colIdx - 1));
                    }
                }

                //Move Left
                for (var col = ColumnNumber - colIdx - 1 - 1; col >= colIdx; col--)
                {
                    if (currentRotation.Any(x => x.Item1 == RowNumber - rowIdx - 1 &&
                                                 x.Item2 == col)) continue;
                    {
                        currentRotation.Add(new Tuple<int, int>(RowNumber - rowIdx - 1, col));
                        if (RowNumber - rowIdx - 1 == col &&
                            DiagonalNumber.Count(x => x.Item1 == RowNumber - rowIdx - 1 && x.Item2 == col) == 0)
                            DiagonalNumber.Add(new Tuple<int, int>(RowNumber - rowIdx - 1, col));
                    }
                }

                //Move Up
                for (var row = RowNumber - rowIdx - 1 - 1; row >= rowIdx; row--)
                {
                    if (currentRotation.Any(x => x.Item1 == row &&
                                                 x.Item2 == colIdx)) continue;
                    {
                        if (row == colIdx &&
                            DiagonalNumber.Count(x => x.Item1 == row && x.Item2 == colIdx) == 0)
                        {
                            DiagonalNumber.Add(new Tuple<int, int>(row, colIdx));
                        }
                        currentRotation.Add(new Tuple<int, int>(row, colIdx));
                    }
                }

                // shift matrix based on current rotation position list
                for (var shiftIdx = 0; shiftIdx < RotationNumer % ((colNumInCurrentRoation + rowNumInCurrentRotation - 2) * 2); shiftIdx++)
                    ShiftMatrix(currentRotation);
            }
            else
            {
                break;
            }
        }
    }

    private void ShiftMatrix(IReadOnlyList<Tuple<int, int>> rotationList)
            {
                if (rotationList.Count <= 0) return;
                var firstNumber = 0;
                for (var i = 0; i <= rotationList.Count; i++)
                {
                    if (i == 0)
                    {
                        firstNumber = Rotation[rotationList[i].Item1, rotationList[i].Item2];
                    }
                    else if (i == rotationList.Count)
                    {
                        Rotation[rotationList[i - 1].Item1, rotationList[i - 1].Item2] = firstNumber;
                    }
                    else
                    {
                        Rotation[rotationList[i - 1].Item1, rotationList[i - 1].Item2] =
                            Rotation[rotationList[i].Item1, rotationList[i].Item2];
                    }
                }
            }
        }

        
    }