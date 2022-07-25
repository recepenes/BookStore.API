using BookStore.API.Models;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountRepository _accountRepository { get; }

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized(result);
        }

    }
}
