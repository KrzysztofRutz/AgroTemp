using AgroTemp.Application.Configuration.Commands;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Entities;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Commands.Users.AddUser;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _userRepository.IsAlreadyExistAsync(request.Login, cancellationToken);

        if (isAlreadyExist) 
        {
            throw new UserIsAlreadyExistException(request.Login);
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Login = request.Login,
            Password = request.Password,
            TypeOfUser = request.TypeOfUser,
        };

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();

        var userDto = _mapper.Map<UserDto>(user);
        
        return userDto;
    }
}
