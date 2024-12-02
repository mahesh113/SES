namespace SimpleExchangeService.Messages.Requests
{
    public class ExchangeRequest
    {
        public decimal Amount { get; set; }
        public string InputCurrency { get; set; }
        public string OutputCurrency { get; set; }
    }
}
