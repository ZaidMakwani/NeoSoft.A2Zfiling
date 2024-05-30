using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Infrastructure.EncryptDecrypt;
using NeoSoft.A2Zfiling.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NeoSoft.A2Zfiling.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));            
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
