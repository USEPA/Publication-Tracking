using System.Collections.Generic;
using System.Dynamic;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PublicationTracking.Data;

namespace PublicationTracking.Pages;

public class ImportModel : PageModel
{

    private readonly ILogger<ImportModel> _logger;
    private Data.PublicationContext _context;

    public List<Data.Publication> publications;
    public List<Data.ImportResults> importResults;

    public ImportModel(ILogger<ImportModel> logger, Data.PublicationContext context)
    {
        _logger = logger;
        _context = context;
        publications = new();
        importResults = new();
    }

    public async Task<IActionResult> OnPost()
    {
        var form = Request.Form;

        if(form.Files.Count > 0)
        {
            var importFile = form.Files[0];
            var extension = Path.GetExtension(importFile.FileName);
            if(extension == ".xlsx")
            {                
                // From here we read the excel file, and use that to create the publications.
                using (var stream = importFile.OpenReadStream())
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        // So we iterate though the rows.
                        foreach(System.Data.DataRow row in result.Tables[0].Rows)
                        {
                            if(row.ItemArray[0].ToString() == "Document Id")
                            {
                                continue;
                            }
                            // Then we go though each column and use it.
                            // Note, right now, we are only using DocumentId, ResponsibleCode, AlphaDescriptor, and Title.
                            // If we want to include new columns, just need to make sure they are in the excel file, and then uncomment the code below.
                            var p = new Data.Publication();
                            p.DocumentId = row.ItemArray[0].ToString();

                            // Need to make sure that the Responsible Code is valid.
                            p.ResponsibleCode = _context.ResponsibleCodes.Where(r => r.Code == row.ItemArray[1].ToString()).FirstOrDefault();
                            p.AlphaDescriptor = _context.AlphaDescriptors.Where(a => a.Code == row.ItemArray[2].ToString()).FirstOrDefault();
                            //p.Year = int.Parse(row.ItemArray[3].ToString());
                            //p.SequenceNumber = int.Parse(row.ItemArray[4].ToString());
                            //p.Volume = row.ItemArray[5]?.ToString();
                            p.Title = row.ItemArray[3].ToString();
                            //p.Comment = row.ItemArray[7]?.ToString();
                            //p.Url = row.ItemArray[8]?.ToString();
                            //p.Language = Enum.TryParse(row.ItemArray[9].ToString(), out Data.Language language) ? language : Data.Language.English;
                            //p.DateRequested = DateTime.Parse(row.ItemArray[10].ToString());
                            //p.PointOfContactName = row.ItemArray[11].ToString();
                            //p.PointOfContactOrganization = row.ItemArray[12]?.ToString();
                            //p.PointOfContactPhoneNumber = row.ItemArray[13]?.ToString();
                            //p.PointOfContactEmail = row.ItemArray[14]?.ToString();
                            //p.PointOfContactMailCode = row.ItemArray[15]?.ToString();
                            //p.IsOriginal = (bool?)row.ItemArray[16];
                            //p.IsDigital = (bool?)row.ItemArray[17];
                            //p.IsPrinted = (bool?)row.ItemArray[18];
                            //p.IsInternalOnly = (bool?)row.ItemArray[19];
                            //p.OriginalId = row.ItemArray[20]?.ToString();
                            //p.Revision = row.ItemArray[21]?.ToString();
                            //p.ExpectedPublicationDate = DateTime.Parse(row.ItemArray[22].ToString());
                            //p.DateEntered = DateTime.Parse(row.ItemArray[22].ToString());
                            //p.EnteredBy = row.ItemArray[24].ToString();

                            publications.Add(p);
                            importResults.Add(new Data.ImportResults { DocumentId = p.DocumentId, IsSuccess = true });

                            Console.WriteLine(p.DocumentId);
                        }
                    }
                    
                }   
            }
        

        }

        //return RedirectToPage("/ImportResults", new { iResults = importResults });
        return CreateResult(importResults);
    }

    public ActionResult CreateResult([FromBody] List<Data.ImportResults> importResults)
    {
        return Page();
    }

    public ActionResult DownloadFile()
    {
        Console.WriteLine("DownloadFile");
        return File("/files/TestFile34.csv", "application/octet-stream", "Template.xlsx");
    }
}