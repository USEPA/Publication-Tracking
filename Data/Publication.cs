namespace PublicationTracking.Data;

public class Publication
{
    public int Id { get; set; }
    public string DocumentId { get; set; }
    public int Organization { get; set; }
    public int SubOrganization { get; set; }
    public char Type { get; set; }
    public int Year { get; set; }
    public int SequenceNumber { get; set; }
    public string Volume { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string Url { get; set; }
    public string Language { get; set; }

    public string PointOfContactName { get; set; }
    public string PointOfContactOrganization { get; set; }
    public string PointOfContactPhoneNumber { get; set; }
    public string PointOfContactEmail { get; set; }
    public string PointOfContactMailCode { get; set; }
    public bool IsOriginal { get; set; }
    public bool PointOfContactOrganizationId { get; set;}
    public string Revision { get; set; }
    
    public DateTime ExpectedPublicationDate { get; set; }
    public DateTime DateEntered { get; set; }
    public string EnteredBy { get; set; }
    public string DateLastModified { get; set; }
}