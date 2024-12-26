using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? PhotoUri { get; set; }
        public string? Description { get; set; }
        public string? PortfolioUri { get; set; }
    }
}
