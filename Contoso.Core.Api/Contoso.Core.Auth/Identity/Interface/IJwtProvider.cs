using Contoso.Core.Auth.Models;

namespace Contoso.Core.Auth.Identity.Interface
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(ApplicationUser user, IList<string> roles);
    }
}
