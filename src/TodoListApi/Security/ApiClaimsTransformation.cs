using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TodoListApi.Security
{
    /// <summary>
    /// Custom claims transformation
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authentication.IClaimsTransformation" />
    public class ApiClaimsTransformation : IClaimsTransformation
    {
        /// <summary>
        /// Provides a central transformation point to change the specified principal.
        /// Note: this will be run on each AuthenticateAsync call, so its safer to
        /// return a new ClaimsPrincipal if your transformation is not idempotent.
        /// </summary>
        /// <param name="principal">The <see cref="T:System.Security.Claims.ClaimsPrincipal" /> to transform.</param>
        /// <returns>
        /// The transformed principal.
        /// </returns>
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Get additional claims here

            return Task.FromResult(principal);
        }
    }
}
