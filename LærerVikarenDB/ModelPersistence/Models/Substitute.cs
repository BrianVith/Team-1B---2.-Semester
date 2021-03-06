using System;
using System.Collections.Generic;
using System.Text;

namespace ModelPersistence.Models
{
    public class Substitute
    {

        private int substituteID;

        public int SubstituteID
        {
            get { return substituteID; }
            set { substituteID = value; }
        }

        private int schoolID;

        public int SchoolID
        {
            get { return schoolID; }
            set { schoolID = value; }
        }

        private int courseID;

        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        private int availableID;

        public int AvaiableID
        {
            get { return availableID; }
            set { availableID = value; }
        }

        private int substituteHours;

        public int SubstituteHours
        {
            get { return substituteHours; }
            set { substituteHours = value; }
        }

    }
}
