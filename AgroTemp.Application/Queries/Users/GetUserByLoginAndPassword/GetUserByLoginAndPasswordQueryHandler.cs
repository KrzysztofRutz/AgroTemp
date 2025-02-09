using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions;
using AgroTemp.Domain.Exceptions;
using AutoMapper;

namespace AgroTemp.Application.Queries.Users.GetUserByLoginAndPassword;

public class GetUserByLoginAndPasswordQueryHandler : IQueryHandler<GetUserByLoginAndPasswordQuery, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByLoginAndPasswordQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLoginAndPasswordAsync(request.login, request.password, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(request.login);
        }

        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}
