using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator26._12._22_Informatic_
{
    public class TranslatingInteger
    {
        public enum NameStep
        { 
            translationWithoutZero,
            translationWithZero,
            negative,
            addOne
        };
        private Dictionary<NameStep, string> Steps0 = new Dictionary<NameStep, string>();
        public int Number { get; private set; }
        public string Result { get; private set; }
        public bool Sign { get; private set; }
        public Dictionary<NameStep, string> Steps { get; private set; }

        public TranslatingInteger(int num)
        {
            Number = num;
            Sign = Number >= 0;
            Result = Translation();
            Steps = Steps0;
        }
        private string Translation()
        {
            TranslationWithoutZero();
            AddZero();
            if (Sign)
                return Steps0[NameStep.translationWithZero];
            TranslatingNegative();
            AddingOne();
            return Steps0[NameStep.addOne];

        }
        private void TranslationWithoutZero()
        {
            Steps0[NameStep.translationWithoutZero] = TranslatingSS.TranslatingInBin(Number.ToString());
        }

        public void AddZero()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 8 - Steps0[NameStep.translationWithoutZero].Length; i++)
            {
                stringBuilder.Append(0);
            }
            stringBuilder.Append(Steps0[NameStep.translationWithoutZero]);
            Steps0[NameStep.translationWithZero] = stringBuilder.ToString();
        }
        private void TranslatingNegative()
        {
            string str = Steps0[NameStep.translationWithZero];
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                    result.Append('1');
                else
                    result.Append('0');
            }
            Steps0[NameStep.negative] = result.ToString();
        }
        private void AddingOne()
        {
            string str = Steps0[NameStep.negative];
            int num = Convert.ToInt32(str, 2);
            Steps0[NameStep.addOne] = AddUpBin.Sum(Steps0[NameStep.negative], "1");
        }
    }
}
