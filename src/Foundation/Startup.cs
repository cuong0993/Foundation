﻿using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentApi.OAuth;
using EPiServer.ServiceApi.Owin;
using EPiServer.ServiceLocation;
using Foundation;
using Foundation.Cms.Extensions;
using Foundation.Cms.Identity;
using Mediachase.Data.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartup(typeof(Startup))]
namespace Foundation
{
    public class Startup
    {
        private readonly IConnectionStringHandler _connectionStringHandler;

        public Startup() : this(ServiceLocator.Current.GetInstance<IConnectionStringHandler>())
        {
            // Parameterless constructor required by OWIN.
        }

        public Startup(IConnectionStringHandler connectionStringHandler)
        {
            _connectionStringHandler = connectionStringHandler;
        }

        public void Configuration(IAppBuilder app)
        {
            app.ConfigureAuthentication(_connectionStringHandler.Commerce.Name);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/user")
            });
            app.UseServiceApiIdentityTokenAuthorization<ApplicationUserManager<SiteUser>, SiteUser>(new ServiceApiTokenAuthorizationOptions()
            {
                RequireSsl = false,
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60)
            });
        }
    }
}