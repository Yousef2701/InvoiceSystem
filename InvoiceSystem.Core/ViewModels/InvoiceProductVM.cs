using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystem.Core.ViewModels
{
    public class InvoiceProductVM
    {
        [Required, DisplayName("رقم الفاتورة")]
        public int InvoiceNo { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("اسم الشركة")]
        public string ProductName { get; set; }

        [Required, DisplayName("سعر القطعة")]
        public double PiecePrice { get; set; }

        [Required, DisplayName("عدد القطع")]
        public int count { get; set; }

    }
}
