using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class FoolProof
    {
        public static int IntFoolProof(int start, int end) 
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                int result;
                if (int.TryParse(command, out result) && result >= start && result <= end)
                    return result;
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("В консоль было введенно неверное значение. Повторите попытку:                    ");
                Console.SetCursorPosition(62, Console.CursorTop);
            }
        }
        public static double DoubleFoolProof()
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                double result;
                
                if (double.TryParse(command, out result) && result.ToString().IndexOf(',') != -1)
                    return result;
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("В консоль было введенно неверное значение. Повторите попытку:                    ");
                Console.SetCursorPosition(62, Console.CursorTop);
            }
        }
    }
}
