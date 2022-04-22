﻿//KEVIN SEGURA CALVO EXAMEN 2 UTC PROGRA 6
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;


namespace WebApp
{
    public static class ContainerExtensions
    {
        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ISolicitudService, SolicitudService>();
            services.AddTransient<IServicioService, ServicioService>();
            return services;
        }
    }
}
