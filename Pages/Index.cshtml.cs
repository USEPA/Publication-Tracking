using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PublicationTracking.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private Data.PublicationContext _context;
    private Services.PublicationServices _publicationService;
    public List<SelectListItem> ResponsibleCodes { get; set; }
    public List<SelectListItem> AlphaDescriptors { get; set; }

    [BindProperty]
    public Data.Publication Publication { get; set; }

    public IndexModel(ILogger<IndexModel> logger, Data.PublicationContext context, Services.PublicationServices publicationService)
    {
        _logger = logger;
        _context = context;
        _publicationService = publicationService;
        Publication = new();
    }

    public void OnGet()
    {
        Publication.ExpectedPublicationDate = DateTime.Now;

        AlphaDescriptors = _context.AlphaDescriptors.Select(a => new SelectListItem { Value = a.Code, Text = $"{a.Code} - {a.Description}" }).ToList();
        ResponsibleCodes = _context.ResponsibleCodes.Where(r => r.IsValid == true).Select(r => new SelectListItem { Value = r.Code, Text = $"{r.Code} - {r.Organization}" }).ToList();
    }

    public IActionResult OnPost()
    {
        _logger.LogInformation("Adding a new publication!");
        var form = Request.Form;

        // Quick note. If the publication is an original, we don't need the original id.
        if (Publication.IsOriginal == true)
        {
            Publication.OriginalId = null;
        }

        // Now that the form is filled out, we can generate a publication Id.
        // In order to generate a publication Id, we need to combine some of the fields.
        // Responsible Code + Alpha Descriptor + 2 Digit Year of Expected Publication Date + Count
        // So Lets generate the first part..
        var pubDate = Request.Form["Publication.ExpectedPublicationDate"].ToString();
        var expectedPubDate = DateTime.Parse(pubDate);
        var pubId = String.Format($"{Request.Form["Publication.ResponsibleCode"]}{Request.Form["Publication.AlphaDescriptor"]}{expectedPubDate.ToString("yy")}");

        // Now, lets go to the database, and see how many of these already exist.
        var pubCount = _publicationService.GetPublicationCount(pubId) + 1;

        // So, lets make that into a number we can add to the end.
        string pubIdCount = $"{pubCount:000}";

        // Here is the final pub number!
        var publicationId = $"{pubId}{pubIdCount}";

        // With this in hand, we can now update the publication.
        Publication.DocumentId = publicationId;
        Publication.AlphaDescriptor = _context.AlphaDescriptors.Where(a => a.Code == Request.Form["Publication.AlphaDescriptor"].ToString()).FirstOrDefault();
        Publication.ResponsibleCode = _context.ResponsibleCodes.Where(r => r.Code == Request.Form["Publication.ResponsibleCode"].ToString()).FirstOrDefault();
        Publication.DateEntered = DateTime.Now;
        Publication.Year = int.Parse(expectedPubDate.ToString("yy"));
        Publication.DateLastModified = DateTime.Now;

        // At this point, we should be ready to add the item to the database!
        _context.Publications.Add(Publication);
        _context.SaveChanges();

        return RedirectToPage("/Details", new { documentId = Publication.DocumentId });
    }
}
