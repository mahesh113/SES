using SimpleExchangeService.Application.Interface;
using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;

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

            return new ExchangeResponse
            {
                Amount = message.Amount,
                InputCurrency = message.InputCurrency,
                OutputCurrency = message.OutputCurrency,
                Value = 2.2m
            };
        }
    }
}
