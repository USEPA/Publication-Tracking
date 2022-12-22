using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PublicationTracking.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private Data.PublicationContext _context;
    private Services.PublicationServices _publicationService;

    public List<SelectListItem> Languages { get; set; }
    public List<SelectListItem> ResponsibleCodes { get; set; }
    public List<SelectListItem> AlphaDescriptors { get; set; }
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
        Languages = BuildLanguages();
        Publication.ExpectedPublicationDate = DateTime.Now;

        AlphaDescriptors = _context.AlphaDescriptors.Select(a => new SelectListItem { Value = a.Code, Text = $"{a.Code} - {a.Description}" }).ToList();
        ResponsibleCodes = _context.ResponsibleCodes.Select(r => new SelectListItem { Value = r.Code, Text = $"{r.Code} - {r.Organization}" }).ToList();
    }

    public void OnPost()
    {
        _logger.LogInformation("Adding a new publication!");
        var form = Request.Form;

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

        // With this in hand, we can now create a Publication
        Publication.DocumentId = publicationId;
        Publication.AlphaDescriptor = _context.AlphaDescriptors.Where(a => a.Code == Request.Form["Publication.AlphaDescriptor"].ToString()).FirstOrDefault();
        Publication.ResponsibleCode = _context.ResponsibleCodes.Where(r => r.Code == Request.Form["Publication.ResponsibleCode"].ToString()).FirstOrDefault();
        Publication.Comment = Request.Form["Publication.Comment"];
        Publication.DateEntered = DateTime.Now;
        Publication.Year = int.Parse(expectedPubDate.ToString("yy"));
        //Publication.DateRequested = null;
        Publication.DateLastModified = DateTime.Now;
        //Publication.EnteredBy = null;
        Publication.ExpectedPublicationDate = expectedPubDate;
        Publication.IsOriginal = bool.Parse(Request.Form["Publication.IsOriginal"]);
        Publication.Language = Request.Form["Publication.Language"];
        Publication.PointOfContactEmail = Request.Form["Publication.PointOfContactEmail"];
        //Publication.PointOfContactMailCode = null;
        Publication.PointOfContactName = Request.Form["Publication.PointOfContactName"];
        //Publication.PointOfContactOrganization = null;
        Publication.PointOfContactPhoneNumber = Request.Form["Publication.PointOfContactPhoneNumber"];
        //Publication.SequenceNumber = null;
        Publication.Title = Request.Form["Publication.Title"];
        Publication.Url = Request.Form["Publication.Url"];
        Publication.IsDigital = bool.Parse(Request.Form["Publication.IsDigital"]);
        Publication.IsPrinted = bool.Parse(Request.Form["Publication.IsPrinted"]);
        Publication.IsInternalOnly = bool.Parse(Request.Form["Publication.IsInternalOnly"]);
        //Publication.Revision = null;
        //Publication.Volume = null;

        // At this point, we should be ready to add the item to the database!
        _context.Publications.Add(Publication);
        _context.SaveChanges();

        RedirectToPage("details", Publication.DocumentId);
    }

    private List<SelectListItem> BuildLanguages()
    {
        // Yeah, the languages here are hard-coded. We can connect this to a database in the future if we'd like.
        var l = new List<SelectListItem>();
        l.Add(new SelectListItem { Text = "English", Value = "1" });
        l.Add(new SelectListItem { Text = "Arabic", Value = "2" });
        l.Add(new SelectListItem { Text = "Armenian", Value = "3" });
        l.Add(new SelectListItem { Text = "Cambodian", Value = "4" });
        l.Add(new SelectListItem { Text = "Chinese", Value = "5" });
        l.Add(new SelectListItem { Text = "French", Value = "6" });
        l.Add(new SelectListItem { Text = "German", Value = "7" });
        l.Add(new SelectListItem { Text = "Hatian Creole", Value = "8" });
        l.Add(new SelectListItem { Text = "Hindi", Value = "9" });
        l.Add(new SelectListItem { Text = "Hmong", Value = "10" });
        l.Add(new SelectListItem { Text = "Italian", Value = "11" });
        l.Add(new SelectListItem { Text = "Japanese", Value = "12" });
        l.Add(new SelectListItem { Text = "Korean", Value = "13" });
        l.Add(new SelectListItem { Text = "Laotian", Value = "14" });
        l.Add(new SelectListItem { Text = "Polish", Value = "15" });
        l.Add(new SelectListItem { Text = "Portuguese", Value = "16" });
        l.Add(new SelectListItem { Text = "Russian", Value = "17" });
        l.Add(new SelectListItem { Text = "Spanish", Value = "18" });
        l.Add(new SelectListItem { Text = "Tagalog", Value = "19" });
        l.Add(new SelectListItem { Text = "Thai", Value = "20" });
        l.Add(new SelectListItem { Text = "Traditional Chinese", Value = "21" });
        l.Add(new SelectListItem { Text = "Vietnamese", Value = "22" });

        return l;
    }
}
