using System;
using System.Collections.Generic;

namespace SunBaby.DA.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public long TelegramId { get; set; }

        public string FirstNameTelegram { get; set; }

        public string LastNameTelegram { get; set; }

        public string LoginTelegram { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportDate { get; set; }

        public int Address { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
