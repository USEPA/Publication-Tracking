namespace PublicationTracking.Data;

public class ImportResults
{
    public string DocumentId { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
}