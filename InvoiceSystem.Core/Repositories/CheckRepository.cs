namespace InvoiceSystem.Core.Repositories
{
    public class CheckRepository : ICheckRepository
    {

        #region Dependancey injuction

        private readonly ApplicationDbContext _context;

        public CheckRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion


        #region Check Customer Async

        public async Task<bool> CheckCustomerAsync(string phone)
        {
            if(phone != null)
            {
                var customer = _context.Customer.Where(m => m.Phone == phone).FirstOrDefault();
                if (customer != null)
                    return true;
            }
            return false;
        }

        #endregion

        #region Check Company Async

        public async Task<bool> CheckCompanyAsync(string vatNo)
        {
            if (vatNo != null)
            {
                var company = _context.Company.Find(vatNo);
                if (company != null)
                    return true;
            }
            return false;
        }

        #endregion

        #region Check Invoice Async

        public async Task<bool> CheckInvoiceAsync(int No)
        {
            if(No != null)
            {
                var invoice = _context.Invoice.Where(m => m.InvoiceNo == No).FirstOrDefault();
                if (invoice != null)
                    return true;
            }
            return false;
        }

        #endregion

        #region Check Invoice Product Async

        public async Task<bool> CheckInvoiceProductAsync(int invoiceNo, string product)
        {
            if(invoiceNo != null &&  product != null)
            {
                if(await CheckInvoiceAsync(invoiceNo))
                {
                    var check = _context.InvoiceProduct.Where(m => m.InvoiceNo == invoiceNo && m.ProductName == product).FirstOrDefault();
                    if (check != null) return true;
                }
            }
            return false;
        }

        #endregion

        #region Check Company LogIn Async

        public async Task<bool> CheckCompanyLogInAsync(CompanyLogInVM model)
        {
            if(model != null)
            {
                if(await CheckCompanyAsync(model.VatNo))
                {
                    var company = _context.Company.Find(model.VatNo);
                    if(company.Password == model.Password)
                        return true;
                }
            }
            return false;
        }

        #endregion

    }
}
