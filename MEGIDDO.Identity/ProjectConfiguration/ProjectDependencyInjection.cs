using MEGIDDO.Identity.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.ProjectConfiguration
{
    public static class ProjectDependencyInjection
    {
        public static void DJImplement(this IServiceCollection services)
        {
            services.AddScoped<IMegiddo_Authentication, Megiddo_Authentication>();
        }


    }
}
