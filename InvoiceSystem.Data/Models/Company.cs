namespace InvoiceSystem.Data.Models
{
    public class Company
    {
        [Key, StringLength(15), DisplayName("الرقم الضريبي")]
        public string VatNo { get; set; }

        [Required, StringLength(10), DisplayName("رقم السجل التجارى")]
        public string CR { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("اسم الشركة")]
        public string NameInArabic { get; set; }

        [Required, MinLength(2), MaxLength(65), DisplayName("Company Name")]
        public string NameInEnglish { get; set; }

        [Required, MinLength(15), MaxLength(24), DisplayName("رقم الحساب البنكي للشركة")]
        public string AccountNo { get; set; }

        [Required, MinLength(8), MaxLength(16), DisplayName("كلمة المرور")]
        public string Password { get; set; }

        [AllowNull]
        public string? LogoUrl { get; set; } = null;

        public virtual ICollection<CompanyBranch> CompanyBranches { get; } = new List<CompanyBranch>();
    }
}
