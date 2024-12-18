using app_store.Common.Commands.Producers;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Producers
{
    public class RemoveProducerCommandHandler : IRequestHandler<RemoveProducerCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveProducerCommandHandler> _logger;
        public RemoveProducerCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveProducerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(RemoveProducerCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<Producer>().DeleteByIdAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessRemove(nameof(Producer), request.Id));
            return Result.Success();
        }

    }
}
