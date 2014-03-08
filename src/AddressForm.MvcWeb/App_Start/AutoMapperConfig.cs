using System;
using System.Linq;
using AddressForm.MvcWeb.Mapping;
using AutoMapper;

namespace AddressForm.MvcWeb
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullDestinationValues = true;

                GetConfigurationFromAssembly(Mapper.Configuration);
            });

            Mapper.AssertConfigurationIsValid();
        }

        private static void GetConfigurationFromAssembly(IConfiguration cfg)
        {
            var profiles = typeof(PersonProfile).Assembly
                .GetTypes()
                .Where(t => t != typeof(Profile) && typeof(Profile).IsAssignableFrom(t));

            foreach (var profile in profiles)
            {
                cfg.AddProfile((Profile)Activator.CreateInstance(profile));
            }
        }
    }
}