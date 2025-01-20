﻿namespace AvioBooking.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddControllers();

            services.AddProblemDetails();

            return services;
        }
    }
}
