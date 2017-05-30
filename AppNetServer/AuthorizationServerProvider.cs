//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace AppNetServer
{
    class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            { 
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                var dbContext = new AppNetEntities();
                var result = dbContext.Auftraggeber
                                .Any(u => u.UserName == context.UserName && u.PasswordHash == context.Password);

                if (context.UserName == "admin" && context.Password == "admin")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                    identity.AddClaim(new Claim("username", "admin"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Anton Markaj"));
                    context.Validated(identity);
                }
                else if (result)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    var firstname = dbContext.Auftraggeber
                                .Where(u => u.UserName == context.UserName && u.PasswordHash == context.Password).FirstOrDefault().vorname;

                    var lastname = dbContext.Auftraggeber
                                .Where(u => u.UserName == context.UserName && u.PasswordHash == context.Password).FirstOrDefault().nachname;

                    var username = dbContext.Auftraggeber
                               .Where(u => u.UserName == context.UserName && u.PasswordHash == context.Password).FirstOrDefault().UserName;

                    identity.AddClaim(new Claim(ClaimTypes.Name, firstname + " " + lastname));
                    identity.AddClaim(new Claim("username", username));
                    context.Validated(identity);

                    Console.WriteLine("Login granted to user \"" + username + "\"");

                    /* identity.AddClaim(new Claim("username", "user"));
                     identity.AddClaim(new Claim(ClaimTypes.Name, "Alfred Sopi"));
                     context.Validated(identity);*/
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username or password is incorrect!");
                    Console.WriteLine("Login failed: Wrong username or password");
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
