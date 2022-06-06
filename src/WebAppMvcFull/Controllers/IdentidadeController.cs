using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppMvcFull.Models;
using WebAppMvcFull.Services;

namespace WebAppMvcFull.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService) 
        {
            _autenticacaoService = autenticacaoService;
        }


        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioDtos usuarioDtos)
        {
            if (!ModelState.IsValid) return View(usuarioDtos);
            var resposta = await _autenticacaoService.Registro(usuarioDtos);

            await RealizarLogin(resposta);
            //if (false) return View(usuarioDtos);
            return RedirectToAction("Index", "Home");

        }



        [HttpGet]
        [Route("login")]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin) 
        {
            if (!ModelState.IsValid) return View(usuarioLogin);
            var resposta = await _autenticacaoService.Login(usuarioLogin);

            await RealizarLogin(resposta);


           // if (false) return View(usuarioLogin);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Route("Sair")]
        public async Task<IActionResult> Logout() 
        {
            return RedirectToAction("Index", "Home"); //apenas teste no momento
        }



        private async Task RealizarLogin(UsuarioRespostaLogin resposta) 
        {
            var token = ObterTokenFormatado(resposta.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", resposta.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };
            // need install Nuget Bearer
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties); 
        }

        private static JwtSecurityToken ObterTokenFormatado(string jwtToken) 
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
