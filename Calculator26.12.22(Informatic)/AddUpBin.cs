using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator26._12._22_Informatic_
{
    public static class AddUpBin
    {
        public static string Sum(string num1, string num2)
        {
            int baze = 2;
            char[] alfabet = new char[2] { '0', '1' };
            if (num1.Length < num2.Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }

            num2 = ZeroHeadDown(num1, num2);

            StringBuilder sumDigit = new StringBuilder();
            
            int next0 = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1i = num1[i] - '0';
                int num2i = num2[i] - '0';
                sumDigit.Insert(0, alfabet[(num1i + num2i + next0) % baze]);
                next0 = (num1i + num2i + next0) / baze;
            }
            if (next0 != 0)
            {
                sumDigit.Insert(0, next0.ToString());
            }
            return sumDigit.ToString();
        }
        public static void ChoiceNeedDescribeInBin(string num1, string num2)
        {
            Console.WriteLine($"Если хотите узнать подробнее, как происходит сложение чисел, то напишите 1, иначе 0.");
            int command = FoolProof.IntFoolProof(0, 1);
            if (command == 1)
                SumText(num1, num2);
        }
        private static void SumText(string num1, string num2)
        {
            int baze = 2;
            char[] alfabet = new char[2] { '0', '1' };
            if (num1.Length < num2.Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }
            WriteSeparator();
            Console.WriteLine($"Будем складывать цифры по разрядно начиная с конца.\n" +
                $" +{num1}\n" +
                $"  {EmptyHead(num1, num2)}");
            ColumnWidth(num1.Length);
            num2 = ZeroHeadDown(num1, num2);

            int CursorTop = Console.CursorTop;
            Console.SetCursorPosition(0, CursorTop + 1);
            Console.WriteLine("Начнем сложение.");
            CursorTop = Console.CursorTop;

            char sumDigit;
            int next0 = 0;
            int next1 = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1i = num1[i] - '0';
                int num2i = num2[i] - '0';
                sumDigit = alfabet[(num1i + num2i + next0) % baze];
                next0 = (num1i + num2i + next0) / baze;
                Console.SetCursorPosition(i + 2, 16);
                Console.Write(sumDigit);
                Console.SetCursorPosition(0, CursorTop);
                if (next0 > 0)
                {
                    if (next1 > 0)
                    {
                        Console.WriteLine($"При сложении получилось число длинною больше, чем один символ: {num1[i]} + {num2[i]} + {next1} = {next0}{sumDigit}.\n" +
                        $"Правый символ записываем {sumDigit}. А левый запоминаем, его добавим к следующему разряду {next0}.");
                    }
                    else
                    {
                        Console.WriteLine($"При сложении получилось число длинною больше, чем один символ: {num1[i]} + {num2[i]} = {next0}{sumDigit}.\n" +
                            $"Правый символ записываем {sumDigit}. А левый запоминаем, его добавим к следующему разряду {next0}.");
                    }
                    CursorTop = Console.CursorTop;
                }
                else if (next1 != 0)
                {
                    Console.WriteLine($"Не забываем про число из прошлой операции: {num1[i]} + {num2[i]} + {next1} = {alfabet[num1i + num2i + next1]}.\n");
                    CursorTop = Console.CursorTop;
                }
                else
                {
                    Console.WriteLine($"При сложении следующих цифр получим: {num1[i]} + {num2[i]} = {alfabet[num1i + num2i]}");
                    CursorTop = Console.CursorTop;
                }
                next1 = next0;
            }
            CursorTop = Console.CursorTop;
            if (next1 != 0)
            {
                Console.WriteLine($"Не забываем про число из прошлой операции, записываем его {next1}.");
                Console.SetCursorPosition(1, 16);
                Console.Write(next1);
            }
            Console.SetCursorPosition(0, CursorTop + 1);
            WriteSeparator();
        }
        private static string EmptyHead(string numup, string numdown)
        {
            StringBuilder empty = new StringBuilder();
            for (int i = 0; i < numup.Length - numdown.Length; i++)
            {
                empty.Append(" ");
            }
            empty.Append(numdown);
            return empty.ToString();
        }
        public static void ColumnWidth(int num)
        {
            StringBuilder dash = new StringBuilder();
            dash.Append("  ");
            for (int i = 0; i < num; i++)
            {
                dash.Append('-');
            }
            Console.WriteLine(dash.ToString());
        }
        public static string ZeroHeadDown(string numup, string numdown)
        {
            StringBuilder zero = new StringBuilder();
            for (int i = 0; i < numup.Length - numdown.Length; i++)
            {
                zero.Append("0");
            }
            zero.Append(numdown);
            return zero.ToString();
        }
        private static void WriteSeparator()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
