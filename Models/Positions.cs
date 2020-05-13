using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Reviews = new HashSet<Reviews>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
