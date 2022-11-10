using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum IndustryType
{
    [Display(Name = "Водоснабжение")]
    WaterSupply,
    
    [Display(Name = "Газификация")]
    Gasification,
    
    [Display(Name = "Не указано")]
    NotSpecified,
    
    [Display(Name = "Не требуется")]
    NotRequired
}