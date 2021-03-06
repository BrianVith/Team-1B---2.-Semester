using System;
using System.Collections.Generic;
using System.Text;

namespace ModelPersistence.Models
{
    public class TimePeriod
    {
        private int timePeriodID;

        public int TimePeriodID
        {
            get { return timePeriodID; }
            set { timePeriodID = value; }
        }


        private string timePeriodAvailable;

        public string TimePeriodAvailable
        {
            get { return timePeriodAvailable; }
            set { timePeriodAvailable = value; }
        }

    }
}
