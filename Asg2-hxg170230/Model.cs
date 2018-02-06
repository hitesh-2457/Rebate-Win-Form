using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Asg2_hxg170230
{
    public class Model
    {

        private String setStrLength(String value, int length)
        {
            if (value.Length > length)
                return value.Substring(0, length);
            else
                return value;
        }

        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = setStrLength(value, 20); }
        }

        private String initial;

        public String Initial
        {
            get { return initial; }
            set { initial = setStrLength(value, 1); }
        }

        private String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = setStrLength(value, 20); }
        }

        private String address1;

        public String Address1
        {
            get { return address1; }
            set { address1 = setStrLength(value, 35); }
        }

        private String address2;

        public String Address2
        {
            get { return address2; }
            set { address2 = setStrLength(value, 35); }
        }

        private String city;

        public String City
        {
            get { return city; }
            set { city = setStrLength(value, 25); }
        }

        private String state;

        public String State
        {
            get { return state; }
            set { state = setStrLength(value, 2); }
        }

        private String zipCode;

        public String ZipCode
        {
            get { return zipCode; }
            set { zipCode = setStrLength(value, 9); }
        }

        private char gender;

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private String phoneNumber;

        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = setStrLength(value, 21); }
        }

        private String eMail;

        public String EMail
        {
            get { return eMail; }
            set { eMail = setStrLength(value, 60); }
        }

        private String proofAttached;

        public String ProofAttached
        {
            get { return proofAttached; }
            set { proofAttached = value; }
        }


        private DateTime dateReceived;

        public DateTime DateReceived
        {
            get { return dateReceived; }
            set { dateReceived = value; }
        }

        private DateTime timeFirstChar;

        public DateTime TimeFirstChar
        {
            get { return timeFirstChar; }
            set { timeFirstChar = value; }
        }

        private DateTime timeSaved;

        public DateTime TimeSaved
        {
            get { return timeSaved; }
            set { timeSaved = value; }
        }

        private int noBackSpace;

        public int NoBackSpace
        {
            get { return noBackSpace; }
            set { noBackSpace = value; }
        }

        public Model()
        {
        }

        public Model(String[] data)
        {
            FirstName = data[0] ?? "";
            Initial = data[1] ?? "";
            LastName = data[2] ?? "";
            Address1 = data[3] ?? "";
            Address2 = data[4] ?? "";
            City = data[5] ?? "";
            State = data[6] ?? "";
            ZipCode = data[7] ?? "";
            Gender = (String.IsNullOrEmpty(data[8])) ? ' ' : data[8][0];
            PhoneNumber = data[9] ?? "";
            EMail = data[10] ?? "";
            ProofAttached = data[11] ?? "";

            DateTime dateRec = new DateTime();
            DateTime.TryParse(data[12] ?? "", out dateRec);
            DateReceived = dateRec;

            DateTime firstChar = new DateTime();
            DateTime.TryParse(data[13] ?? "", out firstChar);
            TimeFirstChar = firstChar;

            DateTime timeSave = new DateTime();
            DateTime.TryParse(data[14] ?? "", out timeSave);
            TimeSaved = timeSave;

            int val = 0;
            Int32.TryParse(data[15] ?? "", out val);
            NoBackSpace = val;
        }

        override
        public String ToString()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            List<object> values = new List<object>();
            foreach (var p in properties)
            {
                values.Add(p.GetValue(this));
            }
            return String.Join("\t", values);
        }
    }
}
