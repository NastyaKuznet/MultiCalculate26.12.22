using System.Net.Http.Headers;

namespace Calculator26._12._22_Informatic_
{
    public static class Menu
    {
        public static void ControlMenu()
        {
            PrintMainMenu();
            int command = ReadCommand();
            new SelectTheNextAction(command);
        }
        static void PrintMainMenu()
        {
            Console.WriteLine($"Программа Кузнецовой Анастасии Александровны ПрИ-101.\n\n" +
                $"Перевод целых и вещественных чисел для пятиклассника.\n\n" +
                $"Напишите номер нужной задачи, чтобы начать её выполнение \nили \"0\", чтобы закрыть программу.\n\n" +
                $"1. Перевод целого числа в дополнительный код.\n" +
                $"2. Сложение целых (положительных и отрицательных) чисел с использованием дополнительного кода.\n" +
                $"3. Перевод вещественного числа в формат с плавающей точкой.\n" +
                $"4. Сложение вещественных чисел в формате с плавающей точкой.");
        }

        static int ReadCommand()
        {
            return FoolProof.IntFoolProof(0, 4);
        }
    }
}
