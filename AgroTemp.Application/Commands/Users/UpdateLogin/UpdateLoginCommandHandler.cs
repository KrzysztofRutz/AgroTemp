using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Users.UpdateLogin;

public class UpdateLoginCommandHandler : ICommandHandler<UpdateLoginCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateLoginCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateLoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        await _userRepository.UpdateLoginAsync(command.Id, command.Login);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

