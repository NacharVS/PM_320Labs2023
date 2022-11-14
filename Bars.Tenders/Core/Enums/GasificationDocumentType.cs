using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum GasificationDocumentType
{
    [Display(Name="Письмо-обращение")]
    Message,
    
    [Display(Name="Задача на проектирование")]
    DesigningTask,
    
    [Display(Name="Акт обследования объекта")]
    ActResearchingObject,
    
    [Display(Name = "Ситуационный план")]
    SituationalPlan,
    
    
}