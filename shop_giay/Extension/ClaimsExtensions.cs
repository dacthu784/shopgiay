using System.Security.Claims;

namespace shop_giay.Extension
{
    public static class ClaimsExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            // Sử dụng ClaimTypes.Name để lấy giá trị username từ claims
            return user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        public static string GetUsername(this ClaimsPrincipal user)
        {
            // Sử dụng ClaimTypes.Name để lấy giá trị username từ claims
            return user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }
    }
}
