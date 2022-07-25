using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public UserManager<ApplicationUser> _UserManager { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }


        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            ApplicationUser user = new()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await _UserManager.CreateAsync(user,signUpModel.Password);

        }

    }
}
