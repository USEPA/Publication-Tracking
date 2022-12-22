
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PublicationTracking.Pages;

public class DetailsModel : PageModel
{
    public void OnGet(string documentId)
    {
        ViewData["PublicationId"] = documentId;
    }
}