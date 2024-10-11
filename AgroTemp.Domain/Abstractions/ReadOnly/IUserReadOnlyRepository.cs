using AgroTemp.Domain.Entities;

namespace AgroTemp.Domain.Abstractions.ReadOnly;

public interface IUserReadOnlyRepository : IBaseReadOnlyRepository<User>
{
}
