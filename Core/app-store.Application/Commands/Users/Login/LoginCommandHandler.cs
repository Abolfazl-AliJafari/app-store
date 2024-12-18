using app_store.Common.Commands.Users;
using app_store.Domain.Helper;
using app_store.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace app_store.Application.Commands.Users.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<LoginCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Result<bool>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>(false, false);
            await Task.Run(() =>
            {
                result = _unitOfWork.UserRepository.Login(request.UserName, request.Password);
                _logger.LogInformation(result.Message);
            });
            return result;
        }


    }
}
