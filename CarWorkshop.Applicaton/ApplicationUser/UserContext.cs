using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }

            var nameIdentifierClaim = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
            var emailClaim = user.FindFirst(c => c.Type == ClaimTypes.Email);

            if (nameIdentifierClaim == null || emailClaim == null)
            {
                return null;
            }

            string id = nameIdentifierClaim.Value;
            string email = emailClaim.Value;

            return new CurrentUser(id, email);
        }
    }
}
