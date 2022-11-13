using Core.Enums;

namespace Core.Entities.Documents;

public class GasificationDocument : BaseDocument
{
    public GasificationDocumentType DocumentType { get; set; }
}