using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Behaviors
{
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<IRequest> _logger;
        public ExceptionHandlingBehavior(
            ILogger<IRequest> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred in {typeof(TRequest).Name}: {ex.Message}");
                throw new ApplicationException($"An error occurred while processing {typeof(TRequest).Name}", ex);
            }
        }
    }
}
