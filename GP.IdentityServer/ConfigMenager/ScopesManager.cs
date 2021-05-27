using System.Collections.Generic;
using IdentityServer4.Models;

namespace GP.IdentityServer.ConfigMenager
{
    public class ScopesManager
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("movieAPI", "Movie API")
            };
    }
}
