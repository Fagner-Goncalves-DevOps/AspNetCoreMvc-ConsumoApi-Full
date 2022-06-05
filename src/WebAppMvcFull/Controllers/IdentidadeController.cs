using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvcFull.Models;

namespace WebAppMvcFull.Controllers
{
    public class IdentidadeController : Controller
    {
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

            //api conversa para registro

            if (false) return View(usuarioDtos);

            //realizar login no app

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

            if (false) return View(usuarioLogin);

            return RedirectToAction("Index", "Home");
        }







        [HttpGet]
        [Route("Sair")]
        public async Task<IActionResult> Logout() 
        {
            return RedirectToAction("Index", "Home"); //apenas teste no momento
        }


    }
}
