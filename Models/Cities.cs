using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Companies = new HashSet<Companies>();
            CompaniesCities = new HashSet<CompaniesCities>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string RegionId { get; set; }
        public string ProvinceId { get; set; }

        public virtual Provinces Province { get; set; }
        public virtual Regions Region { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<CompaniesCities> CompaniesCities { get; set; }
    }
}
