using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvcFull.Models;

namespace WebAppMvcFull.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta) 
        {
            if (resposta != null && resposta.Errors.Mensagens.Any()) 
            {
                foreach (var mesangem in resposta.Errors.Mensagens) 
                {
                    ModelState.AddModelError(string.Empty, mesangem);
                }
                return true;
            }
            return false;
        }
    }
}
