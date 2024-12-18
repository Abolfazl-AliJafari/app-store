using app_store.Common.Commands.FileStorages;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.FileStorages.UpdateFileStorage
{
    public class UpdateFileStorageCommandHandler : IRequestHandler<UpdateFileStorageCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateFileStorageCommandHandler> _logger;
        public UpdateFileStorageCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateFileStorageCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(UpdateFileStorageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<FileStorage>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result.Failure(OperationsExceptions.NotFound(nameof(FileStorage), request.Id));
            }
            entity.Update(
                request.FileName,
                request.ContentType,
                request.FileSize,
                request.Providers
                );
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessUpdate(nameof(FileStorage), request.Id));
            return Result.Success();
        }

    }
}
