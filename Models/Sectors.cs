using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Sectors
    {
        public Sectors()
        {
            Companies = new HashSet<Companies>();
        }

        public string Id { get; set; }
        public string Sector { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
    }
}
