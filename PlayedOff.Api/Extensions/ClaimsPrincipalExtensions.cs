using System.Security.Claims;
using Microsoft.Identity.Web;

namespace PlayedOff.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetMsalId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));
            
            var objectId = claimsPrincipal.FindFirstValue(ClaimConstants.ObjectId);
            if (objectId != null)
                return Guid.Parse(objectId);

            var oid = claimsPrincipal.FindFirstValue(ClaimConstants.Oid);
            if (oid != null)
                return Guid.Parse(oid);

            var sub = claimsPrincipal.FindFirstValue(ClaimConstants.Sub);
            if (sub != null)
                return Guid.Parse(sub);

            throw new ArgumentException("Claim Principal does not contain a unique identifier for the subject");
        }
    }
}
