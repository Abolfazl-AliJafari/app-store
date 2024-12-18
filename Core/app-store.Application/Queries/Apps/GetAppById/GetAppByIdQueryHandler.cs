using app_store.Common.Queries.Apps.GetAppById;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Apps.GetAppById
{
    public class GetAppByIdQueryHandler : IRequestHandler<GetAppByIdQuery, Result<GetAppByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAppByIdQueryHandler> _logger;
        public GetAppByIdQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetAppByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<GetAppByIdResponse>> Handle(GetAppByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<App>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result<GetAppByIdResponse>.Failure(OperationsExceptions.NotFound(nameof(App), request.Id), null);
            }
            var mappedEntity = GetAppByIdQueryMapper.Map(entity);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(App)));
            return Result<GetAppByIdResponse>.Success(mappedEntity);
        }
    }
}
