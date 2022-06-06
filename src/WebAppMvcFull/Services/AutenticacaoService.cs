using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppMvcFull.Models;

namespace WebAppMvcFull.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        //metodos implementados mais simples possivel para login e senha
        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin),
                Encoding.UTF8, "application/json"
                );
            var response = await _httpClient.PostAsync("https://localhost:44331/api/Account/login", loginContent);

            //testar retorno
            //var teste = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }



        public async Task<UsuarioRespostaLogin> Registro(UsuarioDtos usuarioDtos)
        {
            var registroContent = new StringContent(JsonSerializer.Serialize(usuarioDtos),
                 Encoding.UTF8, "application/json"
                );
            var response = await _httpClient.PostAsync("https://localhost:44331/api/Account/register", registroContent);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
        }
    }
}
