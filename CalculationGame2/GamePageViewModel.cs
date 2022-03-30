using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalculationGame2
{
    public class GamePageViewModel:BaseViewModel
    {
        #region properties

        public Game Game
        {
            get;
            set;
        }

        public string TimerString
        {
            get
            {
                return string.Format("Time to end: {0}", Game.RemainingTimeSecond);
            }
        }

        public string ScoreString
        {
            get
            {
                return string.Format("Score: {0}", Game.Score);
            }
        }

        public string LevelString
        {
            get
            {
                return string.Format("Level: {0}", Game.Level);
            }
        }

        public string SampleString
        {
            get
            {
                return Game.CurrentSample.ToString();
            }
        }

        /// <summary>
        /// Общее время игры
        /// </summary>
        public int AllGameTime
        {
            get;
            set;
        }

        //Максимальный уровень
        public int MaxLevel
        {
            get;
            set;
        }

        #endregion

        #region constructors

        public GamePageViewModel()
        {
            MaxLevel = 0;
            AllGameTime = 0;
        }

        public GamePageViewModel(Game game) : this()
        {
            Game = game;
        }


        #endregion

        #region methods

        /// <summary>
        /// Обновить таймер игры
        /// </summary>
        public void UpdateGameTimer()
        {
            Game.RemainingTimeSecond = Math.Max(0, Game.RemainingTimeSecond - 1);
            AllGameTime++;
            OnPropertyChanged(null);
        }

        /// <summary>
        /// Проверка на проигрыш
        /// </summary>
        /// <returns></returns>
        public bool CheckIsGameOver()
        {
            if (Game.RemainingTimeSecond <= 0)
                return true;

            return
                false;
        }

        public bool ToAnswer(int answer)
        {
            if(Game.CurrentSample.CheckAnswer(answer))
            {
                Game.Score += Game.Level;
                Game.Level++;
                Game.RemainingTimeSecond += 1;


                if (Game.Level > MaxLevel)
                    MaxLevel = Game.Level;

                return true;
            }
            else
            {
                Game.Level = Math.Max(1, Game.Level--);
                Game.RemainingTimeSecond -= Math.Min(Game.RemainingTimeSecond, 5);
                return false;
            }

        }

        public void UpdateCurrentSample()
        {
            Game.UpdateSample();
            OnPropertyChanged("SampleString");
        }

        #endregion

    }
}
