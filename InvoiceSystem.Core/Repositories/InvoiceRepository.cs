namespace InvoiceSystem.Core.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {

        #region Dependancey injuction

        private readonly ApplicationDbContext _context;
        private readonly ICheckRepository _checkRepository;

        public InvoiceRepository(ApplicationDbContext context,
                                 ICheckRepository checkRepository)
        {
            _context = context;
            _checkRepository = checkRepository;
        }

        #endregion


        #region Insert New Invoice

        public async Task<InvoiceVM> InsertNewInvoice(InvoiceVM model)
        {
            if(model != null)
            {
                if(await _checkRepository.CheckCompanyAsync(model.CompanyVatNo))
                {
                    if(await _checkRepository.CheckCustomerAsync(model.CustomerPhone))
                    {
                        var invoice = new Invoice
                        {
                            Date = DateTime.Now.ToString("D"),
                            Time = DateTime.Now.ToString("t"),
                            CompanyVatNo = model.CompanyVatNo,
                            CustomerPhone = model.CustomerPhone,
                            TaxPercent = model.TaxPercent,
                            DiscountPercent = model.DiscountPercent,
                            TotalInvoicePriceAfterTax = 0,
                            TotalInvoicePriceBeforeTax = 0,
                            PaymentWay = model.PaymentWay
                        };

                        _context.Invoice.Add(invoice);
                        _context.SaveChanges();

                        return model;
                    }
                }
            }
            return null;
        }

        #endregion

        #region Add Products To Invoice

        public async Task<InvoiceProductVM> AddProductsToInvoice(InvoiceProductVM model)
        {
            if(model != null)
            {
                if(await _checkRepository.CheckInvoiceAsync(model.InvoiceNo))
                {
                    var product = new InvoiceProduct
                    {
                        InvoiceNo = model.InvoiceNo,
                        ProductName = model.ProductName,
                        PiecePrice = model.PiecePrice,
                        count = model.count,
                        TotalPrice = model.PiecePrice * model.count
                    };
                    _context.InvoiceProduct.Add(product);

                    var invoice = _context.Invoice.Find(model.InvoiceNo);
                    invoice.TotalInvoicePriceBeforeTax += product.TotalPrice;
                    invoice.TotalInvoicePriceAfterTax = invoice.TotalInvoicePriceBeforeTax +
                                                        (invoice.TotalInvoicePriceBeforeTax * invoice.TaxPercent / 100);
                    _context.Invoice.Update(invoice);

                    _context.SaveChanges();

                    return model;
                }
            }
            return null;
        }

        #endregion

        #region Remove Product From Invoice

        public async Task<RemoveProductVM> RemoveProductFromInvoice(RemoveProductVM model)
        {
            if(model != null)
            {
                if(await _checkRepository.CheckInvoiceProductAsync(model.InvoiceNo, model.ProductName))
                {
                    var product = _context.InvoiceProduct.Where(m => m.InvoiceNo == model.InvoiceNo && m.ProductName == model.ProductName).FirstOrDefault();
                    _context.InvoiceProduct.Remove(product);

                    var invoice = _context.Invoice.Find(model.InvoiceNo);
                    invoice.TotalInvoicePriceBeforeTax -= product.TotalPrice;
                    invoice.TotalInvoicePriceAfterTax = invoice.TotalInvoicePriceBeforeTax +
                                                        (invoice.TotalInvoicePriceBeforeTax * invoice.TaxPercent / 100);
                    _context.Invoice.Update(invoice);

                    _context.SaveChanges();

                    return model;
                }
            }
            return null;
        }

        #endregion

    }
}
