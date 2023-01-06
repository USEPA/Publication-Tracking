
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PublicationTracking.Pages;

public class PublicationModel : PageModel
{

    public void OnGet(string documentId)
    {
        ViewData["PublicationId"] = documentId;
    }
}