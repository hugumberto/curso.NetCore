using IdentityServer.Models;
using IdentityServer.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityServer4.Models.Client> GetClients(String Connectionstring)
        {
            IdentityDBContext _db = new IdentityDBContext(new DbContextOptionsBuilder<IdentityDBContext>().UseLazyLoadingProxies().UseSqlServer(Connectionstring).Options);
            List <IdentityServer4.Models.Client> clientes = new List<IdentityServer4.Models.Client>();
            foreach (IdentityServer.Models.Client cli in _db.Clients.ToList())
            {
                IdentityServer4.Models.Client icli = new IdentityServer4.Models.Client();
                icli.ClientId = cli.UserName;
                icli.AllowedGrantTypes = GrantTypes.ClientCredentials;
                icli.ClientSecrets.Add(new Secret(cli.Password.Sha256()));
                foreach (Scope scope in _db.Scopes.ToList())
                {
                    if(scope.ClientId == cli.ClientId)
                    {
                        icli.AllowedScopes.Add(scope.ApplicationId.ToString());
                    }
                }
                clientes.Add(icli);
            }
            return clientes;
        }
        public static IEnumerable<ApiResource> GetApiResource(String Connectionstring)
        {
            IdentityDBContext _db = new IdentityDBContext(new DbContextOptionsBuilder<IdentityDBContext>().UseSqlServer(Connectionstring).Options);
            List<ApiResource> apiresources = new List<ApiResource>();
            foreach (IdentityServer.Models.Application app in _db.Applications.ToList())
            {
                apiresources.Add(new ApiResource(app.Name, app.Name));
                
            }
            return apiresources;
        }
    }
}
