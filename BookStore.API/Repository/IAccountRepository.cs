using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Repository
{
    public interface IAccountRepository
    {
        Task<string> LoginAsync(SignInModel signInModel);
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}