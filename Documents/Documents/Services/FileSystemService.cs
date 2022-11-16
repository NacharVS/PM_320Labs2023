using Documents.Data;
using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Threading.Tasks;

namespace Documents.Services
{
    public class FileSystemService
    {
        private GridFSBucket _gridFS;

        public FileSystemService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var connection = client.GetDatabase("Documents");

            _gridFS = new GridFSBucket(connection);
        }

        public async Task LoadFile(InputFileChangeEventArgs args, DocumentInfo document)
        {
            foreach (var file in args.GetMultipleFiles(args.FileCount))
            {
                Stream stream = file.OpenReadStream();
                await _gridFS.UploadFromStreamAsync(file.Name, stream);
                stream.Dispose();

                document.FileName = file.Name;

            }
        }


    }
}
