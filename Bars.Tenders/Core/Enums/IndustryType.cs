using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

/// <summary>
/// Тип отрасли
/// </summary>
public enum IndustryType
{
    [Display(Name = "Не указано")]
    NotSpecified,
    
    [Display(Name = "Водоснабжение")]
    WaterSupply,
    
    [Display(Name = "Газификация")]
    Gasification
}