using System;
using System.Collections.Generic;

namespace IntroASP.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Beers = new HashSet<Beer>();
        }

        public int BrandId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
