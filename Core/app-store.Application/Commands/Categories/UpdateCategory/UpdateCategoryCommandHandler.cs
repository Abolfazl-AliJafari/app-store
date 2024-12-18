using app_store.Common.Commands.Categories;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        public UpdateCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateCategoryCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result.Failure(OperationsExceptions.NotFound(nameof(Category), request.Id));
            }
            entity.Update(
                request.Title,
                request.MainCategoryId
                );
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessUpdate(nameof(Category), request.Id));
            return Result.Success();
        }
    }
}
