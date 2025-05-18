namespace InvoiceSystem.Core.ViewModels
{
    public class RemoveProductVM
    {
        [Required, DisplayName("رقم الفاتورة")]
        public int InvoiceNo { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("اسم الشركة")]
        public string ProductName { get; set; }
    }
}
