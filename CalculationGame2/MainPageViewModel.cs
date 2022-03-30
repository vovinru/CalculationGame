using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationGame2
{
    public class MainPageViewModel:BaseViewModel
    {
        #region propertyes

        public int Record
        {
            get
            {
                if (App.Current.Properties.ContainsKey("Record"))
                    return Convert.ToInt32(App.Current.Properties["Record"]);
                return 0;
            }
        }

        #endregion

    }
}