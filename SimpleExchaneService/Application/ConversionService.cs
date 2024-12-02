using Newtonsoft.Json;
using SimpleExchangeService.Application.Interface;
using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;
using System.Reflection;

namespace SimpleExchangeService.Application
{
    /// <summary>
    /// Conversion service which will be called from API layer.
    /// </summary>
    public class ConversionService : IConversionService
    {
        private readonly HttpClient _httpClient;

        public ConversionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Conversion method which does the external api call and convert the amount to output currently
        /// </summary>
        /// <param name="message">type of ExchangeRequest which as necessary information for currency value conversion</param>
        /// <returns></returns>
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

        /// <summary>
        /// private method to find the string format property value from an object
        /// </summary>
        /// <param name="rates"> rates object</param>
        /// <param name="outputCurrency"> currency in string</param>
        /// <returns>return decimal value of outputCurrency</returns>
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
