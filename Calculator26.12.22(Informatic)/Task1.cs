using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class Task1
    {
        public static void Start()
        {
            Console.Write($"1. Перевод целого числа в дополнительный код.\n\n" +
                $"Возиожен ввод от -128 до 127.\n" +
                $"Введите число: ");
            int num0 = FoolProof.IntFoolProof(-128, 127);

            TranslatingInteger num = new TranslatingInteger(num0);

            Console.WriteLine($"Мы будем переводить число в дополнительный код длиною 8 бит.\n\n" +
                $"Переводим число в двоичную систему счисления. Если число отрицательное, то его модуль.");
            TranslatingSS.ChoiceNeedDescribeInBin(num.Number.ToString());
            Console.WriteLine($"Введенное число в двоичной сс равно {num.Steps[TranslatingInteger.NameStep.translationWithoutZero]}.\n" +
                $"Если полученное число оказалось длиною меньше чем 8 знаков,\n" +
                $"то оставшиеся заполняем нулями спереди {num.Steps[TranslatingInteger.NameStep.translationWithZero]}.");
            ChoiceDo(num);
        }

        private static void ChoiceDo(TranslatingInteger num) 
        {
            if (num.Sign)
                WriteTextPositive(num);
            else 
                WriteTextNegative(num);
        }
        private static void WriteTextPositive(TranslatingInteger num)
        {
            Console.WriteLine($"Результат перевода равен: {num.Result}.");
        }

        private static void WriteTextNegative(TranslatingInteger num)
        {
            Console.WriteLine($"Дальше нам нужно инвертировать нашу запись," +
                $"заменяя нули единицами и наоборот.\nПолучаем {num.Steps[TranslatingInteger.NameStep.negative]}.\n" +
                $"Теперь осталось добавить к полученному числу единицу, получив {num.Steps[TranslatingInteger.NameStep.addOne]}.\n" +
                $"Резутат перевода равен {num.Result}.");
        }
    }
}
