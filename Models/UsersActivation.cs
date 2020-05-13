using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class UsersActivation
    {
        public string Id { get; set; }
        public string VerificationCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? VerifiedAt { get; set; }

        public virtual Users IdNavigation { get; set; }
    }
}
