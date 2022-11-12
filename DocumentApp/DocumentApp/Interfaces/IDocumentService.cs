using DocumentApp.Models;

namespace DocumentApp.Interfaces;

public interface IDocumentService
{
    List<Document> GetDocuments();
    Document Save(Document document);
    Document Upload(string documentId, byte[] data);
    void DeleteDocument(string documentId);
}