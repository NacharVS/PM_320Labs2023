using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AuthorizationApp.Data
{
    public class FileSystemService
    {
        public void UploadImageToDb(string name, string path)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Authorization");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                gridFS.UploadFromStream(name, fs);
            }
        }

        public void DownloadToLocal(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Authorization");
            var gridFS = new GridFSBucket(database);
            

            if (File.Exists($"{Directory.GetCurrentDirectory() + "/wwwroot/images/"}{name}"))
            {
                return;
            }

            using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/images/")}{name}", FileMode.CreateNew))
            {
                gridFS.DownloadToStreamByName(name, fs);
            }
        }

        public List<string> GetImageNames()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Authorization");
            var gridFS = new GridFSBucket(database);

            var list = gridFS.Find(FilterDefinition<GridFSFileInfo>.Empty).ToEnumerable().Select(x => x.Filename);
            return list.ToList();
        }

        public void UpdateImagesInDB()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Authorization");
            var gridFS = new GridFSBucket(database);

            var dirInfo = new DirectoryInfo(@"C:\images");
            var dir = dirInfo.GetFiles();

            foreach (var img in dir)
            {
                using (FileStream fs = new FileStream(img.FullName, FileMode.Open))
                {
                    gridFS.UploadFromStream(img.Name, fs);
                }
            }         
        }
    }
}