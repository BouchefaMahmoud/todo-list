namespace TodoListApi.Extensions
{
    public static class CorsExtensions
    {
        /// <summary>
        /// Configures the cors.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="name">The name.</param>
        public static void ConfigureCors(this IServiceCollection services, string name)
        {
            services.AddCors(options => options.AddPolicy(name, builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
        }
    }
}
