using Microsoft.AspNetCore.Mvc;
using SimpleExchangeService.Messages.Requests;
using SimpleExchangeService.Messages.Response;

namespace SimpleExchangeService.Controllers
{
    public class ExchangeServiceController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<ExchangeReponse>> Post(ExchangeRequest request)
        {
            return Ok();
        }
    }
}
