using app_store.Common.Commands.Categories;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Categories
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveCategoryCommandHandler> _logger;
        public RemoveCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveCategoryCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<Category>().DeleteByIdAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessRemove(nameof(Category), request.Id));
            return Result.Success();
        }
    }
}
