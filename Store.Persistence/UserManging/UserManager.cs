using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Infrastructure.ManagingUser;
using Store.Application.Contracts.Infrastructure.UserManager;
using Store.Dal.Context;
using Store.Domain.Entities.Users;


namespace Store.Persistence.UserManging
{
    public class UserManager : IUserManager
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;


        public UserManager(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;

        }

        // User Management
        public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Users.FindAsync(id).AsTask();
        }

        public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower(),
            cancellationToken);
        }

        public Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower(),
                cancellationToken);
        }

        public async Task<IdentityResult> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            if (await IsEmailExistsAsync(user.Email, cancellationToken))
            {
                return IdentityResult.Failed("Email is already exists");
            }

            user.PasswordHashed = _passwordHasher.HashPassword(user.PasswordHashed);

            await _context.Users.AddAsync(user, cancellationToken);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                return IdentityResult.Success();
            }

            return IdentityResult.Failed();
        }

        public async Task<bool> UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);

            return (await _context.SaveChangesAsync(cancellationToken) > 0);
        }

        public async Task<bool> DeleteUserAsync(User user, CancellationToken cancellationToken) // Soft delete
        {
            user.IsDeleted = true;
            return (await _context.SaveChangesAsync(cancellationToken) > 0);
        }

        public async Task<bool> ChangePasswordAsync(User user, string newPassword, CancellationToken cancellationToken)
        {
            user.PasswordHashed = _passwordHasher.HashPassword(newPassword);
            _context.Users.Update(user);
            return (await _context.SaveChangesAsync(cancellationToken) > 0);
        }

        public bool ValidatePassword(User user, string password)
        {
            return _passwordHasher.VerifyPassword(password, user.PasswordHashed);
        }


        // Token Management
        public async Task<bool> AssignRefreshTokenToUserAsync(User user, string refreshToken, DateTime ExpiresOn,
            string createdByIp, CancellationToken cancellationToken)
        {
            var token = new RefreshToken
            {
                Token = refreshToken,
                ExpiresOn = ExpiresOn,
                CreatedByIp = createdByIp,
                User = user,

            };

            await _context.RefreshTokens.AddAsync(token, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> MarkTokenAsUsed(string refreshToken, CancellationToken cancellationToken)
        {
            int affectedRows = await _context.RefreshTokens
            .Where(r => r.Token == refreshToken)
            .ExecuteUpdateAsync(update => update.SetProperty(r => r.IsUsed, true), cancellationToken);

            return (affectedRows > 0);
        }

        public async Task<IdentityResult> RevokeRefreshTokenAsync(string refreshToken, string revokedByIp, CancellationToken cancellationToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(t => t.Token == refreshToken, cancellationToken);

            if (token == null)
                return IdentityResult.Failed("Invalid RefreshToken");

            token.IsRevoked = true;
            return (await _context.SaveChangesAsync(cancellationToken) > 0)
                ? IdentityResult.Success() : IdentityResult.Failed();
        }

        public async Task RevokeRefreshTokensByIpAddressAsync(string ipAddress, CancellationToken cancellationToken)
        {
            var tokens = await _context.RefreshTokens.Where(r => r.CreatedByIp == ipAddress)
                 .ToListAsync(cancellationToken);

            if (tokens.Any())
            {
                tokens.ForEach(t => t.IsRevoked = true);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task RevokeAllUserRefreshTokens(User user, CancellationToken cancellationToken)
        {
            var tokens = await _context.RefreshTokens.Where(r => r.UserId == user.Id)
                 .ToListAsync();

            _context.RemoveRange(tokens);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveExpiredTokensAsync(CancellationToken cancellationToken)
        {
            var tokens = await _context.RefreshTokens.Where(r => r.ExpiresOn > DateTime.UtcNow)
                .ToListAsync(cancellationToken);
        }

        // Role Management
        public async Task<IdentityResult> AssignRoleToUserAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.SingleAsync(r => r.Name.ToLower() == roleName.ToLower(),
                cancellationToken);

            if (role == null)
                return IdentityResult.Failed($"{roleName} is not exist, it should be added first");

            user.Roles.Add(role);
            return await _context.SaveChangesAsync(cancellationToken) > 0 ?
                IdentityResult.Success() : IdentityResult.Failed("Unexpected Error");
        }
        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return await _context.Users.Where(u => u.Roles.Any(r => r.Name.ToLower() == roleName.ToLower()))
                .ToListAsync(cancellationToken);
        }




    }
}
