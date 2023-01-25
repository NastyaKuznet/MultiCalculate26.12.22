using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    class UntranslationDouble
    {
        public double Result { get; private set; }
        public TranslationDouble Number { get; private set; }
        public UntranslationDouble(TranslationDouble number) 
        {
            Number = number;
            Result = Translating();
        }
        private double Translating()
        {
            int order = TranslatingOrder();
            string result = ShiftAndTranslating(order);
            if(Number.Sign == "1")
                return double.Parse(result) * -1;
            return double.Parse(result);
        }

        private int TranslatingOrder()
        {
            int order = int.Parse(TranslatingSS.TranslatingInTen(Number.OrderBin));
            order -= 127;
            return order;
        }
        private string ShiftAndTranslating(int order0)
        {
            string num0 = "1," + Number.Mantissa;
            int order = Math.Abs(order0);
            string num;
            if (order0 >= 0)
                num = ShiftRight(order, num0);
            else
                num = ShiftLeft(order, num0);
            double result = double.Parse(num);
            return TranslatingSS.TranslateInDecDouble(result);
        }
        private string ShiftRight(int order, string num0) 
        {
            string num = num0.Replace(",", "");
            string result = num.Substring(0, order + 1) + "," + num.Substring(order + 1);
            return result;
        }
        private string ShiftLeft(int order, string num0)
        {
            string[] i_d = num0.Split(',');
            string num = num0.Replace(",", "");
            int comma = num0.IndexOf(",");
            if (i_d[0].Length <= order)
                return "0," + AddZeroLeft(order, num);
            else
                return num.Substring(0, comma - order) + "," + num.Substring(comma - order);
        }
        private string AddZeroLeft(int order, string num)
        { 
            StringBuilder val = new StringBuilder();
            for (int i = 0; i < order - num.TrimEnd('0').Length + 1; i++)
            {
                val.Append("0");
            }
            val.Append(num);
            return val.ToString();
        }
    }
}
