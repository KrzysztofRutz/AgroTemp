using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Users.RemoveUser;

public class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.Id);
        }

        _userRepository.Delete(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
