using Microsoft.AspNetCore.Identity;

namespace DebtMaster.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
