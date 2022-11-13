using MediatR;

namespace TodoListApi.Extensions
{
    public static class MediatRExtensions
    {

        /// <summary>
        /// Configures the MediatR.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Program));
        }
    }
}
