namespace PharmacySystem.DAL.Object
{
    public class ProductCharge
    {
        public string ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string UnitId { get; set; }

        public string UnitName { get; set; }

        public int Quantity { get; set; }

        public int ExportPrice { get; set; }

        public int AmountTotal { get; set; }
    }
}
