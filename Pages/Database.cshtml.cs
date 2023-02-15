using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PublicationTracking.Pages;

public class DatabaseModel : PageModel
{
    private readonly ILogger<DatabaseModel> _logger;
    private Data.PublicationContext _context;
    public IQueryable<Data.Publication> _publicationListQ { get; set; }
    public int _page { get; set; }
    
    [BindProperty]
    public string SearchId { get; set; }
    public static int totalPublications;

    public DatabaseModel(ILogger<DatabaseModel> logger, Data.PublicationContext context)
    {
        _logger = logger;
        _context = context;
        totalPublications = _context.Publications.Count();
    }

    public void OnGet(string? pageNumber)
    {
        _page = int.Parse(pageNumber ?? "1");

        var list = _context.Publications
            .OrderByDescending(p => p.DateEntered)
            .Include(p => p.AlphaDescriptor)
            .Include(p => p.ResponsibleCode);
        _publicationListQ = list;

    }
}