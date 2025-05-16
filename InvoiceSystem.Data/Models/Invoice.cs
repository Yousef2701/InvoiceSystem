namespace InvoiceSystem.Data.Models
{
    public class Invoice
    {
        [Key, MinLength(8), MaxLength(8), DisplayName("رقم الفاتورة"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNo { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required, ForeignKey("Company"), StringLength(15), DisplayName("الرقم الضريبي للشركة")]
        public string CompanyVatNo { get; set; }

        [Required, MinLength(7), MaxLength(10), DisplayName("رقم التليفون العميل")]
        public string CustomerPhone { get; set; }

        [Required, DisplayName("نسبة الضريبة")]
        public double TaxPercent { get; set; }

        [Required, DisplayName("نسبة الخصم")]
        public double DiscountPercent { get; set; }

        [Required, DisplayName("اجمالي الفاتورة قبل الضريبة")]
        public double TotalInvoicePriceBeforeTax { get; set; }

        [Required, DisplayName("اجمالي الفاتورة بعد الضريبة")]
        public double TotalInvoicePriceAfterTax { get; set; }

        [Required, DisplayName("طريقة الدفع")]
        public string PaymentWay { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
