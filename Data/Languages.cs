using System.ComponentModel.DataAnnotations;

namespace PublicationTracking.Data;
public enum Language
{
    English,
    Arabic,
    Armenian,
    Cambodian,
    Chinese,
    French,
    German,
    [Display(Name="Haitian Creole")]
    Haitian_Creole,
    Hindi,
    Hmong,
    Italian,
    Japanese,
    Korean,
    Laotian,
    Polish,
    Portuguese,
    Russian,
    [Display(Name="Simplified Chinese")]
    Simplified_Chinese,
    Spanish,
    Tagalog,
    Thai,
    [Display(Name="Traditional Chinese")]
    Traditional_Chinese,
    Vietnamese
}