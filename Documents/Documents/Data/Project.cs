using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Documents.Data
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Department_ID { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
        public string Customer { get; set; }
        public string Architect { get; set; }
        public string Builder { get; set; }
        public List<DocumentInfo> BuilderDocumentInfos { get; set; }
        public List<DocumentInfo> ArchitectDocumentInfos { get; set; }
        public List<FormInfo> FormInfos { get; set; }

        public Project()
        {
            CreatedDate = DateTime.Now;
        }
    }
}