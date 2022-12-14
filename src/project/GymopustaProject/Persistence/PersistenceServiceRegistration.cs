using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("GymopustaConnectionString")));
            services.AddScoped<IMoveRepository, MoveRepository>();
            services.AddScoped<IMoveAreaRepository, MoveAreaRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDescriptionRepository, DescriptionRepository>();
            services.AddScoped<IGIFRepository, GIFRepository>();
            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<IInstructorCustomerRepository, InstructorCustomerRepository>();
            services.AddScoped<IGymProgramItemRepository, GymProgramItemRepository>();
            services.AddScoped<IGymProgramRepository, GymProgramRepository>();

            return services;
        }
    }
}
