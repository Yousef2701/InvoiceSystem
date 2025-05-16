namespace InvoiceSystem.Core.Interfaces
{
    public interface ICheckRepository
    {
        public Task<bool> CheckCustomerAsync(string phone);

        public Task<bool> CheckCompanyAsync(string vatNo);

        public Task<bool> CheckInvoiceAsync(int No);

        public Task<bool> CheckCompanyLogInAsync(CompanyLogInVM model);
    }
}
