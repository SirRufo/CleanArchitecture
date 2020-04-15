using Desktop.Application.Common.Interfaces;
using Desktop.Infrastructure.Authentication;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;

namespace Desktop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services )
        {
            if ( services is null ) throw new ArgumentNullException( nameof( services ) );

            services
                .TryAddSingleton<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
