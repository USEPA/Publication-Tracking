using System.ComponentModel.DataAnnotations;

namespace PublicationTracking.Data;

public class ResponsibleCode
{
    [Key]
    public string Code { get; set; }
    public string Organization { get; set; }
}