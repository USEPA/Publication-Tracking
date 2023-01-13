using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PublicationTracking.Pages;

public class DatabaseModel : PageModel
{
    private readonly ILogger<DatabaseModel> _logger;
    private Data.PublicationContext _context;

    public List<Data.Publication> _publicationList { get; set; }

    public DatabaseModel(ILogger<DatabaseModel> logger, Data.PublicationContext context)
    {
        _logger = logger;
        _context = context;
        _publicationList = new List<Data.Publication>();
    }

    public void OnGet()
    {
        var _lastDate = DateTime.Now;
        var list = GetPublicationsFromDate(_lastDate);
        Console.WriteLine(list.Count());
        _publicationList = list;

    }

    private List<Data.Publication> GetPublicationsFromDate(DateTime lastDate)
    {
        var nextPage = _context.Publications
            .OrderByDescending(p => p.DateEntered)
            //.Where(p => p.DateEntered <= lastDate)
            //.Take(25)
            .Include(p => p.AlphaDescriptor)
            .Include(p => p.ResponsibleCode)
            .ToList();
        return nextPage;
    }
}