﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SUKenworth.Startup))]
namespace SUKenworth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
