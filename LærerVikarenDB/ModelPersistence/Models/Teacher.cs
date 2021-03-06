using System;
using System.Collections.Generic;
using System.Text;

namespace ModelPersistence.Models
{
    public class Teacher
    {
        #region Properties

        private int teacherID;

        public int TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        private string teacherName;

        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string socialSecurityNumber;

        public string SocialSecurityNumber
        {
            get { return socialSecurityNumber; }
            set { socialSecurityNumber = value; }
        }

        private DateTime childAttestExpirationDate;

        public DateTime ChildAttestExpirationDate
        {
            get { return childAttestExpirationDate; }
            set { childAttestExpirationDate = value; }
        }

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion


    }
}
