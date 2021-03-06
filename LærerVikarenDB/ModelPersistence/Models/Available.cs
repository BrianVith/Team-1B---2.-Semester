using System;
using System.Collections.Generic;
using System.Text;

namespace ModelPersistence.Models
{
    public class Available
    {
        private int availableID;

        public int AvailableID
        {
            get { return availableID; }
            set { availableID = value; }
        }    

        private DateTime availableDate;

        public DateTime AvailableDate
        {
            get { return availableDate; }
            set { availableDate = value; }
        }

        private int teacherID;

        public int TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        private int timePeriodID;

        public int TimePeriodID
        {
            get { return timePeriodID; }
            set { timePeriodID = value; }
        }


    }
}
