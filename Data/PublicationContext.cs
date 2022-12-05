using Microsoft.EntityFrameworkCore;

namespace PublicationTracking.Data;

public class PublicationContext : DbContext
{
    public DbSet<Publication> Publications { get; set; }
}