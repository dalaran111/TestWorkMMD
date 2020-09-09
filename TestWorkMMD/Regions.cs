using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWorkMMD
{
    public partial class Regions
    {
        public Regions()
        {
            Countries = new HashSet<Countries>();
        }
        [Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}
