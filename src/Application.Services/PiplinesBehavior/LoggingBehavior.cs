using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Services.PiplinesBehavior
{
    
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling {TRequest}", typeof(TRequest).Name);
            var response = await next();
            _logger.LogInformation("Handled {TRequest} with {TResponse} response", typeof(TRequest).Name, typeof(TResponse).Name);

            return response;
        }
    }
}
