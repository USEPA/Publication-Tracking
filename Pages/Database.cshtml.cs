using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PublicationTracking.Pages;

public class DatabaseModel : PageModel
{
    private readonly ILogger<DatabaseModel> _logger;

    public DatabaseModel(ILogger<DatabaseModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}