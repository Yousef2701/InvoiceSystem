using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystem.Core.ViewModels
{
    public class CompanyBranchVM
    {
        [Required, StringLength(15), DisplayName("الرقم الضريبي للشركة")]
        public string CompanyVatNo { get; set; }

        [Required, MinLength(3), MaxLength(45), DisplayName("المدينة")]
        public string City { get; set; }

        [Required, MinLength(7), MaxLength(10), DisplayName("رقم التليفون")]
        public string Phone { get; set; }
    }
}
