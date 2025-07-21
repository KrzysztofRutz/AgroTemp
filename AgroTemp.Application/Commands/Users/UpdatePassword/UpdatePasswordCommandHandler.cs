using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Users.UpdatePassword;

public class UpdatePasswordCommandHandler : ICommandHandler<UpdatePasswordCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdatePasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        await _userRepository.UpdatePasswordAsync(command.Id, command.Password);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

