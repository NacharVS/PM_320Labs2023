using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BlazorApp7.Data
{
    public class FileSystemService
    {
        public void UploadImageToDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Images321");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream("C:/Users/Vadim.Nacharov/Desktop/images321/ball.jpg", FileMode.Open))
            {
                gridFS.UploadFromStream("ggg.jpg", fs);
            }
        }

        public void DownloadToLocal()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Images321");
            var gridFS = new GridFSBucket(database);
            using (FileStream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Images/")}DeserializedBall.jpg", FileMode.CreateNew))
            {
                gridFS.DownloadToStreamByName("ggg.jpg", fs);
            }
        }
        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles(e.FileCount))
            {
                _loadedFiles.Add(file);
                Stream stream = file.OpenReadStream();
                await service.UploadImageToDb(stream);
                stream.Dispose();
            }

        }
    }
}
