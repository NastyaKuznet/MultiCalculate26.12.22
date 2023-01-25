using Calculator26._12._22_Informatic_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class UntranslatingInteger
    {
        public string BinCode { get; private set; }
        public int DecNum { get; private set; }
        
        public UntranslatingInteger(string binCode) 
        {
            BinCode = binCode;
            DecNum = SelectBySign();
        }

        private int SelectBySign()
        {
            if (BinCode[0] == '0')
                return UntranslatingPositive();
            else
                return UntranslatingNegative();

        }
        private int UntranslatingPositive()
        {
            string result = TranslatingSS.TranslatingInTen(BinCode);
            return int.Parse(result);
        }

        private int UntranslatingNegative()
        {
            string str0 = SubtractionBin.Subtraction(BinCode, "1");
            string str = TranslatingNegative(str0);
            StringBuilder result = new StringBuilder();
            result.Append("-");
            result.Append(TranslatingSS.TranslatingInTen(str));
            return int.Parse(result.ToString());
        }

        private string TranslatingNegative(string str0)
        {
            string str = str0;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                    result.Append('1');
                else
                    result.Append('0');
            }
            return result.ToString();
        }

    }
}
