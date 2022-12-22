using Microsoft.EntityFrameworkCore;

namespace PublicationTracking.Data;

public class PublicationContext : DbContext
{
    // These are the actual publications stored in the database.
    public DbSet<Publication> Publications { get; set; }
    public DbSet<AlphaDescriptor> AlphaDescriptors { get; set; }
    public DbSet<ResponsibleCode> ResponsibleCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=EPA_PubNumbers;User Id=sa;Password=++password1++;");
    }
}