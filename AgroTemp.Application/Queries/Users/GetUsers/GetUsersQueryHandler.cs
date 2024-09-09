using AgroTemp.Application.Configuration.Queries;
using AgroTemp.Application.Dtos;
using AgroTemp.Domain.Abstractions.ReadOnly;
using AutoMapper;

namespace AgroTemp.Application.Queries.Users.GetUsers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserReadOnlyRepository userReadOnlyRepository, IMapper mapper)
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userReadOnlyRepository.GetAllAsync(cancellationToken);

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return usersDto;
    }
}
