using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationGame2.Samples
{
    public static class FactorySample
    {
        /// <summary>
        /// Получить случайный знак
        /// </summary>
        /// <returns></returns>
        public static SignType GetRandomSign()
        {
            Random r = new Random();
            int s = r.Next(1, 4);

            if (s == 1)
                return SignType.Plus;
            if (s == 2)
                return SignType.Minus;
            if (s == 3)
                return SignType.Multiple;

            return SignType.Defind;
        }

        public static int GetRandomNumber(SignType signType, int difficult)
        {
            Random r = new Random();

            if(signType == SignType.Plus || signType == SignType.Minus)
            {
                return r.Next(0, difficult);
            }
            if(signType == SignType.Defind || signType == SignType.Multiple)
            {
                return r.Next(0, difficult / 5);
            }

            return 0;
        }

        public static int GetRandomNumber(int firstNumber, SignType signType, int difficult)
        {
            Random r = new Random();

            if (signType == SignType.Plus || signType == SignType.Minus)
            {
                return r.Next(0, difficult);
            }

            if(signType == SignType.Multiple)
            {
                return r.Next(0, difficult / 5);
            }

            if(signType == SignType.Defind)
            {
                while(true)
                {
                    int ret = r.Next(0, difficult / 5);
                    if (firstNumber % ret == 0)
                        return ret;
                }
            }

            return 0;
        }
    }
}
