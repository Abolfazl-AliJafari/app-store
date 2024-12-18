using app_store.Application.Queries.Producers.GetProducerById;
using app_store.Common.Queries.Producers.GetProductById;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Producers
{
    public class GetProducerByIdQueryHandler : IRequestHandler<GetProducerByIdQuery, Result<GetProducerByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProducerByIdQueryHandler> _logger;
        public GetProducerByIdQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetProducerByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<GetProducerByIdResponse>> Handle(GetProducerByIdQuery request, CancellationToken cancellationToken)
        {
                var entity = await _unitOfWork.Repository<Producer>().GetByIdAsync(request.Id, cancellationToken);
                if (entity == null)
                {
                    return Result<GetProducerByIdResponse>.Failure(OperationsExceptions.NotFound(nameof(Producer), request.Id), null);
                }
                var mappedEntity = GetProducerByIdQueryMapper.Map(entity);  
                _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(Producer)));
                return Result<GetProducerByIdResponse>.Success(mappedEntity);
        }

    }
}
