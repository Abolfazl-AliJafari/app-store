using app_store.Common.Queries.Users.GetUserById;
using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;
        public GetUserByIdQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetUserByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<User>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result<GetUserByIdResponse>.Failure(OperationsExceptions.NotFound(nameof(User), request.Id), null);
            }
            var mappedEntity = GetUserByIdQueryMapper.Map(entity);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(User)));
            return Result<GetUserByIdResponse>.Success(mappedEntity);
        }

    }
}
