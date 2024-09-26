using Application.Features.Testing.Greeting;
using Domain.Notification;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<GreetingCommand>, GreetingCommandValidator>();


            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<DomainSuccessNotification>, DomainSuccessNotificationHandler>();

            return services;
        }
    }
}
