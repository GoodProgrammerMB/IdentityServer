using System.Collections.Generic;
using IdentityServer4.Models;

namespace GP.IdentityServer.ConfigMenager
{
    public class ResourceManager
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                //new ApiResource("movieAPI", "Movie API")
            };
    }
}
