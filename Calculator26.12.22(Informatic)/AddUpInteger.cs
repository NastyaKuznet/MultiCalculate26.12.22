using Calculator26._12._22_Informatic_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class AddUpInteger
    {
        public string Num1 { get; private set; }
        public string Num2 { get; private set; }
        public string ResultWithoutOverflowCheck { get; private set; }
        public UntranslatingInteger Result { get; private set; }


        public AddUpInteger(string num1, string num2)
        {
            Num1 = num1;
            Num2 = num2;
            ResultWithoutOverflowCheck = AddUpSt1();
            Result = AddUpSt2();
        }

        private string AddUpSt1()
        {
            return AddUpBin.Sum(Num1, Num2);
        }
        private UntranslatingInteger AddUpSt2() 
        {
            return new UntranslatingInteger(Overflow(ResultWithoutOverflowCheck));
        }
        public bool IsOverflow()
        {
            if (ResultWithoutOverflowCheck.Length > 8)
                return true;
            return false;
        }

        private string Overflow(string str)
        {
            if (str.Length > 8)
                return str.Substring(str.Length - 8);
            return str;
        }

    }   
}
