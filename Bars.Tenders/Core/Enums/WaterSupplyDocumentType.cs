using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum WaterSupplyDocumentType
{
    [Display(Name="Акт обследования и выбора трассы водоснабжения")]
    ActResearchWaterSupplyPath,
    
    [Display(Name="Акт обследования и выбора места под проектируемую скважину")]
    ActResearchWaterSupplyHole,
    
    [Display(Name="Градостроительный план земельного участка")]
    AreaBuildingPlan,
    
    [Display(Name = "Технические условия на водоснабжение")]
    WaterSupplyTechState,
    
    [Display(Name = "Технические условия на электроснабжение (для насосной станции первого или второго подъема)")]
    ElecticSupplyTechState,
    
    [Display(Name = "Справка согласования с собственниками земельных участков")]
    ActAcceptanceWithOwners,
    
    [Display(Name = "Сведения о наличие водозаборных скважин (родников) на территории хозяйства")]
    ActHavingWaterHoles
}