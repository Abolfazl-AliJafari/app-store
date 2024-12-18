using app_store.Common.Commands.FileStorages;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.FileStorages
{
    public class RemoveFileStorageCommandHandler : IRequestHandler<RemoveFileStorageCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveFileStorageCommandHandler> _logger;
        public RemoveFileStorageCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveFileStorageCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(RemoveFileStorageCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<FileStorage>().DeleteByIdAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessRemove(nameof(FileStorage), request.Id));
            return Result.Success();
        }
    }
}
