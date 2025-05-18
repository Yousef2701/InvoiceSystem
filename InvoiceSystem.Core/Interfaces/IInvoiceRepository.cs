namespace InvoiceSystem.Core.Interfaces
{
    public interface IInvoiceRepository
    {

        public Task<InvoiceVM> InsertNewInvoice(InvoiceVM model);

        public Task<InvoiceProductVM> AddProductsToInvoice(InvoiceProductVM model);

        public Task<RemoveProductVM> RemoveProductFromInvoice(RemoveProductVM model);

    }
}
