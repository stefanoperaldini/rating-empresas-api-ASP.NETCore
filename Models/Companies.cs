using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Companies
    {
        public Companies()
        {
            CompaniesCities = new HashSet<CompaniesCities>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string sector_id { get; set; }
        public string UrlWeb { get; set; }
        public string Linkedin { get; set; }
        public string Address { get; set; }
        public string sede_id { get; set; }
        public string UrlLogo { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Sectors Sector { get; set; }
        public virtual Cities Sede { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<CompaniesCities> CompaniesCities { get; set; }
    }
}
