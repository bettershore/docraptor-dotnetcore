namespace Bettershore.DocRaptor
{
    public class DocumentSettings : IDocumentSettings
    {
        public DocumentType DocumentType { get; set; }
        public string Content { get; set; }
        public bool IsTestMode { get; set; }
        public bool EnableJavascriptProcessing { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
        public bool UseSsl { get; set; }
    }
}