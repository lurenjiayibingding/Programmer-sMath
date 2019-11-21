using System;
using System.Collections.Generic;

namespace Chapter1
{
    class Program
    {
        private static readonly Dictionary<char, long> map1 = new Dictionary<char, long>()
        {
            {'0',0},
            {'1',1},
            {'2',2},
            {'3',3},
            {'4',4},
            {'5',5},
            {'6',6},
            {'7',7},
            {'8',8},
            {'9',9},
            {'A',10},
            {'B',11},
            {'C',12},
            {'D',13},
            {'E',14},
            {'F',15},
            {'G',16},
            {'H',17},
            {'I',18},
            {'J',19}
        };

        private static readonly Dictionary<long, char> map2 = new Dictionary<long, char>()
        {
            {0,'0'},
            {1,'1'},
            {2,'2'},
            {3,'3'},
            {4,'4'},
            {5,'5'},
            {6,'6'},
            {7,'7'},
            {8,'8'},
            {9,'9'},
            {10,'A'},
            {11,'B'},
            {12,'C'},
            {13,'D'},
            {14,'E'},
            {15,'F'},
            {16,'G'},
            {17,'H'},
            {18,'I'},
            {19,'J'}
        };


        static void Main(string[] args)
        {
            Console.WriteLine("请输入M:");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入M的值:");
            string mValue = Console.ReadLine();
            Console.WriteLine("请输入N:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"计算结果:{ConvertMToN(m, mValue, n)}");

            Console.WriteLine("计算结束");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="mValue"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static string ConvertMToN(int m, string mValue, int n)
        {
            if (m == n)
            {
                return mValue;
            }
            if (m > 20 || n > 20)
            {
                throw new Exception("最大只能进行20进制内的数据转换");
            }

            //将m进制数转为10进制数
            char[] mCharArray = mValue.ToCharArray();
            Array.Reverse(mCharArray);
            long mIntValue = 0;
            for (int i = 0; i < mCharArray.Length; i++)
            {
                mIntValue += Convert.ToInt64(Math.Pow(map1[mCharArray[i]], i));
            }

            //将10进制数转为n进制数

            long quotient = 1;
            List<char> charList = new List<char>();
            while (quotient != 0)
            {
                long remainder = mIntValue % n;
                charList.Add(map2[remainder]);
                quotient = mIntValue / n;
            }
            char[] aaaa = charList.ToArray();
            Array.Reverse(aaaa);
            return new string(aaaa);
        }
    }
}