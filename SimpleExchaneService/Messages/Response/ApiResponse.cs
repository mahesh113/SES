namespace SimpleExchangeService.Messages.Response
{
    public class ApiResponse
    {
        public string Result { get; set; }
        public string Provider { get; set; }
        public Rates Rates { get; set; }
    }
    public class Rates
    {
        public string AUD { get; set; }
        public string USD { get; set; }
        public string ARS { get; set; }
        public string CAD { get; set; }
        public string CHF { get; set; }
        public string CLP { get; set; }
        public string EUR { get; set; }
        public string GBP { get; set; }
    }
}
