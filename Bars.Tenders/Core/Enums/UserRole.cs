using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum UserRole
{
    [Display(Name = "Заказчик")]
    Customer,
    
    [Display(Name = "Проектировщик")]
    Architect,
    
    [Display(Name = "Застройщик")]
    Builder
}