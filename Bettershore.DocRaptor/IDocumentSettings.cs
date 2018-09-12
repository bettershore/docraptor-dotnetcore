namespace Bettershore.DocRaptor
{
    public interface IDocumentSettings
    {
        DocumentType DocumentType { get; }
        string Content { get; }
        bool IsTestMode { get; }
        bool EnableJavascriptProcessing { get; }
        string Name { get; }
        string ApiKey { get; }
        bool UseSsl { get; }
    }
}