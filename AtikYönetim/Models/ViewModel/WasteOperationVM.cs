namespace AtikYonetim.Models.ViewModel
{
    public class WasteOperationVM
    {
        public int ID { get; set; }
        public string Month { get; set; }
        public string Store { get; set; }
        public string WasteType { get; set; }
        public string WasteSort { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string ReceivingCompany { get; set; }
        public DateTime WasteDate { get; set; }
        public string? Content { get; set; }
    }
}
