using InvoiceSystem.Core.ViewModels;

namespace InvoiceSystem.Core.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<CompanyVM> AddCompanyInfoAsync(CompanyVM model);

        public Task<CompanyBranchVM> AddCompanyBranchAsync(CompanyBranchVM model);
    }
}
