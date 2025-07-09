using System.Security.Claims;

namespace PlayedOff.Domain.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        private const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        private const string Oid = "oid";
        private const string Sub = "sub";

        public static Guid GetAzureOid(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentNullException(nameof(claimsPrincipal));
            
            var objectId = claimsPrincipal.FindFirst(ObjectId)?.Value;
            if (objectId != null)
                return Guid.Parse(objectId);

            var oid = claimsPrincipal.FindFirst(Oid)?.Value;
            if (oid != null)
                return Guid.Parse(oid);

            var sub = claimsPrincipal.FindFirst(Sub)?.Value;
            if (sub != null)
                return Guid.Parse(sub);

            throw new ArgumentException("Claim Principal does not contain a unique identifier for the subject");
        }
    }
}
