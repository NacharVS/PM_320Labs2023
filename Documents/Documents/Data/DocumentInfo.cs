namespace Documents.Data
{
    public class DocumentInfo
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public bool IsImportant { get; set; }
        public bool IsAccepted { get; set; }
        public byte[] Content { get; set; }
    }
}