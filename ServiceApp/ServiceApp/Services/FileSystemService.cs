using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace ServiceApp.Services
{
    public class FileSystemService
    {
        public async Task UploadFileToDb(Stream stream, string fileName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProjectFiles");
            var gridFS = new GridFSBucket(database);
            await gridFS.UploadFromStreamAsync(fileName, stream);
        }
    }
}
