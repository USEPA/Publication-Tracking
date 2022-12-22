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
    [Display(Name="Hatian Creole")]
    Hatian_Creole,
    Hindi,
    Hmong,
    Italian,
    Japanese,
    Korean,
    Laotian,
    Polish,
    Portuguese,
    Russian,
    Spanish,
    Tagalog,
    Thai,
    [Display(Name="Traditional Chinese")]
    Traditional_Chinese,
    Vietnamese
}