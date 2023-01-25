using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class TranslationDouble
    {
        public string Sign { get; private set; }
        public double Number { get; private set; }
        public string TranslationBin { get; private set; }
        public int OrderDec { get; private set; }
        public string OrderBin { get; private set; }
        public string NormalizationNum { get; private set; }
        public string Mantissa { get; private set; }
        
        public string Result { get; private set; }

        public TranslationDouble(double number) 
        {
            Number = number;
            Sign = ChoiceSign();
            TranslationBin = TranslatingSS.TranslateInBinDouble(Math.Abs(Number));
            NormalizationAndMantissa();
            Result = Translate();
        }
        public TranslationDouble(string sign, string order, string mantissa) 
        {
            Sign = sign;
            OrderBin = order;
            Mantissa = mantissa;
            Result = Sign + OrderBin + Mantissa;
        }

        private string Translate()
        {
            StringBuilder result = new StringBuilder();
            result.Append(ChoiceSign());
            result.Append(OrderBin);
            result.Append(Mantissa);

            return result.ToString();
        }

        private string ChoiceSign()
        {
            if (Number >= 0)
                return "0";
            else return "1";
        }
        private void NormalizationAndMantissa()
        {
            string[] number = TranslationBin.Split('.');
            if (number[0].Length > 1 && number[0][0] != '0')
                NormalizationLeft();
            else if (number[0].Length == 1 && number[0][0] != '0')
            {
                OrderDec = 0;
                NormalizationNum = TranslationBin;
                AddZeroMantissa(NormalizationNum.Substring(2));
            }
            else
                NormalizationRight();
            CreateOrderBin();
        }
        private void NormalizationLeft()
        {
            StringBuilder result = new StringBuilder();
            result.Append("1.");
            OrderDec =(TranslationBin.IndexOf('.') - 1);
            string num = TranslationBin.Substring(1).Replace(".", "");
            AddZeroMantissa(num);
            result.Append(num);
            NormalizationNum = result.ToString();
        }
        private void NormalizationRight()
        {
            StringBuilder result = new StringBuilder();
            result.Append("1.");
            string parth = int.Parse(TranslationBin.Substring(2)).ToString();
            
            string num;
            if (TranslationBin.Substring(2).Length == 1)
            {
                num = "0";
                OrderDec = -1;
            }
            else
            {
                num = parth.Substring(1);
                OrderDec = int.Parse("-" + (TranslationBin.Substring(2).Length - num.Length).ToString());
            }
            AddZeroMantissa(num);
            result.Append(num);
            NormalizationNum = result.ToString();
        }
        private void CreateOrderBin()
        {
            int order = OrderDec + 127;
            AddZeroOrder(TranslatingSS.TranslatingInBin(order.ToString()));
        }
        private void AddZeroMantissa(string num)
        {
            if (num.Length > 23)
                Mantissa = num.Substring(0, 23);
            if (num.Length < 23)
            {
                StringBuilder result = new StringBuilder();
                result.Append(num);
                for (int i = 23 - num.Length; i > 0; i--)
                { 
                    result.Append('0');
                }
                Mantissa = result.ToString();
            }
            else
                Mantissa = num;
        }
        private void AddZeroOrder(string num)
        {
            if(num.Length > 8)
                Console.WriteLine("Порядок переполнен :(");
            if (num.Length < 8)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 8 - num.Length; i > 0; i--)
                {
                    result.Append('0');
                }
                result.Append(num);
                OrderBin = result.ToString();
            }
            else
                OrderBin = num;
        }
    }
}
