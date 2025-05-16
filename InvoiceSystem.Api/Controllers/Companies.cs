namespace InvoiceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Companies : ControllerBase
    {

        #region Dependancey injuction

        private readonly ICompanyRepository _companyRepository;
        private readonly ICheckRepository _checkRepository;

        public Companies(ICompanyRepository companyRepository,
                         ICheckRepository checkRepository)
        {
            _companyRepository = companyRepository;
            _checkRepository = checkRepository;
        }

        #endregion


        #region Add New Company

        [HttpPost("AddNewCompany")]
        public async Task<IActionResult> AddNewCompany([FromForm]CompanyVM model)
        {
            if (model != null)
            {
                return Ok(await _companyRepository.AddCompanyInfoAsync(model));
            }
            return BadRequest("Model is Empty!!!");
        }

        #endregion

        #region Add New Company Branch

        [HttpPost("AddNewCompanyBranch")]
        public async Task<IActionResult> AddNewCompanyBranch([FromBody]CompanyBranchVM model)
        {
            if (model != null)
            {
                return Ok(await _companyRepository.AddCompanyBranchAsync(model));
            }
            return BadRequest("Model is Empty!!!");
        }

        #endregion

        #region Company LogIn

        [HttpPost("CompanyLogIn")]
        public async Task<IActionResult> CompanyLogIn([FromBody]CompanyLogInVM model)
        {
            if(model != null)
            {
                return Ok(await _checkRepository.CheckCompanyLogInAsync(model));
            }
            return BadRequest("Model is Empty!!!");
        }

        #endregion

    }
}
