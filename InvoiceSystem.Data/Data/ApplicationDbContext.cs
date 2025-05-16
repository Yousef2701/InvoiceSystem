namespace InvoiceSystem.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CompanyBranch>()
            .HasKey(b => new { b.CompanyVatNo, b.City });

            builder.Entity<Customer>()
            .HasKey(b => new { b.CompanyVatNo, b.Phone });

            builder.Entity<InvoiceProduct>()
            .HasKey(b => new { b.InvoiceNo, b.ProductName });
        }

        public DbSet<Company> Company { get; set; }

        public DbSet<CompanyBranch> CompanyBranch { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet <InvoiceProduct> InvoiceProduct { get; set; }
    }
}
