using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class SumDoubleCode
    {
        public TranslationDouble Num1 { get; private set; }
        public TranslationDouble Num2 { get; private set; }
        public TranslationDouble Num_1 { get; private set; }
        public TranslationDouble Num_2 { get; private set; }
        public TranslationDouble ResultCode { get; private set; }
        public double ResultDouble { get; private set; }
        private bool IsShift { get; set; }

        public SumDoubleCode (TranslationDouble num1, TranslationDouble num2)
        {
            Num1 = num1;
            Num2 = num2;
            StartTranslation();
            ResultDouble = new UntranslationDouble(ResultCode).Result;
        }

        private void StartTranslation()
        {
            EquateOrders();
            if (Num1.Number > 0 && Num2.Number > 0 || Num1.Number < 0 && Num2.Number < 0)
            {
                SumMantissa();
            }
            else 
            {
                SubtractionMantissa();
            }
        }
        private void EquateOrders()
        {
            if (Num1.OrderDec == Num2.OrderDec)
            {
                if (Math.Abs(Num1.Number) > Math.Abs(Num2.Number))
                {
                    Num_1 = Num1;
                    Num_2 = Num2;
                }
                else
                {
                    Num_1 = Num2;
                    Num_2 = Num1;
                }
            }
            else
            {
                ChangeNumberEntry();
                IsShift = true;
            }
        }
        private void ChangeNumberEntry()
        {
            TranslationDouble Num02;
            if (Num1.OrderDec < Num2.OrderDec)
            {

                Num_1 = Num2;
                Num02 = Num1;
            }
            else
            {
                Num_1 = Num1;
                Num02 = Num2;
            }
            int differenceOrders = Num_1.OrderDec - Num02.OrderDec;
            string mantissa = ShiftMantissa(Num02.Mantissa, differenceOrders);
            Num_2 = new TranslationDouble(Num02.Sign, Num_1.OrderBin, mantissa);
        }
        private string ShiftMantissa(string mantissa, int shift)
        { 
            StringBuilder result = new StringBuilder();
            result.Append(mantissa);
            result.Insert(0, "1");
            for(int i = shift - 1; i > 0; i--)
                result.Insert(0, '0');
            return result.ToString().Substring(0, 23);
        }
        private void SumMantissa()
        {
            string sum;
            if (IsShift)
                sum = AddUpBin.Sum("1" + Num_1.Mantissa, "0" + Num_2.Mantissa);
            else
                sum = AddUpBin.Sum("1" + Num_1.Mantissa, "1" + Num_2.Mantissa);
            if (sum.Length - 23 == 2)
            {
                ResultCode = new TranslationDouble(Num_1.Sign, AddUpBin.Sum(Num_1.OrderBin, "1"), sum.Substring(1, 23));
            }
            else if (sum.Length - 23 == 1)
            {
                ResultCode = new TranslationDouble(Num_1.Sign, Num_1.OrderBin, sum.Substring(1, 23));
            }
            else
            {
                ResultCode = new TranslationDouble(Num_1.Sign, Num_1.OrderBin, sum);
            }
        }
        private void SubtractionMantissa()
        {
            string sub;
            if (IsShift)
                sub = SubtractionBin.Subtraction("1" + Num_1.Mantissa, "0" + Num_2.Mantissa);
            else
                sub = SubtractionBin.Subtraction("1" + Num_1.Mantissa, "1" + Num_2.Mantissa);
            int startIndex = 24 - sub.TrimStart('0').Length;
            string mantissa = AddZeroMantissa(sub.Substring(startIndex + 1));
            if (Math.Abs(Num_1.Number) > Math.Abs(Num_2.Number))
                ResultCode = new TranslationDouble(Num_1.Sign, SubtractionBin.Subtraction(Num_1.OrderBin, TranslatingSS.TranslatingInBin(startIndex.ToString())), mantissa);
            else
                ResultCode = new TranslationDouble(Num_2.Sign, SubtractionBin.Subtraction(Num_1.OrderBin, TranslatingSS.TranslatingInBin(startIndex.ToString())), mantissa);
        }
        private string AddZeroMantissa(string num)
        {
            if (num.Length < 23)
            {
                StringBuilder result = new StringBuilder();
                result.Append(num);
                for (int i = 23 - num.Length; i > 0; i--)
                {
                    result.Append('0');
                }
                num = result.ToString();
            }
            return num;
        }
    }
}
