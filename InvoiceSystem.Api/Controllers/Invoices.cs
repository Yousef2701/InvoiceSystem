namespace InvoiceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoices : ControllerBase
    {

        #region Dependancey injuction

        private readonly IInvoiceRepository _invoiceRepository;

        public Invoices(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        #endregion


        #region Insert New Invoice

        [HttpPost("InsertNewInvoice")]
        public async Task<IActionResult> InsertNewInvoice([FromBody]InvoiceVM model)
        {
            if(model != null)
            {
                return Ok(await _invoiceRepository.InsertNewInvoice(model));
            }
            return BadRequest("Model is Empty!!!");
        }

        #endregion

        #region Add Product To Invoice

        [HttpPost("AddProductsToInvoice")]
        public async Task<IActionResult> AddProductsToInvoice([FromBody] InvoiceProductVM model)
        {
            if(model != null)
            {
                return Ok(await _invoiceRepository.AddProductsToInvoice(model));
            }
            return BadRequest("Model is Empty!!!");
        }

        #endregion

        #region Remove Product From Invoice

        [HttpDelete("RemoveProductFromInvoice")]
        public async Task<IActionResult> RemoveProductFromInvoice(RemoveProductVM model)
        {
            if(model != null)
            {
                return Ok(await _invoiceRepository.RemoveProductFromInvoice(model));
            }
            return BadRequest("Model is Empty!!!");
        }

        #endregion

    }
}
