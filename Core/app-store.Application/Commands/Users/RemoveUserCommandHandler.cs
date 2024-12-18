using app_store.Common.Commands.Users;
using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Users
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveUserCommandHandler> _logger;
        public RemoveUserCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Repository<User>().DeleteByIdAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessRemove(nameof(User), request.Id));
            return Result.Success();
        }
    }
}
