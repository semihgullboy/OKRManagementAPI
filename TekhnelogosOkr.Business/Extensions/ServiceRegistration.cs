using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TekhnelogosOkr.Business.Abstract;
using TekhnelogosOkr.Business.Concrete;
using TekhnelogosOkr.Business.Configurations;
using TekhnelogosOkr.Business.MappingProfiles;
using TekhnelogosOkr.Business.ValidationRules.FluentValidation;
using TekhnelogosOkr.Business.ValidationRules.FluentValidation.Authentication;
using TekhnelogosOkr.Business.ValidationRules.FluentValidation.Department;
using TekhnelogosOkr.Business.ValidationRules.FluentValidation.KeyResult;
using TekhnelogosOkr.Business.ValidationRules.FluentValidation.OkrObjective;
using TekhnelogosOkr.Business.ValidationRules.FluentValidation.Role;
using TekhnelogosOkr.Validators;
using TekhnelogosOkr.ViewModel.OkrObjectiveTransaction;
using TekhnelogosOkr.ViewModel.Suggestion;

namespace TekhnelogosOkr.Business.Extensions
{
    public static class ServiceRegistration
    {
        [Obsolete]
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<LdapSettings>(configuration.GetSection("LdapSettings"));

            //JWt Token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = configuration["JWTAuth:ValidAudienceURL"],
                    ValidIssuer = configuration["JWTAuth:ValidIssuerURL"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTAuth:SecretKey"])),

                    RoleClaimType = ClaimTypes.Role,

                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    {
                        return expires != null ? expires > DateTime.UtcNow : false;
                    },

                    NameClaimType = ClaimTypes.Name
                };
            });

            services.AddScoped<IAuthenticationService, LdapAuthenticationManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ILdapService, LdapManager>();
            services.AddScoped<ITokenService, JwtHelper>();
            services.AddScoped<ICompanyObjectiveService, CompanyObjectiveManager>();
            services.AddScoped<IStatusService, StatusManager>();
            services.AddScoped<IOkrObjectiveService, OkrObjectiveManager>();
            services.AddScoped<IKeyResultService, KeyResultManager>();
            services.AddScoped<ISuggestionService, SuggestionManager>();
            services.AddScoped<IOkrObjectiveTransactionService, OkrObjectiveTransactionManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IKeyResultTransactionService, KeyResultTransactionManager>();

            services.AddControllers()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserLoginViewModelValidator>());
            services.AddControllers()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DepartmentViewModelValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCompanyObjectiveViewModelValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateCompanyObjectiveViewModelValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDepartmentOkrObjectiveViewModelValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddOkrObjectiveViewModelValidatorValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateObjectiveViewModelValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateDepartmentOkrObjectiveViewModelValidator>());
            services.AddControllers()
              .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddKeyResultViewModelValidator>());
            services.AddControllers()
             .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateKeyResultViewModelValidator>());
            services.AddControllers()
             .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RoleViewModelValidator>());
            services.AddControllers()
             .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddSuggestionViewModelValidator>());
            services.AddControllers()
             .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddOkrObjectiveTransactionViewModelValidator>());

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}