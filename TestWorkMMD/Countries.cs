using System;
using System.Collections.Generic;

namespace TestWorkMMD
{
    public partial class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public int CapitalId { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public int RegionId { get; set; }

        public virtual Citiess Capital { get; set; }
        public virtual Regions Region { get; set; }
    }
}
