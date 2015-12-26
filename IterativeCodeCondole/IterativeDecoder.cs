using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeCodeCondole
{
    public class IterativeDecoder
    {
        private byte[,] matrix;
        private bool[,] _lmatrix;
        private bool[] _checkElemLine;
        private bool[] _checkElemColumn;
        public string decodeLine
        {
            get { return CreateDecodeLine(); }
            private set { }
        }
        public IterativeDecoder(params byte[] values)
        {
            this.SetMatrixSize(values.Length);
            this.DivideArray(values);
            this.ByteToBoolMatrix(matrix);
            this.DivideLineColumtElements(matrix);
            this.CorrectErrMatrix();
        }

        public string CreateDecodeLine()
        {
            StringBuilder combination = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    combination.Append(matrix[i, j]);
                }
            }

            return combination.ToString();
        }

        void DivideArray(byte[] array)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (count < array.Length)
                        matrix[i, j] = array[count++];
                }
            }
        }

        void SetMatrixSize(int count)
        {
            double sqrt = Math.Sqrt(count);
            int іsqrt = (int)sqrt;
            double a = (double)count / (double)іsqrt;
            int b = (int)a;
            if (a > b)
            {
                b = b + 1;
                matrix = new byte[іsqrt, b];
            }
            else if (a == b)
            {
                matrix = new byte[іsqrt, b];
            }
            _checkElemLine = new bool[matrix.GetLength(0)-1];
            _checkElemColumn = new bool[matrix.GetLength(1)-1];
        }

        private void CorrectErrMatrix()
        {
            int[] errlist = FindErrElems(); 
            int i = errlist[0];
            int j = errlist[1];

            if(errlist.Length != 0){
            if (matrix[i, j] == 1)
                matrix[i, j] = 0;
            else if (matrix[i, j] == 0)
                matrix[i, j] = 1;
            else throw new Exception();
            }
        } 

        int[] FindErrElems()
        {
            int[] els = new int[2];
            int matrixcolumncount = _lmatrix.GetLength(1) - 1;
            int matrixlinecount = _lmatrix.GetLength(0) - 1;
            bool[] columntelements = new bool[matrixcolumncount];
            bool[] lineelements = new bool[matrixlinecount];
            int lineel=0;
            int colel=0;
            
            for (int i = 0; i < matrixlinecount; i++)
                for (int j = 0; j < matrixcolumncount; j++)
                    lineelements[i] ^= _lmatrix[i, j];

            for (int i = 0; i < matrixcolumncount; i++)
                for (int j = 0; j < matrixlinecount; j++)
                    columntelements[i] ^= _lmatrix[j, i];

            for (int i = 0; i < _checkElemLine.Length; i++)
            {
                if (_checkElemLine[i] != lineelements[i])
                {
                    lineel = i;
                }
            }

            for (int i = 0; i < _checkElemColumn.Length; i++)
            {
                if (_checkElemColumn[i] != columntelements[i])
                {
                    colel = i;
                }
            }
            els[0] = colel;
            els[1] = lineel;

            return els;
        }

        void DivideLineColumtElements(byte [,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (j == matrix.GetLength(1) - 1)
                        _checkElemLine[i] = ByteToBool(matrix[i, j]);
            }
            for (int i = 0; i < matrix.GetLength(1)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    if (j == matrix.GetLength(0) - 1)
                        _checkElemColumn[i] = ByteToBool(matrix[j, i]);
            }
        }

        void ByteToBoolMatrix(byte[,] values)
        {
            _lmatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    _lmatrix[i, j] = ByteToBool(matrix[i, j]);
                }
            }
        }

        public bool ByteToBool(byte value)
        {
            if (value == 1)
                return true;
            else if (value == 0)
                return false;
            else throw new ArgumentException();
        }
        public byte BoolToByte(bool value)
        {
            if (value == true)
                return 1;
            else if (value == false)
                return 0;
            else throw new ArgumentException();
        }
    }
}