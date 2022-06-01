using SunBaby.DA.Models.Abstract;
using System;

namespace SunBaby.DA.Models
{
    public class Toy : BaseToy, IDataModel
    {
        public double Tarif1 { get; set; }

        public double Tarif2 { get; set; }

        public double Tarif3 { get; set; }

        public double Tarif4 { get; set; }        
    }
}
