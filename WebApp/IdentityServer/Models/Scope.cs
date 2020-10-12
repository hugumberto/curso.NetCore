using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class Scope
    {
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }

        public Guid ApplicationId { get; set; }

        public virtual Application Application { get; set; }

    }
}
