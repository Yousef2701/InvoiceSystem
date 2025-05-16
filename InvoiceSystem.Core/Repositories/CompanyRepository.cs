namespace InvoiceSystem.Core.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {

        #region Dependancey injuction

        private readonly ICheckRepository _checkRepository;
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ICheckRepository checkRepository,
                                 ApplicationDbContext context)
        {
            _checkRepository = checkRepository;
            _context = context;
        }

        #endregion


        #region Add Company Info Async

        public async Task<CompanyVM> AddCompanyInfoAsync(CompanyVM model)
        {
            if (model != null)
            {
                if(!await _checkRepository.CheckCompanyAsync(model.VatNo))
                {
                    if(model.ConfirmPassword == model.Password)
                    {
                        var company = new Company
                        {
                            VatNo = model.VatNo,
                            CR = model.CR,
                            NameInArabic = model.NameInArabic,
                            NameInEnglish = model.NameInEnglish,
                            AccountNo = model.AccountNo,
                            Password = model.Password,
                            LogoUrl = ""
                        };

                        _context.Company.Add(company);
                        _context.SaveChanges();

                        return model;
                    }
                }
            }
            return null;
        }

        #endregion

        #region AddCompanyBranchAsync

        public async Task<CompanyBranchVM> AddCompanyBranchAsync(CompanyBranchVM model)
        {
            if(model != null)
            {
                if(await _checkRepository.CheckCompanyAsync(model.CompanyVatNo))
                {
                    var branch = new CompanyBranch
                    {
                        CompanyVatNo = model.CompanyVatNo,
                        City = model.City,
                        Phone = model.Phone
                    };

                    _context.CompanyBranch.Add(branch);
                    _context.SaveChanges();

                    return model;
                }
            }
            return null;
        }

        #endregion

    }
}
