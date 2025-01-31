namespace SalesDatePrediction.Domain.Models
{
    public class CustomerEntity
    {
        public string ContactName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedDate { get; set; }
    }
}
