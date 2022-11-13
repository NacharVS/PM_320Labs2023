using DocumentApp.Interfaces;
using DocumentApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DocumentApp.Services;

public class DocumentService : IDocumentService
{
    public List<Document> GetDocuments()
    {
        return DataBaseConnection.DocumentsCollection.Find(new BsonDocument()).ToList();
    }
    public Document SaveDocument(Document document)
    {
        DataBaseConnection.DocumentsCollection.InsertOne(document);
        return document;
    }
    
    public List<Document>SaveDocuments(List<Document> documents)
    {
        foreach (var document in documents)
        {
            DataBaseConnection.DocumentsCollection.InsertOne(document);
        }
        return documents;
    }
    
    public List<Document> SaveDesignerDocuments(List<Document>? documents)
    {
        foreach (var document in documents!)
        {
            DataBaseConnection.DesignerDocumentsCollection.InsertOne(document);
        }

        return documents;
    }
    
    public void DownloadDocument(Document document)
    {
        try
        {
            File.WriteAllBytes($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\wwwroot\documents\")}{document.FileName}", document.Data);
        }
        catch (Exception)
        {
        }
    }

    public Document Upload(Document document)
    {
        return document;
    }
}