using Desktop.Presentation.Common.Interfaces;
using Desktop.Presentation.Common.Interfaces.Impl;
using Desktop.Presentation.ViewModels;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace Desktop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation( this IServiceCollection services )
        {
            if ( services is null ) throw new ArgumentNullException( nameof( services ) );

            services
                .AddSingleton<INavigationService, NavigationService>()

                .AddSingleton<MainViewModel>()
                .AddTransient<LoginViewModel>()
                .AddTransient<HomeViewModel>();

            return services;
        }
    }
}
