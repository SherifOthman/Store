namespace Store.Application.Contracts.Infrastructure.Authentication;
public interface ILoggedInService
{
    Guid UserId { get; }
}
