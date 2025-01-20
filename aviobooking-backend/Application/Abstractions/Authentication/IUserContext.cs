using Domain.Entities;

namespace Application.Abstractions.Authentication;

public interface IUserContext
{
    StronglyTypedId<User> UserId { get; }
}
