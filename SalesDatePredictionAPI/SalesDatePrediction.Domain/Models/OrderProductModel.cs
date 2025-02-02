namespace SalesDatePrediction.Domain.Models
{
    public class OrderProductModel
    {
        public int custID { get; set; }
        public int EmpID { get; set; }
        public int ShipperID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipCountry { get; set; }


        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }
}
