using System;
using System.Collections.Generic;

namespace Chapter1
{
    class Program
    {
        /// <summary>
        /// 字符-值对应字典
        /// </summary>
        private static readonly Dictionary<char, long> dicCharToValue = new Dictionary<char, long>()
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
        /// <summary>
        /// 值-字符对应字典
        /// </summary>
        private static readonly Dictionary<long, char> dicValueToChar = new Dictionary<long, char>()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("请输入M:");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入M的值:");
            string mValue = Console.ReadLine();
            Console.WriteLine("请输入N:");
            int n = Convert.ToInt32(Console.ReadLine());

            try
            {
                Console.WriteLine($"计算结果:{ConvertMToN(m, mValue, n)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生异常:{ex.Message}");
            }

            Console.WriteLine("计算结束");
            Console.ReadKey();
        }

        /// <summary>
        /// 将m进制数转为n进制数
        /// </summary>
        /// <param name="m">需要被转换的进制</param>
        /// <param name="mValue">需要被转换的数值</param>
        /// <param name="n">转换为的进制</param>
        /// <returns></returns>
        static string ConvertMToN(int m, string mValue, int n)
        {
            if (m == 1 || n == 1)
            {
                throw new Exception("不存在1进制数");
            }
            if (m > 20 || n > 20)
            {
                throw new Exception("最大只能进行20进制内的数据转换");
            }
            if (m == n)
            {
                return mValue;
            }

            //将m进制数转为10进制数
            char[] mCharArray = mValue.ToCharArray();
            Array.Reverse(mCharArray);
            long mIntValue = 0;
            for (int i = 0; i < mCharArray.Length; i++)
            {
                long currentValue = dicCharToValue[char.ToUpper(mCharArray[i])];
                if (currentValue >= m)
                {
                    throw new Exception($"{m}进制数只能由0~{m - 1}中的数字表示");
                }
                mIntValue += Convert.ToInt64(currentValue * Math.Pow(m, i));
            }

            //将10进制数转为n进制数

            long quotient = mIntValue;
            List<char> charList = new List<char>();
            while (quotient != 0)
            {
                long remainder = quotient % n;
                charList.Add(dicValueToChar[remainder]);
                quotient = quotient / n;
            }
            char[] charArray = charList.ToArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}