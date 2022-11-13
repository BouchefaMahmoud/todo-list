using Core.Security;
using Domain.Interfaces;
using Domain.Interfaces.RepositoriesInt;
using Infrastructure.Persistence;
using Infrastructure.Persistence.ContextImpl;
using Infrastructure.Persistence.ContextInt;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Query.interfaces;
using Query.Services;

namespace TodoListApi.Extensions
{
    public static class ContextExtensions
    {

        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            if(configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
                return;
            }
            services.AddDbContext<TodoListContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.TryAddScoped<ITodoListContext, TodoListContext>();
            services.TryAddScoped<ITodoListUnitOfWork, TodoListUnitOfWork>();

            /*
             * Optionnel : Audit 
             */
            #region
            // Useful for auditable entity
            services.AddHttpContextAccessor();
            services.AddTransient<IUserService>(x => new UserService(() => x.GetService<IHttpContextAccessor>().HttpContext?.User));
            #endregion
        }

        /// <summary>
        /// Configures the context services (repositories).
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static void ConfigureContextServices(this IServiceCollection services)
        {
            //Read Repositories
            services.TryAddScoped<ITodoListReadRepository, TodoListReadRepository>();
            services.TryAddScoped<ITaskReadRepository, TaskReadRepository>();


            // Create and update Repositories
            services.TryAddScoped<ITodoListRepository, TodoListRepository>();
            services.TryAddScoped<ITaskRepository, TaskRepository>();

        }
    }
}
