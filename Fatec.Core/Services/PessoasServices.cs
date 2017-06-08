using Fatec.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Services
{
    public class PessoasServices
    {
        private string uri;

        public PessoasServices(string uri)
        {
            this.uri = uri;
        }

        public async Task<List<Pessoa>> Todos()
        {
            List<Pessoa> lista = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var data = await client.GetAsync(uri);
                    if (data.IsSuccessStatusCode)
                    {
                        var json = await data.Content.ReadAsStringAsync();
                        lista = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                    }
                    return lista;
                }
            }
            catch
            {
                throw new WebException("Erro ao consultar serviço");
            }
        }

        public async Task<Pessoa> Consultar(long id)
        {
            using (var client = new HttpClient())
            {
                var data = await client.GetAsync(uri + "/" + id.ToString());
                if (data.IsSuccessStatusCode)
                {
                    var json = await data.Content.ReadAsStringAsync();
                    Pessoa objeto = JsonConvert.DeserializeObject<Pessoa>(json);
                    return objeto;
                }
            }
            return default(Pessoa);
        }
    }
}
