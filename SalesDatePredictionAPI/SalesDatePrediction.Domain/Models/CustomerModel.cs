namespace SalesDatePrediction.Domain.Models
{
    public class CustomerModel
    {
        public int custid { get; set; }
        public string ContactName { get; set; }
        public string LastOrderDate { get; set; }
        public string NextPredictedDate { get; set; }
    }
}
