namespace InvoiceSystem.Data.Models
{
    public class InvoiceProduct
    {
        [ForeignKey("Invoice"), MinLength(8), MaxLength(8), DisplayName("رقم الفاتورة"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNo { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("اسم الشركة")]
        public string ProductName { get; set; }

        [Required, DisplayName("سعر القطعة")]
        public double PiecePrice { get; set; }

        [Required, DisplayName("عدد القطع")]
        public int count { get; set; }

        [Required, DisplayName("السعر الاجمالى")]
        public double TotalPrice { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
    }
}
