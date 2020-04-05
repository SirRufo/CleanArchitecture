
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddConfiguration<TOptions>( this IServiceCollection services, IConfiguration config, string section ) where TOptions : class
        {
            if ( string.IsNullOrEmpty( section ) )
            {
                section = typeof( TOptions ).Name;
            }
            var instance = Activator.CreateInstance<TOptions>();
            var sectionConfig = config.GetSection( section );
            var optionConfig = new ConfigureFromConfigurationOptions<TOptions>( sectionConfig );
            optionConfig.Configure( instance );
            services.AddSingleton( instance );
            return services;
        }
    }
}