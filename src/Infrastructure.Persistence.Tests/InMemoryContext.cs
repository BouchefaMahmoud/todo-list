using Core.Security;
using Infrastructure.Persistence.ContextImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Core;


namespace Infrastructure.Persistence.Tests
{
    public static class InMemoryContext
    {
        public static TodoListContext GetInMemoryContext()
        {
            ILogger<DbContextBase> logger;
            ILoggerFactory loggerFactory = new LoggerFactory();

            logger = loggerFactory.CreateLogger<DbContextBase>();

            UserService userService = new();

            var optionsBuilder = new DbContextOptionsBuilder<TodoListContext>()
                .UseInMemoryDatabase("UnitTests" + DateTime.Now.ToFileTimeUtc())
                .EnableSensitiveDataLogging();

            return new TodoListContext(optionsBuilder.Options, logger, userService);
        }

    }
}
