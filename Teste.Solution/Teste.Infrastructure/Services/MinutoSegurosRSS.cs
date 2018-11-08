using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teste.Infrastructure.Configurations;

namespace Teste.Infrastructure.Services
{
    public class MinutoSegurosRSS
    {
        public MinutoSegurosRSS()
        {
        }

        public string GetFeed()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://www.minutoseguros.com.br/");

            var response = client.GetAsync("blog/feed/").Result;
            response.EnsureSuccessStatusCode();

            HttpContent content = response.Content;
            Task<string> result = content.ReadAsStringAsync();
            
            return result.Result;
        }
    }
}
