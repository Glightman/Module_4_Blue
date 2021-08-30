using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarShopAPI.Services
{
    public interface IAuthService
    {
        public Task<SignInResult> GetUser(IdentityUser identityUser);
        public Task<IdentityResult> Create(IdentityUser identityUser);
    }
}