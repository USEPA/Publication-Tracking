using System.ComponentModel.DataAnnotations;
namespace PublicationTracking.Data;

public class Publication
{
    public int Id { get; set; }
    public string DocumentId { get; set; }
    public ResponsibleCode ResponsibleCode { get; set; }
    public AlphaDescriptor AlphaDescriptor { get; set; }
    public int? Year { get; set; }
    public int? SequenceNumber { get; set; }
    public string? Volume { get; set; }

    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Display(Name = "Additional Comments")]
    public string Comment { get; set; }

    [Display(Name = "Publication URL")]
    public string? Url { get; set; }
    public Data.Language? Language { get; set; }
    public DateTime? DateRequested { get; set; }

    [Required]
    [Display(Name = "Requestor Name", Prompt = "Dugnutt, Bobson")]
    public string? PointOfContactName { get; set; }
    public string? PointOfContactOrganization { get; set; }

    [Phone]
    [Display(Name = "Requestor Phone Number")]
    public string PointOfContactPhoneNumber { get; set; }

    [EmailAddress]
    [Display(Name = "Email Address", Prompt = "Bobson.Dugnutt@example.com")]
    public string? PointOfContactEmail { get; set; }
    public string? PointOfContactMailCode { get; set; }
    public bool? IsOriginal { get; set; }
    public bool? IsDigital { get; set; }
    public bool? IsPrinted { get; set; }
    public bool? IsInternalOnly { get; set; }
    public string? PointOfContactOrganizationId { get; set;}
    public string? Revision { get; set; }

    [Display(Name = "When will the document be available?")]
    public DateTime ExpectedPublicationDate { get; set; }
    public DateTime DateEntered { get; set; }
    public string? EnteredBy { get; set; }
    public DateTime DateLastModified { get; set; }
}