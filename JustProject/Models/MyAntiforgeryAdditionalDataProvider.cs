using Microsoft.AspNetCore.Antiforgery;
using System.Security.Claims;

namespace JustProject.Models
{
    public class MyAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
    {
        public bool HasAntiforgeryToken()
        {
            return true;
        }

        public string GetAdditionalData(HttpContext context)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        public bool ValidateAdditionalData(HttpContext context, string additionalData)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return true;
        }
    }
}
