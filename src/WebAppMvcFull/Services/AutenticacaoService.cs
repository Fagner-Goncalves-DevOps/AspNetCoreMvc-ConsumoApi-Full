
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppMvcFull.Extensions;
using WebAppMvcFull.Models;

namespace WebAppMvcFull.Services
{
    public class AutenticacaoService : Service , IAutenticacaoService
    {

        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient,
                                   IOptions<AppSettings> setting)
        {
            httpClient.BaseAddress = new Uri(setting.Value.AutenticacaoUrl);
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {

            var loginContent = ObterConteudo(usuarioLogin);
            var response = await _httpClient.PostAsync( "/api/Account/login" , loginContent);

            if (!TratarErrosResponse(response)) 
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

            

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);
            var response = await _httpClient.PostAsync("/api/Account/register", registroContent);

            if (!TratarErrosResponse(response)) 
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
