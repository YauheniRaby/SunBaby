using SunBaby.DA.Models.Abstract;
using System;

namespace SunBaby.DA.Models
{
    public class Order : IDataModel
    {
        public Guid Id { get; set; }

        public int PeriodWeeks { get; set; }

        public DateTime StartRent { get; set; }

        public ToyShort Toy { get; set; }

        public UserShort User { get; set; }
    }
}
