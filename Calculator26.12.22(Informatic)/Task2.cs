using Calculator26._12._22_Informatic_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class Task2
    {
        public static void Start()
        {
            Console.Write($"2. Сложение целых (положительных и отрицательных) чисел с использованием дополнительного кода.\n\n" +
                $"Возможен ввод чисел от -128 до 127.\n" +
                $"Введите первое число: ");
            int num01 = FoolProof.IntFoolProof(-128, 127);
            Console.Write("Введите второе число: ");
            int num02 = FoolProof.IntFoolProof(-128, 127);
            Console.WriteLine("Переведем числа в дополнительный код:");

            string num1 = new TranslatingInteger(num01).Result;
            string num2 = new TranslatingInteger(num02).Result;
            Console.WriteLine($"    {num01} --> {num1}\n" +
                $"    {num02} --> {num2}.");
            Console.WriteLine("Теперь сложим числа побитово.");
            AddUpBin.ChoiceNeedDescribeInBin(num1, num2);
            AddUpInteger result = new AddUpInteger(num1, num2);
            Console.WriteLine($"Мы молучили число {result.ResultWithoutOverflowCheck}.");
            SelectToDo(result);
        }

        private static void SelectToDo(AddUpInteger result)
        {
            if (result.IsOverflow())
                DoIsOverFlow(result);
            else
                DoIsNotOverFlow(result);
        }

        private static void DoIsOverFlow(AddUpInteger result)
        {
            Console.WriteLine($"Произошло переполнение!\n" +
                $"Длина полученного результата больше чем 8 бит. Нужнно отбросить лишний бит слева,\n" +
                $"и получится верное значение.\n");
            Console.WriteLine($"{result.Result.BinCode} --> {result.Result.DecNum}.");
        }

        private static void DoIsNotOverFlow(AddUpInteger result)
        {
            Console.WriteLine($"Результат сложения равен.");
            Console.WriteLine($"{result.Result.BinCode} --> {result.Result.DecNum}.");
        }
    }
}
