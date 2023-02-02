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
    public string? Comment { get; set; }

    [Display(Name = "Publication URL")]
    public string? Url { get; set; }
    public Data.Language? Language { get; set; }
    public DateTime? DateRequested { get; set; }

    [Required]
    [Display(Name = "Requestor Name")]
    public string? PointOfContactName { get; set; }
    [Display(Name = "Requestor Orginization")]
    public string? PointOfContactOrganization { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Requestor Phone Number")]
    public string PointOfContactPhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string? PointOfContactEmail { get; set; }
    public string? PointOfContactMailCode { get; set; }
    public bool? IsOriginal { get; set; }
    public bool? IsDigital { get; set; }
    public bool? IsPrinted { get; set; }
    public bool? IsInternalOnly { get; set; }
    [Display(Name = "Original Id")]
    public string? OriginalId { get; set;}
    public string? Revision { get; set; }

    [Display(Name = "When will the document be available?")]
    public DateTime ExpectedPublicationDate { get; set; }
    public DateTime DateEntered { get; set; }
    public string? EnteredBy { get; set; }
    public DateTime DateLastModified { get; set; }
}