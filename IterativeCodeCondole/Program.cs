using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeCodeCondole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\tIтеративний код (Код Еллаєса)!");
            //Console.WriteLine("Введiть комбiнацiю двiйкових символiв для кодування: ");
            Console.WriteLine("Введiть комбiнацiю двiйкових символiв для декодування: ");
            string input = (Console.ReadLine()).Replace(" ", string.Empty);
            //byte[] bytearray = new byte[input.Length];
            //for (int i = 0; i < input.Length; i++)
            //{
            //    bytearray[i] = Convert.ToByte(input[i]);
            //}
            //IterativeCode code = new IterativeCode(bytearray);
            //IterativeCoder code = new IterativeCoder(1,0,1,1,1,0,1,0,1,0,1,0,1,0,0,1,0,1,1,0,1,1,0,1,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1);
            //IterativeCoder code = new IterativeCoder(1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1);
            //IterativeCoder code = new IterativeCoder(1,0,1,0,1,0,1,1,1,1,1,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1,0,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,1,0,0);




            //IterativeCoder code = new IterativeCoder(1,1,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,0,0,0);
            //Console.WriteLine(code.encodeLine);
            //code.ShowMatrix();
            //     11101001111101110111111000000000110


            IterativeDecoder dec = new IterativeDecoder(1,1,1,0,1,0,0,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,0);
            Console.WriteLine(dec.decodeLine);

            //Console.WriteLine();
            //Console.WriteLine("\nМатриця пiсля виправлення помилки:\n");
            //dec.ShowMatrix();



            //public void ShowOutputCode()
            //{
            //    StringBuilder combination = new StringBuilder();

            //    for (int i = 0; i < matrix.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < matrix.GetLength(1); j++)
            //        {
            //            combination.Append(matrix[i,j]);
            //        }
            //        combination.Append(BoolToByte(_checkElemLine[i]));
            //    }

            //    for (int i = 0; i < _checkElemColumn.Length; i++)
            //        combination.Append(BoolToByte(_checkElemColumn[i]));
            //    combination.Append(BoolToByte(_controlElement));

            //    Console.WriteLine("\n");
            //    Console.WriteLine("Вихiдна комбiнацiя - {0}", combination);
            //}


        //     public void ShowMatrix()
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        Console.WriteLine();
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            Console.Write("{0} ", matrix[i, j]);
        //        }
        //        Console.Write("|{0}", BoolToByte(_checkElemLine[i]));

        //        if (i == matrix.GetLength(0) - 1)
        //        {
        //            Console.WriteLine("\n{0}|-", new string('-', _checkElemColumn.Length * 2));
        //        }
        //    }
        //    for (int i = 0; i < matrix.GetLength(1); i++)
        //        Console.Write("{0} ", BoolToByte(_checkElemColumn[i]));
        //    Console.Write("|");
        //    Console.Write(BoolToByte(_controlElement));
        //}

            Console.ReadLine();
        }
    }
}
