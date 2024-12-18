using app_store.Common.Commands.Apps;
using app_store.Domain.Entities;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Apps.CreateApp
{
    public class CreateAppCommandHandler : IRequestHandler<CreateAppCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateAppCommandHandler> _logger;

        public CreateAppCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<CreateAppCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<Guid>> Handle(CreateAppCommand request, CancellationToken cancellationToken)
        {
            var entity = CreateAppCommandMapper.Map(request);
            await _unitOfWork.Repository<App>().AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessAdd(nameof(App)));
            return Result<Guid>.Success(entity.Id);
        }
    }
}
