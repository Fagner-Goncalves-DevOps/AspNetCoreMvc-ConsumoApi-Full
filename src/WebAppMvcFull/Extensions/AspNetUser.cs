using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppMvcFull.Extensions;

namespace WebAppMvcFull.Services
{

    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor) 
        {
            _accessor = accessor;
        }


        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool EstaAutenticado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }


        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public string ObterUserToken()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserToken() : "";
        }



        public IEnumerable<Claim> ObterClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _accessor.HttpContext;
        }

        public bool PossuiRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }
    }


}
