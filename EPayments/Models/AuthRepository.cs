using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPayments.Models
{
    public class AuthRepository : UserManager<ApplicationUser>
    {
        public AuthRepository(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }

        public static AuthRepository Create(IdentityFactoryOptions<AuthRepository> options,
                                                IOwinContext context)
        {
            var db = context.Get<AuthContext>();

            var manager = new AuthRepository(new UserStore<ApplicationUser>(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return manager;
        }
    }
}