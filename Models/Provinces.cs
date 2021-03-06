﻿using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Provinces
    {
        public Provinces()
        {
            Cities = new HashSet<Cities>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
