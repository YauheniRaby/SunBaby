using SunBaby.DA.Models.Abstract;
using System;

namespace SunBaby.DA.Models
{
    public class BaseUser : IDataModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportDate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
