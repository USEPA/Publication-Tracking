using Microsoft.EntityFrameworkCore;

namespace PublicationTracking.Data;

public class PublicationContext : DbContext
{
    //private IConfiguration _configuration;
    // These are the actual publications stored in the database.
    public DbSet<Publication> Publications { get; set; }
    public DbSet<AlphaDescriptor> AlphaDescriptors { get; set; }
    public DbSet<ResponsibleCode> ResponsibleCodes { get; set; }
    private string _connectionString { get; set; }

    public PublicationContext(DbContextOptions<PublicationContext> options): base(options)
    {

    }

}