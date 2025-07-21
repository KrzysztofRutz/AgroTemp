using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Enums.User;
using AgroTemp.Domain.Exceptions;

namespace AgroTemp.Application.Commands.Users.UpdateUserParameters;

public class UpdateUserParametersCommandHandler : ICommandHandler<UpdateUserParametersCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserParametersCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserParametersCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.Id);
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.TypeOfUser = (TypeOfUser)Enum.Parse(typeof(TypeOfUser), request.TypeOfUser);

        await _userRepository.UpdateUserParametersAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
