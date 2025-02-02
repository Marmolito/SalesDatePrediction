namespace SalesDateProductionAPI.Models.Entities
{
    public class OrderEntity
    {
        public int orderid { get; set; }
        public string requireddate { get; set; }
        public string shippeddate { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
    }
}
