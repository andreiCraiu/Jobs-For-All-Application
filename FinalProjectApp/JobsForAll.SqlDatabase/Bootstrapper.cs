using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using JobsForAll.SqlDatabase.Context;
using JobsForAll.SqlDatabase.Contracts;
using JobsForAll.SqlDatabase.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace JobsForAll.SqlDatabase
{
    public static class Bootstrapper
    {
        public static void SetUp(IServiceCollection services, string connection)
        {
            services.AddDbContext<IDataCore, DataCore>(it => it.UseSqlServer(connection), ServiceLifetime.Scoped);
            services.AddSingleton<IDbMapper, DbMapper>();
            services.AddSingleton<IRepository, Repository>();
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataCore>()
                .AddDefaultTokenProviders();
        }
    }
}
