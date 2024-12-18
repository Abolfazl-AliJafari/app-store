using app_store.Application.Queries.Producers.GetProducerAll;
using app_store.Common.Queries.Producers.GetProductAll;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Producers
{
    public class GetProducerAllQueryHandler : IRequestHandler<GetProducerAllQuery, Result<IEnumerable<GetProducerAllResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProducerAllQueryHandler> _logger;

        public GetProducerAllQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetProducerAllQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<IEnumerable<GetProducerAllResponse>>> Handle(GetProducerAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<Producer>().GetAllAsync(cancellationToken);

            if (entities == null)
            {
                return Result<IEnumerable<GetProducerAllResponse>>.Failure(OperationsExceptions.NoData(nameof(Producer)), null);
            }

            var mappedEntities = GetProducerAllQueryMapper.Map(entities);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(Producer)));
            return Result<IEnumerable<GetProducerAllResponse>>.Success(mappedEntities);
        }

    }
}
