using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TekhnelogosOkr.DataAccess.Abstract;
using TekhnelogosOkr.DataAccess.Concrete.Context;
using TekhnelogosOkr.DataAccess.Concrete.EntityFramework;

namespace TekhnelogosOkr.DataAccess.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TekhnelogosOkrContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TekhnelogosOkrContext")));

            services.AddScoped<IDepartmentDal, EfDepartmentDal>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<ICompanyObjectiveDal, EfCompanyObjectiveDal>();
            services.AddScoped<IStatusDal, EfStatusDal>();
            services.AddScoped<IOkrObjectiveDal, EfOkrObjectiveDal>();
            services.AddScoped<ICompanyObjectiveOkrObjectiveDal, EfCompanyObjectiveOkrObjectiveDal>();
            services.AddScoped<IOkrObjectiveUserDal, EfOkrObjectiveUserDal>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IKeyResultDal, EfKeyResult>();
            services.AddScoped<ISuggestionDal, EfSuggestionDal>();
            services.AddScoped<IOkrObjectiveTransactionDal, EfOkrObjectiveTransactionDal>();
            services.AddScoped<IKeyResultOkrObjectiveDal, EfKeyResultOkrObjectiveDal>();
            services.AddScoped<IUserRoleDal, EfUserRoleDal>();
            services.AddScoped<IKeyResultTransactionDal, EfKeyResultTransactionDal>();
        }
    }
}
