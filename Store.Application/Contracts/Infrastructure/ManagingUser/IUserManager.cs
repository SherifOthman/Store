using Store.Application.Contracts.Infrastructure.ManagingUser;
using Store.Domain.Entities.Users;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Infrastructure.UserManager
{
    public interface IUserManager
    {
        // User Management
        Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        bool ValidatePassword(User user, string password);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<IdentityResult> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken);
        Task<bool> DeleteUserAsync(User user, CancellationToken cancellationToken); // Soft delete
        Task<bool> ChangePasswordAsync(User user, string newPassword, CancellationToken cancellationToken);

        // Token Management
        Task<bool> AssignRefreshTokenToUserAsync(User user, string refreshToken, DateTime ExpiresOn,
            string createdByIp, CancellationToken cancellationToken);
        Task<bool> MarkTokenAsUsed(string refreshToken, CancellationToken cancellationToken);
        Task<IdentityResult> RevokeRefreshTokenAsync(string token, string revokedByIp, CancellationToken cancellationToken);
        Task RevokeRefreshTokensByIpAddressAsync(string ipAddress, CancellationToken cancellationToken);
        Task RevokeAllUserRefreshTokens(User user, CancellationToken cancellationToken);
        Task RemoveExpiredTokensAsync(CancellationToken cancellationToken);

        // Role Management
        Task<IdentityResult> AssignRoleToUserAsync(User user, string roleName, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName, CancellationToken cancellationToken);
    
    }
}
