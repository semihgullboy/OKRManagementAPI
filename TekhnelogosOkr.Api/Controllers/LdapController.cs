using Microsoft.AspNetCore.Mvc;
using System.Net;
using TekhnelogosOkr.Api.Controllers;
using TekhnelogosOkr.Business.Abstract;

namespace TekhnelogosOkr.WebAPI.Controllers
{
    [ApiController]
    public class LdapController : BaseController
    {
        private readonly ILdapService _ldapService;

        public LdapController(ILdapService ldapService)
        {
            _ldapService = ldapService;
        }

        [HttpPost("importUsers")] //LDAP Üzerinden kullanıcıları veritabanına eklemek için kullanılan işlem
        public async Task<IActionResult> FetchUsers()
        {
            try
            {
                await _ldapService.ImportUsersFromLdapAsync();
                return Ok("Kullanıcılar kaydedildi.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Sunucu Hatası: {ex.Message}");
            }
        }
    }
}