public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=InvoiceSystem-DB;Trusted_Connection=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}