using System;

namespace Zodiac.Models
{
    internal class User
    {
        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

    }
}
