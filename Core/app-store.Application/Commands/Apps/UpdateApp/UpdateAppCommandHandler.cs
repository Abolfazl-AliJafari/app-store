using app_store.Common.Commands.Apps;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Apps.UpdateApp
{
    public class UpdateAppCommandHandler : IRequestHandler<UpdateAppCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateAppCommandHandler> _logger;
        public UpdateAppCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateAppCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(UpdateAppCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<App>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result.Failure(OperationsExceptions.NotFound(nameof(App), request.Id));
            }
            entity.Update(
                request.Title,
                request.Description,
                request.PhotosGallery,
                request.IconId,
                request.ProducerId,
                request.AppFileId,
                request.CategoryId);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessUpdate(nameof(App), request.Id));
            return Result.Success();
        }
    }
}
