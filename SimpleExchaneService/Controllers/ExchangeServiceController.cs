using Microsoft.AspNetCore.Mvc;
using SimpleExchangeService.Application.Interface;
using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;

namespace SimpleExchangeService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExchangeServiceController : Controller
    {
        private readonly IConversionService _conversionService;
        public ExchangeServiceController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public async Task<ActionResult<ExchangeResponse>> Post(ExchangeRequest request)
        {
            var response = await _conversionService.Convert(request);
            return Ok(response);
        }
    }
}
