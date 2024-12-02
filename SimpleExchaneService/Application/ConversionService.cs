using SimpleExchangeService.Application.Interface;
using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;

namespace SimpleExchangeService.Application
{
    public class ConversionService : IConversionService
    {
        public Task<ExchangeResponse> Convert(ExchangeRequest message)
        {
            return Task.FromResult(new ExchangeResponse
            {
                Amount = message.Amount,
                InputCurrency = message.InputCurrency,
                OutputCurrency = message.OutputCurrency,
                Value = 2.2m
            });
        }
    }
}
