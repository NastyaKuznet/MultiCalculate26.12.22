using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class TranslatingSS
    {
        public static string TranslatingInBin(string num)
        {
            if(num == "0")
                return "0";
            int baze = 2;
            char[] alfabet = new char[2] {'0', '1'};
  
            StringBuilder result = new StringBuilder();
            int number = Math.Abs(int.Parse(num));
            int remainder;
            while (number > 0)
            {
                //remainder - остаток
                remainder = number % baze;
                result.Insert(0, alfabet[remainder]);
                number /= baze;
            }
            return result.ToString();
        }
        public static void ChoiceNeedDescribeInBin(string num)
        {
            Console.WriteLine($"Если хотите узнать подробнее, как происходит перевод числа, то напишите 1, иначе 0.");
            int command = FoolProof.IntFoolProof(0, 1);
            if (command == 1)
                TranslatingInBinText(num);
        }
        private static void TranslatingInBinText(string num)
        {
            int baze = 2;
            char[] alfabet = new char[2] { '0', '1' };
            WriteSeparator();
            Console.WriteLine($"Для перевода числа из 10 сс в {baze} сс нужно делить число {num} на основание нужной сс равное {baze}," +
                $" \nа остатки от деления записывать в новое число с конца.");

            StringBuilder result = new StringBuilder();
            int number = Math.Abs(int.Parse(num));
            int remainder;
            while (number > 0)
            {
                //remainder - остаток
                remainder = number % baze;
                Console.WriteLine($"Остаток от деления числа равен {remainder}: {number} % {baze} = {remainder};");
                result.Insert(0, alfabet[remainder]);
                Console.WriteLine($"Теперь введеное число равно {number / baze}: {number} // {baze} = {number / baze}." +
                    $" \nА остаток от деления записываем в начало нового числа: {result}.\n");
                number /= baze;
            }
            WriteSeparator();
        }
        public static void ChoiceNeedDescribeInBin(double num)
        {
            Console.WriteLine($"Если хотите узнать подробнее, как происходит перевод числа, то напишите 1, иначе 0.");
            int command = FoolProof.IntFoolProof(0, 1);
            if (command == 1)
                TranslateInBinDouble(num);
        }
        public static string TranslateInBinDouble(double num)
        {
            string integer = TranslatingInBin(((int)num).ToString());
            string double_ = TranslateDoubleBin((num - (int)num).ToString().Substring(2));
            return integer + "." + double_;
        }
        private static string TranslateDoubleBin(string num)
        {
            int len = num.Length;
            long number = long.Parse(num);
            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                number = number * 2;
                if (number.ToString().Length > len)
                    result.Append(number.ToString()[0]);
                else
                    result.Append("0");
                number = number % (int)(Math.Pow(10, len));
            }
            return result.ToString();
        }
        public static string TranslateInDecDouble(double num)
        {
            string integer = TranslatingInTen(((int)num).ToString());
            string[] dum = num.ToString().Split(',') ;
            string d;
            string double_ = "0";
            if (dum.Length == 1)
            {
                d = "0";
            }
            else
            {
                d = dum[1];
                double_ = TranslatingDoubleDec(d);
            }
            return integer + "," + double_;
        }
        private static string TranslatingDoubleDec(string num)
        {
            double result = 0.0;
            for (int i = 0; i < num.Length; i++)
            {
                result += (num[i] - '0') * Math.Pow(2, (i + 1) * -1);
            }
            return result.ToString().Substring(2);
        }
        private static void PositionNumberForTask1(string number)
        {
            for (int i = 1; i <= number.Length; i++)
            {
                Console.Write(number.Length - i);
            }
            Console.WriteLine();
            Console.WriteLine(number);
        }
        public static void ChoiceNeedDescribeInTen(string num)
        {
            Console.WriteLine($"Если хотите узнать подробнее, как происходит перевод числа, то напишите 1, иначе 0.");
            int command = FoolProof.IntFoolProof(0, 1);
            if (command == 1)
                TranslatingInTenText(num);
        }
        public static string TranslatingInTen(string num)
        {
            int baze = 2;
            char[] alfabet = new char[2] { '0', '1' };
           
            int result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = num[i] - '0';
                result += (int)(digit * Math.Pow(baze, (num.Length - i - 1)));
            }
            return result.ToString();
        }
        private static void TranslatingInTenText(string num)
        {
            int baze = 2;
            char[] alfabet = new char[2] { '0', '1' };
            WriteSeparator();
            Console.WriteLine($"Для перевода числа из {baze} сс в 10 сс сперва нужно обозначить позиции цифр в числе следующим образом справа налево.");
            PositionNumberForTask1(num);
            Console.WriteLine($"Теперь нам нужно каждую цифру умножать на основание сс равное {baze} в степени поцизии цифры. " +
                $"Итоговым числом ялвяется сумма этих произвежений.");
            int result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = num[i];
                Console.Write($"{digit} * {baze}^{num.Length - i - 1}");
                if (i != num.Length - 1)
                    Console.Write(" + ");
                else
                    Console.Write(" = ");
                result += (int)(digit * Math.Pow(baze, (num.Length - i - 1)));
            }
            WriteSeparator();
        }
        private static void WriteSeparator()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
