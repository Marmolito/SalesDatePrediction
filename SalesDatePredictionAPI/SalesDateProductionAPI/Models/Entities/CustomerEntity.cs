namespace SalesDateProductionAPI.Models.Entities
{
    public class CustomerEntity
    {
        public int custid { get; set; }
        public string ContactName { get; set; }
        public string LastOrderDate { get; set; }
        public string NextPredictedDate { get; set; }
    }
}
