using app_store.Common.Commands.Producers;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Producers.CreateProducer
{
    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateProducerCommandHandler> _logger;

        public CreateProducerCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<CreateProducerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<Guid>> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = CreateProducerCommandMapper.Map(request);
            await _unitOfWork.Repository<Producer>().AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessAdd(nameof(Producer)));
            return Result<Guid>.Success(entity.Id);
        }
    }
}
