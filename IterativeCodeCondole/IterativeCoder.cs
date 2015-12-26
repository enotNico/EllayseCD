using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeCodeCondole
{
    public class IterativeCoder
    {
        private byte[,] matrix;
        private bool[,] _lmatrix;
        private bool[] _checkElemLine;
        private bool[] _checkElemColumn;
        private bool _controlElement = false;
        public string encodeLine
        {
            get { return CreateEncodeLine(); }
            private set { }
        }
        
        public IterativeCoder(params byte[] values)
        {
            this.SetMatrixSize(values.Length);
            this.DivideArray(values);
            this.ByteToBoolMatrix(matrix);
            this.CalculateCheckElements();
            this.CalculateControlElement(_checkElemLine, _checkElemColumn);
            this.CreateEncodeLine();
        }

        public string GetEncodeLine()
        {
            return encodeLine;
        }

        private string CreateEncodeLine()
        {
            StringBuilder combination = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    combination.Append(matrix[i, j]);
                }
                combination.Append(BoolToByte(_checkElemLine[i]));
            }

            for (int i = 0; i < _checkElemColumn.Length; i++)
                combination.Append(BoolToByte(_checkElemColumn[i]));
            combination.Append(BoolToByte(_controlElement));

            return combination.ToString();
        }

        void CalculateCheckElements()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    _checkElemLine[i] ^= _lmatrix[i, j];

            for (int i = 0; i < matrix.GetLength(1); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    _checkElemColumn[i] ^= _lmatrix[j,i];
        }

        void CalculateControlElement(bool[] lineElements, bool[] columnElements)
        { 
            bool calcLineElms = false;
            bool calcColElms = false;
            for(int i=0; i < lineElements.Length; i++)
               calcLineElms ^= lineElements[i];

            for (int j = 0; j < columnElements.Length; j++)
                calcColElms ^= columnElements[j];

            if (calcLineElms == calcColElms)
                _controlElement = calcColElms;
        }

        void DivideArray(byte[] array)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(count < array.Length)
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
            if(a > b)
            {
                b = b + 1;
                matrix = new byte[іsqrt,b];
            }
            else if(a==b)
            {
                matrix = new byte[іsqrt, b];
            }
            _checkElemLine = new bool[matrix.GetLength(0)];
            _checkElemColumn = new bool[matrix.GetLength(1)];
        }
        
        void ByteToBoolMatrix(byte[,] values)
        {
            _lmatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    _lmatrix[i, j] = ByteToBool(matrix[i,j]);
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
