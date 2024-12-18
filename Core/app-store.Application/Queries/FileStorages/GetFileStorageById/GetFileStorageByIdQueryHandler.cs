using app_store.Common.Queries.FileStorages.GetFileStorageById;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.FileStorages.GetFileStorageById
{
    public class GetFileStorageByIdQueryHandler : IRequestHandler<GetFileStorageByIdQuery, Result<GetFileStorageByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetFileStorageByIdQueryHandler> _logger;
        private readonly IFileService _fileService;
        public GetFileStorageByIdQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetFileStorageByIdQueryHandler> logger,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fileService = fileService;
        }
        public async Task<Result<GetFileStorageByIdResponse>> Handle(GetFileStorageByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<FileStorage>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result<GetFileStorageByIdResponse>.Failure(OperationsExceptions.NotFound(nameof(FileStorage), request.Id), null);
            }
            var result = await _fileService.GetFileUrlsAsync(entity);
            if(!result.IsSuccess)
            {
                throw new Exception(result.Message);
            }
            var mappedEntity = GetFileStorageByIdQueryMapper.Map(entity,result.Data);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(FileStorage)));
            return Result<GetFileStorageByIdResponse>.Success(mappedEntity);
        }

    }
}
