using Microsoft.Extensions.DependencyInjection;

using System;

namespace Desktop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services )
        {
            if ( services is null ) throw new ArgumentNullException( nameof( services ) );



            return services;
        }
    }
}
