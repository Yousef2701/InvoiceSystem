using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace InvoiceSystem.Core.ViewModels
{
    public class InvoiceVM
    {
        //[Required, MinLength(8), MaxLength(8), DisplayName("رقم الفاتورة")]
        //public int InvoiceNo { get; set; }

        [Required, StringLength(15), DisplayName("الرقم الضريبي للشركة")]
        public string CompanyVatNo { get; set; }

        [Required, MinLength(7), MaxLength(10), DisplayName("رقم التليفون العميل")]
        public string CustomerPhone { get; set; }

        [Required, DisplayName("نسبة الضريبة")]
        public double TaxPercent { get; set; } 

        [Required, DisplayName("نسبة الخصم")]
        public double DiscountPercent { get; set; } 

        [Required, DisplayName("طريقة الدفع")]
        public string PaymentWay { get; set; }
    }
}
