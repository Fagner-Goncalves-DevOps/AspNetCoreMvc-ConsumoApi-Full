using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMvcFull.Models;

namespace WebAppMvcFull.Services
{
   public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}
