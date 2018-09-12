using System;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bettershore.DocRaptor
{
    public class DocRaptorClient
    {
        public async Task<HttpResponseMessage> GenerateDocument(IDocumentSettings settings)
        {
            dynamic content = new ExpandoObject();

            content.test = settings.IsTestMode;
            content.document_content = settings.Content;
            content.document_type = DocumentTypeToString(settings.DocumentType);
            content.javascript = settings.EnableJavascriptProcessing;

            if (!string.IsNullOrEmpty(settings.Name))
            {
                content.name = settings.Name;
            }

            var http = settings.UseSsl ? "https" : "http";
            var url = $"{http}://docraptor.com/docs?user_credentials={settings.ApiKey}";

            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
                };
                return await client.SendAsync(httpRequest);
            }
        }

        private string DocumentTypeToString(DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.Pdf:
                    return "pdf";
                case DocumentType.Xls:
                    return "xls";
                case DocumentType.Xlsx:
                    return "xlsx";
                default:
                    throw new ArgumentException($"Invalid document type {documentType}");
            }
        }
    }
}
