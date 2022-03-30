using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationGame2
{
    public class FinalPageViewModel:BaseViewModel
    {

        #region propertyes

        public int Score
        {
            get;
            set;
        }

        public int AllGameTime
        {
            get;
            set;
        }

        public int MaxLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Есть ли рекорд
        /// </summary>
        public bool RecordScore
        {
            get;
            set;
        }

        public string ScoreString
        {
            get
            {
                return string.Format("Score: {0}", Score);
            }
        }

        public string AllGameTimeString
        {
            get
            {
                return string.Format("Game time: {0}", AllGameTime);
            }
        }

        public string MaxLevelString
        {
            get
            {
                return string.Format("Maximum level: {0}", MaxLevel);
            }
        }


        #endregion

        #region constructors

        public FinalPageViewModel()
        {

        }

        public FinalPageViewModel(int score, int allGameTime, int maxLevel)
        {
            Score = score;
            AllGameTime = allGameTime;
            MaxLevel = maxLevel;

            if (App.Current.Properties.ContainsKey("Record"))
            {
                int recordCurrent = Convert.ToInt32(App.Current.Properties["Record"]);
                if (recordCurrent <= Score)
                {
                    RecordScore = true;
                }
            }
            else
                RecordScore = true;

            if (RecordScore)
            {
                //Меняем рекорд
                App.Current.Properties["Record"] = Score;
            }
        }

        #endregion

    }
}
