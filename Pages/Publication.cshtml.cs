
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PublicationTracking.Pages;

public class PublicationModel : PageModel
{
    private readonly ILogger<DatabaseModel> _logger;
    private Data.PublicationContext _context;
    public Data.Publication _publication;

    public PublicationModel(ILogger<DatabaseModel> logger, Data.PublicationContext context)
    {
        _logger = logger;
        _context = context;
        _publication = new();
    }

    public void OnGet(string id)
    {
        //_publication = _context.Publications.FirstOrDefault(p => p.DocumentId == id);
        _publication = _context.Publications
            .Include(p => p.AlphaDescriptor)
            .Include(p => p.ResponsibleCode)
            .FirstOrDefault(p => p.DocumentId == id);
    }
}