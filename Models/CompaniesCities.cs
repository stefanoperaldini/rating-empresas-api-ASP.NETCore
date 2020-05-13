using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class CompaniesCities
    {
        public CompaniesCities()
        {
            Reviews = new HashSet<Reviews>();
        }

        public string CityId { get; set; }
        public string CompanyId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Companies Company { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
