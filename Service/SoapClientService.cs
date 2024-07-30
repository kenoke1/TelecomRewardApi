
using System.Text;

namespace TelecomRewardsApi.Service
{
    public class SoapClientService : ISoapClientService
    {
        private readonly HttpClient _httpClient;

        public SoapClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> FindPersonAsync(string id)
        {
            var soapRequest = $@"
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org"">
                <soapenv:Header/>
                <soapenv:Body>
                    <tem:FindPerson>
                        <tem:id>{id}</tem:id>
                    </tem:FindPerson>
                </soapenv:Body>
            </soapenv:Envelope>";

            var content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");
            var response = await _httpClient.PostAsync("https://www.crcind.com/csp/samples/SOAP.Demo.cls", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
