using Desktop.Presentation.Common.Interfaces;
using Desktop.Presentation.Common.Interfaces.Impl;
using Desktop.Presentation.ViewModels;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;
using System.Reflection;

namespace Desktop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation( this IServiceCollection services )
        {
            if ( services is null ) throw new ArgumentNullException( nameof( services ) );

            services.TryAddSingleton<IDialogService, MediatorDialogService>();
            services.TryAddSingleton<INavigationService, NavigationService>();

            services.AddMediatR( Assembly.GetExecutingAssembly() );

            services
                .AddSingleton<MainViewModel>()
                .AddTransient<LoginViewModel>()
                .AddTransient<HomeViewModel>()
                .AddTransient<EditNameDialogViewModel>()
                ;

            return services;
        }
    }
}
