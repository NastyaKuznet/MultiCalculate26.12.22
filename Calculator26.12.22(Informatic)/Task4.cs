using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class Task4
    {
        private static TranslationDouble Num1 { get; set; }
        private static TranslationDouble Num2 { get; set; }
        private static SumDoubleCode Result { get; set; }
        public static void Start()
        {
            Console.Write($"4. Сложение вещественных чисел в формате с плавающей точкой.\n\n" +
                $"Введите первое число: ");
            double num01 = FoolProof.DoubleFoolProof();
            Console.Write($"Введите второе число: ");
            double num02 = FoolProof.DoubleFoolProof();

            TranslationDouble num1 = new TranslationDouble(num01);
            TranslationDouble num2 = new TranslationDouble(num02);

            Console.WriteLine($"Переведем числа в формат с плавающей точкой:\n" +
                $"  {num01} --> {num1.Result}\n" +
                $"  {num02} --> {num2.Result}.");
            Console.WriteLine($"Сперва нужно сравнить порядки чисел. Если же они не равны,\n" +
                $"то нужно из большего вычесть меньший и на эту разницу\n" +
                $"сделать сдвиг мантиссы числа с меньшим порядком.");
            Sort(num1, num2);
            Result = new SumDoubleCode(num1, num2);
            ShiftOrder();
            Console.WriteLine($"Осталось сложить побитово мантиссы чисел. Если при сложении получится, \n" +
                $"что единица выходит за левую границу мантиссы, то нужно просто прибавить её к порядку.\n" +
                $" {Result.Num_1.Result}\n" +
                $"+\n" +
                $" {Result.Num_2.Result}");
            WriteLine();
            Console.WriteLine($" {Result.ResultCode.Result} --> {Result.ResultDouble}\n" +
                $"{num1.Number} + {num2.Number} = {Result.ResultDouble}.");
        }
        private static void Sort(TranslationDouble num1, TranslationDouble num2)
        {
            if (num1.OrderDec > num2.OrderDec)
            {
                Num1 = num1;
                Num2 = num2;
            }
            else
            {
                Num1 = num2;
                Num2 = num1;
            }   
        }
        private static void ShiftOrder()
        {
            int shift = (Num1.OrderDec + 127) - (Num2.OrderDec + 127);
            Console.WriteLine($"Разность порядков равна {Num1.OrderDec + 127} - {Num2.OrderDec + 127} = {shift}.\n");
            if (shift == 0)
            {
                Console.WriteLine("Если разность равна 0, то ничего сдвигать не нужно.");
            }
            else
            {
                Console.WriteLine($"Нам нужно сдвинуть мантиссу числа с меньшим порядком на {shift} знаков вправо.\n" +
                    $"Помним, что перед мантиссой стоит 1, которую мы не видим." +
                    $"Так же порядок числа станет равен порядку большего числа.\n" +
                    $"Получаем число при сдвиге: \n" +
                    $"{Result.Num_2.Result}.");
            }
        }
        private static void WriteLine()
        {
            Console.Write(" ");
            for (int i = 0; i < 32; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
