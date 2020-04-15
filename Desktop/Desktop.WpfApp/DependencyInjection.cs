using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;

namespace Desktop.WpfApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPlatform( this IServiceCollection services )
        {
            if ( services is null ) throw new ArgumentNullException( nameof( services ) );

            services.AddMediatR( Assembly.GetExecutingAssembly() );

            return services;
        }
    }
}
