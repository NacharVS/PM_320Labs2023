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
    public Document Save(Document document)
    {
        DataBaseConnection.DocumentsCollection.InsertOne(document);
        return document;
    }

    public Document Upload(string documentId, byte[] data)
    {
        var document = DataBaseConnection.DocumentsCollection.Find(x=> x.Id == documentId).FirstOrDefault();
        document.Data = data;
        DataBaseConnection.DocumentsCollection.ReplaceOne(x => x.Id == documentId, document);
        return document;
    }

    public void DeleteDocument(string documentId)
    {
        var document = DataBaseConnection.DocumentsCollection.Find(x=> x.Id == documentId).FirstOrDefault();
        document.Data = null;
        DataBaseConnection.DocumentsCollection.ReplaceOne(x => x.Id == documentId, document);
    }
}