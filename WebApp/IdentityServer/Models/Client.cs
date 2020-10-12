using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public virtual ICollection<Scope> Scopes { get; set; }
    }
}
