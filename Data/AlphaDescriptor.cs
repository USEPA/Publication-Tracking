using System.ComponentModel.DataAnnotations;

namespace PublicationTracking.Data;

public class AlphaDescriptor
{
    [Key]
    public string Code { get; set; }
    public string Description { get; set; }
}