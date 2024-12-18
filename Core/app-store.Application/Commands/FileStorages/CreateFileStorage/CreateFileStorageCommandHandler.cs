using app_store.Common.Commands.FileStorages;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.FileStorages.CreateFileStorage
{
    public class CreateFileStorageCommandHandler : IRequestHandler<CreateFileStorageCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateFileStorageCommandHandler> _logger;
        private readonly IFileService _fileService;

        public CreateFileStorageCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<CreateFileStorageCommandHandler> logger,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fileService = fileService;
        }
        public async Task<Result<Guid>> Handle(CreateFileStorageCommand request, CancellationToken cancellationToken)
        {
            var entity = CreateFileStorageCommandMapper.Map(request);
            await _unitOfWork.Repository<FileStorage>().AddAsync(entity, cancellationToken);
            foreach (var provider in entity.Providers)
            {
                var result = await _fileService.UploadFileAsync(entity,request.FileStream,provider);
                if(!result.IsSuccess)
                {
                    throw new Exception(result.Message);
                }
            }
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessAdd(nameof(FileStorage)));
            return Result<Guid>.Success(entity.Id);

        }

    }
}
