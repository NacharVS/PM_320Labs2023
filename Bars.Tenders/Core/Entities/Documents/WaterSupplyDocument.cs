using Core.Enums;

namespace Core.Entities.Documents;

public class WaterSupplyDocument : BaseDocument
{
    public WaterSupplyDocumentType DocumentType { get; set; }
}