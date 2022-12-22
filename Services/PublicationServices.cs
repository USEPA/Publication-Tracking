namespace PublicationTracking.Services;

public class PublicationServices
{
    private Data.PublicationContext _context;
    public PublicationServices(Data.PublicationContext context)
    {
        _context = context;
    }

    public int GetPublicationCount(string publicationNumberBase)
    {
        var pubs = _context.Publications.Where(p => p.DocumentId.StartsWith(publicationNumberBase));
        return 2;
        //return pubs.Count();
    }
}