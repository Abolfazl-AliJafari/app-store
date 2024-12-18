using app_store.Common.Commands.Apps;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Apps
{
    public class RemoveAppCommandHandler : IRequestHandler<RemoveAppCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveAppCommandHandler> _logger;
        public RemoveAppCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveAppCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(RemoveAppCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<App>().DeleteByIdAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessRemove(nameof(App), request.Id));
            return Result.Success();
        }
    }
}
