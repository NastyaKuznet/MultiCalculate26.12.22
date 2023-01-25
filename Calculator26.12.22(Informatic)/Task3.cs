using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class Task3
    {
        public static void Start()
        {
            Console.Write($"3. Перевод вещественного числа в формат с плавающей точкой.\n\n" +
               $"Введите число: ");
            double num0 = FoolProof.DoubleFoolProof();
            TranslationDouble num = new TranslationDouble(num0);

            Console.WriteLine( $"Для перевода числа в формат с плавающей точкой отводится 32 бита.\n" +
                $"Первый бит отводится под знак. Следующие 8 бит под порядок, остальные 23 под мантиссу." );
            Console.WriteLine($"Начнём перевод.");
            ChoiceSign(num.Sign);
            Console.WriteLine($"Теперь модуль числа нужно перевести в 2 сс:\n" +
                $"{num.Number} --> {num.TranslationBin}.");
            Console.WriteLine($"Проведем нормализацию числа:\n" +
                $"{num.TranslationBin} = {num.NormalizationNum} * 2^{num.OrderDec}.");
            Console.WriteLine($"Число {num.OrderDec} называется порядком.\n" +
                $"Приведем порядок числа к нужному виду.\n" +
                $"Для этого добавим число 127 (это нужно для того, чтобы порядок всегда был положительным).\n" +
                $"{num.OrderDec} + 127 = {num.OrderDec + 127}." +
                $"И переведем в 2 сс: {num.OrderDec + 127} --> {int.Parse(num.OrderBin)}");
            Console.WriteLine($"Если порядок получился длиною меньше 8 бит, то дописываем нули слева.\n\n" +
                $"Переходим к мантиссе. В мантиссу нужно записать нормализованное число\n" +
                $"без целой части {num.NormalizationNum.Substring(2)}.\n" +
                $"И если мантисса получилась длиною меньше 23 бит, то дописываем нули справа.\n\n" +
                $"Результат перевода равен: {num.Result}");
        }
        private static void ChoiceSign(string sign)
        {
            if (sign == "0")
                Console.WriteLine($"Т.к. число положительное запишим в первый бит {sign}.\n");
            else
                Console.WriteLine($"Т.к. число отрицательное запишим в первый бит {sign}.\n");
        }
    }
}
