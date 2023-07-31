namespace AtikYonetim.Core.Entities
{
    public class WasteOperation
    {
        public int ID { get; set; }
        public int MonthId { get; set; }
        public int StoreId { get; set; }
        public int WasteTypeId { get; set; }
        public int WasteSortId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public int ReceivingCompanyId { get; set; }
        public DateTime WasteDate { get; set; }
        public string? Content { get; set; }
    }
}