using Events.Core.Auth.Models;

namespace Events.Core.Auth.Identity.Interface
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(ApplicationUser user, IList<string> roles);
    }
}
