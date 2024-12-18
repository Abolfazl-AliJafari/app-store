using app_store.Common.Queries.Categories.GetCategoryById;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetCategoryByIdQueryHandler> _logger;
        public GetCategoryByIdQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetCategoryByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result<GetCategoryByIdResponse>.Failure(OperationsExceptions.NotFound(nameof(Category), request.Id), null);
            }
            var mappedEntity = GetCategoryByIdQueryMapper.Map(entity);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(Category)));
            return Result<GetCategoryByIdResponse>.Success(mappedEntity);
        }

    }
}
