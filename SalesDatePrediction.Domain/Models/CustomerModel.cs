namespace SalesDatePrediction.Domain.Models
{
    public class CustomerModel
    {
        public string ContactName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedDate { get; set; }
    }
}
