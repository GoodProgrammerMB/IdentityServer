using System.Collections.Generic;
using IdentityServer4.Models;

namespace GP.IdentityServer.ConfigMenager
{
    public class IdentityResourcesManager
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
            };
    }
}
