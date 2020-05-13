using System;
using System.Collections.Generic;

namespace rating_empresas_api_.NET.Models
{
    public partial class Users
    {
        public Users()
        {
            Companies = new HashSet<Companies>();
            Reviews = new HashSet<Reviews>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Linkedin { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ActivatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual UsersActivation UsersActivation { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
