using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Users.UpdateUser;

public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.Id);
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Login = request.Login;
        user.Password = request.Password;
        user.TypeOfUser = request.TypeOfUser;

        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();
    }
}
