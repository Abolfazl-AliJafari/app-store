using app_store.Common.Queries.Apps.GetAppAll;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Apps.GetAppAll
{
    public class GetAppAllQueryHandler : IRequestHandler<GetAppAllQuery, Result<IEnumerable<GetAppAllResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAppAllQueryHandler> _logger;

        public GetAppAllQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetAppAllQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<IEnumerable<GetAppAllResponse>>> Handle(GetAppAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<App>().GetAllAsync(cancellationToken);

            if (entities == null)
            {
                return Result<IEnumerable<GetAppAllResponse>>.Failure(OperationsExceptions.NoData(nameof(App)), null);
            }

            var mappedEntities = GetAppAllQueryMapper.Map(entities);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(App)));
            return Result<IEnumerable<GetAppAllResponse>>.Success(mappedEntities);
        }
    }
}
