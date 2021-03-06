using System;
using System.Collections.Generic;
using System.Text;

namespace ModelPersistence.Models
{
    public class School
    {

        private int schoolID;

        public int SchoolID
        {
            get { return schoolID; }
            set { schoolID = value; }
        }
        
        private string schoolName;

        public string SchoolName
        {
            get { return schoolName; }
            set { schoolName = value; }
        }

        private string schoolAddress;

        public string SchoolAddress
        {
            get { return schoolAddress; }
            set { schoolAddress = value; }
        }

    }
}
