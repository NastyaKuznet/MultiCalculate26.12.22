using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public static class SubtractionBin
    {
        public static string Subtraction( string num1, string num2)
        {
            int baze = 2;
            char[] alfabet = new char[2] { '0', '1' };
            if (num1.TrimStart('0').Length < num2.TrimStart('0').Length)
            {
                string c = num2;
                num2 = num1;
                num1 = c;
            }

            num2 = ZeroHeadDown(num1, num2);
            char minusDigit;
            char[] loan = new char[num1.Length];
            StringBuilder columnResult = new StringBuilder();

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1i = num1[i] - '0';
                int num2i = num2[i] - '0';
                if (num1i >= num2i || loan[i] >= num2i)
                {
                    if (num1i >= num2i && loan[i] == 0)
                    {
                        minusDigit = alfabet[num1i - num2i];
                        columnResult.Insert(0, minusDigit);
                    }
                    else
                    {
                        int loani = loan[i] - '0';
                        minusDigit = alfabet[loani - num2i];
                        columnResult.Insert(0, minusDigit);
                    }
                }
                else
                {
                    loan = Loan(num1, i);
                    int withALoan = baze + (loan[i] - '0');
                    minusDigit = alfabet[withALoan - 1 - num2i];
                    columnResult.Insert(0, minusDigit);
                }
            }
            return columnResult.ToString();
        }
        public static string ZeroHeadDown(string numup, string numdown)
        {
            StringBuilder zero = new StringBuilder();
            for (int i = 0; i < numup.Length - numdown.Length; i++)
            {
                zero.Append("0");
            }
            zero.Append(numdown);
            return zero.ToString();
        }
        private static char[] Loan(string num, int startIndex)
        {
            char[] alfabet = new char[2] { '0', '1' };
            int baze = 2;
            int n;
            char[] status = new char[num.Length];
            for (int i = startIndex + 1; i >= 0; i--)
            {
                n = num[i] - '0';
                if (n > 0)
                {
                    status[i] = alfabet[n - 1];
                    return status;
                }
                else
                    status[i] = alfabet[baze - 1];
            }
            return status;
        }
    }
}
