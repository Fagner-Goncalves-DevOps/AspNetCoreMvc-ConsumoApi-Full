using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvcFull.Services;

namespace WebAppMvcFull.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services) 
        {

            //add dependecia como cliente http, não singleton etc..
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>(); 


        }
    }
}
