using app_store.Common.Queries.Categories;
using app_store.Common.Queries.Categories.GetCategoryAll;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Queries.Categories.GetCategotyAll
{
    public class GetCategoryAllQueryHandler : IRequestHandler<GetCategoryAllQuery, Result<IEnumerable<GetCategoryAllResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetCategoryAllQueryHandler> _logger;

        public GetCategoryAllQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetCategoryAllQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<IEnumerable<GetCategoryAllResponse>>> Handle(GetCategoryAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<Category>().GetAllAsync(cancellationToken);

            if (entities.Count() == 0)
            {
                return Result<IEnumerable<GetCategoryAllResponse>>.Failure(OperationsExceptions.NoData(nameof(Category)), null);
            }
            var mappedEntities = GetCategoryAllQueryMapper.Map(entities);
            _logger.LogInformation(OperationsExceptions.SuccessGetData(nameof(Category)));
            return Result<IEnumerable<GetCategoryAllResponse>>.Success(mappedEntities);
        }
    }
}
