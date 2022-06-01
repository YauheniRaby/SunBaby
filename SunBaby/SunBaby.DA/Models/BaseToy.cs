using SunBaby.DA.Models.Abstract;
using System;

namespace SunBaby.DA.Models
{
    public class BaseToy : IDataModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
