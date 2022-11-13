using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum GasificationDocumentType
{
    [Display(Name="письмо-обращение")]
    Message,
    
    [Display(Name="задача на проектирование")]
    DesigningTask,
    
    [Display(Name="Акт обследования объекта")]
    ActResearchingObject
}