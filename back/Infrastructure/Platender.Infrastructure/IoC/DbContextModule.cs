using Autofac;
using Microsoft.Extensions.Configuration;
using Platender.Application.EF.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platender.Infrastructure.IoC
{
    public class DbContextModule : Module
    {
        private readonly IConfiguration _configuration;

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var sqlSettings = new SqlConnectionSettings();
            _configuration.GetSection("Sql").Bind(sqlSettings);

            builder.RegisterInstance(sqlSettings).SingleInstance();
        }
    }
}
