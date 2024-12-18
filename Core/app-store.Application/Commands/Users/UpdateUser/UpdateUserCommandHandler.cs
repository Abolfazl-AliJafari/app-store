using app_store.Common.Commands.Users;
using app_store.Domain.Entities.Users;
using app_store.Domain.Helper;
using app_store.Domain.Helper.Exeptions;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        public UpdateUserCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<User>().GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result.Failure(OperationsExceptions.NotFound(nameof(User), request.Id));
            }
            entity.Update(
                request.FirstName,
                request.LastName,
                request.UserName,
                request.Password,
                request.Email);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation(OperationsExceptions.SuccessUpdate(nameof(User), request.Id));
            return Result.Success();
        }
    }
}
