using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCep
{
    public class CEP
    {
        public class CEPData
        {
            public string Cep { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string UF { get; set; }
            public string IBGE { get; set; }
            public string GIA { get; set; }
            public string Ddd { get; set; }
            public string Siafi { get; set;}
        }

        private const string ViaCEPBaseUrl = "https://viacep.com.br/ws/";

        public async Task<CEPData> ConsultarCEP(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{ViaCEPBaseUrl}{cep}/json/";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    CEPData cepData = JsonConvert.DeserializeObject<CEPData>(content);
                    return cepData;
                }

                // Se a solicitação não for bem-sucedida, você pode tratar isso conforme necessário
                return null;
            }
        }
    }
}
