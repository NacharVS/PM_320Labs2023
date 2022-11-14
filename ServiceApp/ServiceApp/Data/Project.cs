using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data
{
    public class Project
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string Name { get; set; }

        public string Department { get; set; }

        public string Customer { get; set; }
        public string Developer { get; set; }
        public string Designer { get; set; }
        public Dictionary<string, bool> DocsPreor { get; set; }
        public Dictionary<string, bool> DocsPreorTwo { get; set; }
        public Dictionary<string, string> FormOfDesignerOne { get; set; }
        public Dictionary<string, string> FormOfDesigner { get; set; }
        public List<string> FormOfDesignerValue { get; set; }
        public List<string> LoadedFilesDev = new List<string>();
        public List<string> LoadedFilesDes = new List<string>();
        public string CommentForDes { get; set; }
        public string CommentForDev { get; set; }
        public bool IsApproved { get; set; }
    }
}
