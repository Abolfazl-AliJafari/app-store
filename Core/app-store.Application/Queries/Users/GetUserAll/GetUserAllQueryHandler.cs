using app_store.Common.Queries.Users.GetUserAll;
using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Users.GetUserAll
{
    public class GetUserAllQueryHandler : IRequestHandler<GetUserAllQuery, Result<IEnumerable<GetUserAllResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetUserAllQueryHandler> _logger;

        public GetUserAllQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetUserAllQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<IEnumerable<GetUserAllResponse>>> Handle(GetUserAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<User>().GetAllAsync(cancellationToken);
            if (entities == null)
            {
                return Result<IEnumerable<GetUserAllResponse>>.Failure(OperationsExceptions.NoData(nameof(User)), null);
            }
            var mappedEntities = GetUserAllQueryMapper.Map(entities);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(User)));
            return Result<IEnumerable<GetUserAllResponse>>.Success(mappedEntities);
        }

    }
}
