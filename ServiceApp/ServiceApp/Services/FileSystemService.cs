using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using Microsoft.AspNetCore.Components.Forms;

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

        public void DownloadFileToProject(IBrowserFile file)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProjectFiles");
            var gridFS = new GridFSBucket(database);
            try
            {
                using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/files/")}{file.Name}", FileMode.CreateNew))
                {
                    gridFS.DownloadToStreamByName(file.Name, fs);
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
