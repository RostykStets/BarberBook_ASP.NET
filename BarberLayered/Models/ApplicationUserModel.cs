using BusinessLogicLayer.DTOs;

namespace BarberLayered.Models
{
    public class ApplicationUserModel :ApplicationUserDto
    {
        public ApplicationUserModel()
        {

        }

        public ApplicationUserModel(ApplicationUserDto applicationUserDto)
        {
            this.Id = applicationUserDto.Id;
            this.UserName = applicationUserDto.UserName;
            this.NormalizedUserName = applicationUserDto.NormalizedUserName;
            this.Email = applicationUserDto.Email;
            this.NormalizedEmail = applicationUserDto.NormalizedEmail;
            this.EmailConfirmed = applicationUserDto.EmailConfirmed;
            this.PasswordHash = applicationUserDto.PasswordHash;
            this.SecurityStamp = applicationUserDto.SecurityStamp;
            this.ConcurrencyStamp = applicationUserDto.ConcurrencyStamp;
            this.PhoneNumber = applicationUserDto.PhoneNumber;
            this.PhoneNumberConfirmed = applicationUserDto.PhoneNumberConfirmed;
            this.TwoFactorEnabled = applicationUserDto.TwoFactorEnabled;
            this.LockoutEnd = applicationUserDto.LockoutEnd;
            this.LockoutEnabled = applicationUserDto.LockoutEnabled;
            this.AccessFailedCount = applicationUserDto.AccessFailedCount;
            this.Description = applicationUserDto.Description;
            this.PhotoUri = applicationUserDto.PhotoUri;
            this.PortfolioUri = applicationUserDto.PortfolioUri;
        }

        public ApplicationUserDto ApplicationUserToDto()
        {
            ApplicationUserDto applicationUserDto = new ApplicationUserDto()
            {
                Id = this.Id,
                UserName = this.UserName,
                NormalizedUserName = this.NormalizedUserName,
                Email = this.Email,
                NormalizedEmail = this.NormalizedEmail,
                EmailConfirmed = this.EmailConfirmed,
                PasswordHash = this.PasswordHash,
                SecurityStamp = this.SecurityStamp,
                ConcurrencyStamp = this.ConcurrencyStamp,
                PhoneNumber = this.PhoneNumber,
                PhoneNumberConfirmed = this.PhoneNumberConfirmed,
                TwoFactorEnabled = this.TwoFactorEnabled,
                LockoutEnd = this.LockoutEnd,
                LockoutEnabled = this.LockoutEnabled,
                AccessFailedCount = this.AccessFailedCount,
                Description = this.Description,
                PhotoUri = this.PhotoUri,
                PortfolioUri = this.PortfolioUri
            };


            return applicationUserDto;
        }
    }
}
