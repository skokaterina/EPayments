using EPayments.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: OwinStartup(typeof(EPayments.App_Start.Startup))]

namespace EPayments.App_Start
{
    public class Startup
    {        
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AuthContext>(AuthContext.Create);
            app.CreatePerOwinContext<AuthRepository>(AuthRepository.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}