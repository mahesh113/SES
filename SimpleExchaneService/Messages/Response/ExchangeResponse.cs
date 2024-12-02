namespace SimpleExchangeService.Messages.Response
{
    public class ExchangeResponse
    {
        public decimal Amount { get; set; }
        public decimal Value { get; set; }
        public string InputCurrency { get; set; }
        public string OutputCurrency { get; set; }
    }
}
