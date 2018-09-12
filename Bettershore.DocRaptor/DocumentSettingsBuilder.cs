namespace Bettershore.DocRaptor
{
    public class DocumentSettingsBuilder
    {
        private readonly DocumentType _documentType;
        private readonly string _content;
        private bool _isTestMode;
        private bool _enableJavascriptProcessing;
        private string _name;
        private readonly string _apiKey;
        private bool _useSsl;

        public DocumentSettingsBuilder(string apiKey, DocumentType documentType, string content)
        {
            _apiKey = apiKey;
            _documentType = documentType;
            _content = content;
        }

        public IDocumentSettings Build()
        {
            return new DocumentSettings()
            {
                DocumentType = _documentType,
                Content = _content,
                IsTestMode = _isTestMode,
                EnableJavascriptProcessing = _enableJavascriptProcessing,
                Name = _name,
                ApiKey = _apiKey,
                UseSsl = _useSsl
            };
        }

        public DocumentSettingsBuilder WithIsTestMode(bool isTestMode)
        {
            _isTestMode = isTestMode;
            return this;
        }

        public DocumentSettingsBuilder EnableJavascriptProcessing(bool enableJavascriptProcessing)
        {
            _enableJavascriptProcessing = enableJavascriptProcessing;
            return this;
        }

        public DocumentSettingsBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public DocumentSettingsBuilder WithUseSsl(bool useSsl)
        {
            _useSsl = useSsl;
            return this;
        }
    }
}