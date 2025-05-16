namespace InvoiceSystem.Core.ViewModels
{
    public class CompanyLogInVM
    {
        [Required, StringLength(15), DisplayName("الرقم الضريبي")]
        public string VatNo { get; set; }

        [Required, DataType(DataType.Password), MinLength(8), MaxLength(16), DisplayName("كلمة المرور")]
        public string Password { get; set; }
    }
}
