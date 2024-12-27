using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("auctionApp","Auction App full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
           new Client
           {
               ClientId = "postman",
               ClientName = "postman",
               AllowedScopes = { "auctionApp","openid","profile" },
               RedirectUris = {"www.postman.com/oAuth2/callback"},
               ClientSecrets = new[] {new Secret("NotASecret".Sha256())},
               AllowedGrantTypes = {GrantType.ResourceOwnerPassword}
           }

        };
}
