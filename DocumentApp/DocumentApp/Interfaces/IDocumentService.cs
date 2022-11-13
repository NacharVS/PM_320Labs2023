using DocumentApp.Models;

namespace DocumentApp.Interfaces;

public interface IDocumentService
{
    List<Document> GetDocuments();
    Document SaveDocument(Document document);
    List<Document> SaveDocuments(List<Document> documents);
    List<Document> SaveDesignerDocuments(List<Document>? documents);
    Document Upload(Document document);

    void DownloadDocument(Document document);
}