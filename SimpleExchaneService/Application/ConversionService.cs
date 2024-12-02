using SimpleExchangeService.Application.Interface;

namespace SimpleExchangeService.Application
{
    public class ConversionService : IConversionService
    {
        public decimal Convert(decimal value) => 3.3m;
    }
}
