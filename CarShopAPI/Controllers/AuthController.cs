using CarShopAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CarShopAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ApiBaseController
    {
        IAuthService _service;
        public AuthController (IAuthService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cria um novo login de usuário.
        /// </summary>
        /// <param name="identityUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register(IdentityUser identityUser)
        {
            try
            {
                IdentityResult result = _service.Create(identityUser).Result;
                if (!result.Succeeded)
                    throw new Exception();
                identityUser.PasswordHash = "";
                return ApiOk(identityUser);
            }
            catch
            {
                return ApiBadRequest("Erro ao tentar criar usuário.");
            }
        }

        /// <summary>
        /// Cria um novo token para o usuário.
        /// </summary>
        /// <param name="identityUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Token")]
        public IActionResult Token([FromBody] IdentityUser identityUser)
        {
            try
            {
                return ApiOk(_service.GenerateToken(identityUser));
            }
            catch (Exception e)
            {
                return ApiBadRequest(e, e.Message);
            }
        }
    }
}
