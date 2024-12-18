using app_store.Common.Commands.Producers;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Producers.UpdateProducer
{
    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateProducerCommandHandler> _logger;
        public UpdateProducerCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateProducerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Producer>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result.Failure(OperationsExceptions.NotFound(nameof(Producer), request.Id));
            }
            entity.Update(
                request.Title,
                request.Description
                );
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessUpdate(nameof(Producer), request.Id));
            return Result.Success();
        }
    }
}
