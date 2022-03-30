using CalculationGame2.Samples;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationGame2
{
    /// <summary>
    /// Класс описывает процесс игры
    /// </summary>
    public class Game
    {
        #region propertyes

        /// <summary>
        /// Оставшиеся время игры
        /// </summary>
        public int RemainingTimeSecond
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public Sample CurrentSample
        {
            get;
            set;
        }

        #endregion

        #region constructors

        public Game()
        {
            Start();
        }

        #endregion

        #region methods

        public void Start()
        {
            RemainingTimeSecond = 30;
            Score = 0;
            Level = 1;

            UpdateSample();
        }

        public void UpdateSample()
        {
            CurrentSample = new Sample(Level + 10, 2);
        }

        #endregion
    }
}
