using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;

namespace SimpleExchangeService.Application.Interface
{
    public interface IConversionService
    {
        Task<ExchangeResponse> Convert(ExchangeRequest message);
    }
}
