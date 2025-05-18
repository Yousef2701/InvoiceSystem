namespace InvoiceSystem.Data.Models
{
    public class Customer
    {
        [Required, ForeignKey("Company"), StringLength(15), DisplayName("الرقم الضريبي للشركة")]
        public string CompanyVatNo { get; set; }

        [Required, MinLength(7), MaxLength(10), DisplayName("رقم التليفون")]
        public string Phone { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("اسم العميل")]
        public string NameInArabic { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("Customer Name")]
        public string NameInEnglish { get; set; }

        [Required, MinLength(3), MaxLength(65), DisplayName("العنوان")]
        public string AddressInArabic { get; set; }

        [Required, MinLength(3), MaxLength(65), DisplayName("Address")]
        public string AddressInEnglish { get; set; }

        [Required, MinLength(5), MaxLength(15), DisplayName("الرقم الضريبي للعميل")]
        public int CustomerVatNo { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
