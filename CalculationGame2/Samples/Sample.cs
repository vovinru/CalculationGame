using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationGame2.Samples
{
    public class Sample
    {
        #region properties

        /// <summary>
        /// Цифры
        /// </summary>
        public List<int> Numbers
        {
            get;
            set;
        }

        /// <summary>
        /// Знаки выражения
        /// </summary>
        public List<SignType> Signs
        {
            get;
            set;
        }

        #endregion

        #region constructors

        public Sample()
        {
            Numbers = new List<int>();
            Signs = new List<SignType>();
        }

        /// <summary>
        /// Конструктор для создания примера
        /// </summary>
        /// <param name="difficult">сложность (макс. значение (для плюс минус), макс деленое на 5 (деление, умножение) </param>
        /// <param name="countNumbers">количество элементов примера</param>
        public Sample(int difficult, int countNumbers) : this()
        {
            for (int i = 1; i < countNumbers; i++)
            {
                Signs.Add(FactorySample.GetRandomSign());
            }

            for (int i = 0; i < countNumbers; i++)
            {
                if (i == 0)
                    Numbers.Add(FactorySample.GetRandomNumber(Signs[i], difficult));
                else
                    Numbers.Add(FactorySample.GetRandomNumber(Numbers[i - 1], Signs[i - 1], difficult));
            }

        }

        public List<int> GetVariants(int count)
        {
            List<int> variants = new List<int>();
            Random r = new Random();

            int answer = GetAnswer();

            variants.Add(answer);

            for (int i = 1; i < count; i++)
            {
                int def = Math.Min(100, Math.Abs(answer) * 3);

                int variant = answer + r.Next(answer - def, answer + def);

                while (variants.Contains(variant))
                    variant++;

                bool begin = r.Next(0, 100) > 50;
                if (begin)
                    variants.Insert(0, variant);
                else
                    variants.Add(variant);
            }

            return variants;
        }
        public int GetAnswer()
        {
            int ret = Numbers.First();

            for (int i = 0; i < Signs.Count; i++)
            {
                switch(Signs[i])
                {
                    case SignType.Plus:
                        ret += Numbers[i + 1];
                        break;

                    case SignType.Minus:
                        ret -= Numbers[i + 1];
                        break;

                    case SignType.Multiple:
                        ret *= Numbers[i + 1];
                        break;

                    case SignType.Defind:
                        ret /= Numbers[i + 1];
                        break;
                }
            }

            return ret;
        }

        public bool CheckAnswer(int answer)
        {
            return answer == GetAnswer();
        }

        public override string ToString()
        {
            string ret = Numbers[0].ToString();

            for (int i = 1; i < Numbers.Count; i++)
            {
                switch(Signs[i-1])
                {
                    case SignType.Plus:
                        ret += "+";
                        break;
                    case SignType.Minus:
                        ret += "-";
                        break;
                    case SignType.Defind:
                        ret += "/";
                        break;
                    case SignType.Multiple:
                        ret += "*";
                        break;
                }

                ret += Numbers[i];
            }

            return ret;
        }

        #endregion


    }
}
