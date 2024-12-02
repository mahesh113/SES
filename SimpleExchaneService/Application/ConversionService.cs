using Newtonsoft.Json;
using SimpleExchangeService.Application.Interface;
using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;
using System.Reflection;

namespace SimpleExchangeService.Application
{
    public class ConversionService : IConversionService
    {
        private readonly HttpClient _httpClient;

        public ConversionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeResponse> Convert(ExchangeRequest message)
        {
            var response = await _httpClient.GetAsync(message.InputCurrency);
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<ApiResponse>(respStr);

            var rateValue = GetRateValue(responseObj.Rates, message.OutputCurrency);

            return new ExchangeResponse
            {
                Amount = message.Amount,
                InputCurrency = message.InputCurrency,
                OutputCurrency = message.OutputCurrency,
                Value = System.Convert.ToDecimal(rateValue) * message.Amount
            };
        }

        private static object GetRateValue(Rates rates, string outputCurrency)
        {
            PropertyInfo[] propInfos = typeof(Rates).GetProperties();
            foreach (var x in propInfos )
            {
                if ( x.Name.ToUpper() == outputCurrency.ToUpper())
                {
                    return x.GetValue(rates);
                }
            }
            return 0;
        }
    }
}
