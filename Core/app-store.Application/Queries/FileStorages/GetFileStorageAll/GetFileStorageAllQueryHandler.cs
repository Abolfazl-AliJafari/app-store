using app_store.Common.Queries.FileStorages.GetFileStorageAll;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.FileStorages.GetFileStorageAll
{
    public class GetFileStorageAllQueryHandler : IRequestHandler<GetFileStorageAllQuery, Result<IEnumerable<GetFileStorageAllResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetFileStorageAllQueryHandler> _logger;

        public GetFileStorageAllQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetFileStorageAllQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<IEnumerable<GetFileStorageAllResponse>>> Handle(GetFileStorageAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<FileStorage>().GetAllAsync(cancellationToken);
            if (entities == null)
            {
                return Result<IEnumerable<GetFileStorageAllResponse>>.Failure(OperationsExceptions.NoData(nameof(FileStorage)), null);
            }

            var mappedEntities = GetFileStorageAllQueryMapper.Map(entities);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(FileStorage)));
            return Result<IEnumerable<GetFileStorageAllResponse>>.Success(mappedEntities);
        }
    }
}
