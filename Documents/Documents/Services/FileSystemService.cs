using Documents.Data;
using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
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
                document.Content = GetByteArray(file.Name);
            }
        }

        public byte[] GetByteArray(string fileName)
        {
            byte[] byteArray;

            try
            {
                byteArray = _gridFS.DownloadAsBytesByName(fileName);
            }
            catch
            {
                byteArray = null;
            }

            return byteArray;
        }

        public void DownloadDocumentToProject(DocumentInfo document)
        {
            try
            {
                System.IO.File.WriteAllBytes($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/documents/")}{document.FileName}", document.Content);
            }
            catch (Exception) {}
        }
    }
}
