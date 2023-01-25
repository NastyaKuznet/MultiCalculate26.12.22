using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class SelectTheNextAction
    {
        public int Command { get; set; }

        public SelectTheNextAction(int command)
        {
            Console.Clear();
            //можно написать через словарь
            switch (command)
            {
                case (0):
                    Environment.Exit(0);
                    break;
                case (1):
                    Task1.Start();
                    break;
                case (2):
                    Task2.Start();
                    break;
                case (3):
                    Task3.Start();
                    break;
                case (4):
                    Task4.Start();
                    break;
                case (5):
                    Menu.ControlMenu();
                    break;
            }
            Select();
        }
        private void Select()
        {
            Console.WriteLine($"Для выхода из программы нажмите 0.\n" +
                $"Для перехода на другое задание - номер задания.\n" +
                $"Для выхода в главное меню - 5.\n");
            int commad = FoolProof.IntFoolProof(0, 5);
            new SelectTheNextAction(commad);
        }
    }
}
