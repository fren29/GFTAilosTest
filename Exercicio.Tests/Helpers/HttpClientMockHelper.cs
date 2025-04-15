using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace Exercicio.Tests.Helpers
{
    public static class HttpClientMockHelper
    {
        public static HttpClient Create(params (string match, HttpResponseMessage response)[] routes)
        {
            var handler = new Mock<HttpMessageHandler>();

            // fallback for unmatched URLs
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"data\":[],\"page\":1,\"total_pages\":1}")
                })
                .Callback<HttpRequestMessage, CancellationToken>((req, _) =>
                {
                    Console.WriteLine($"[FALLBACK] URL não mapeada: {req.RequestUri}");
                });

            foreach (var (match, response) in routes)
            {
                handler.Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync",
                        ItExpr.Is<HttpRequestMessage>(req =>
                            req.RequestUri!.ToString().Contains(match)),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(response);
            }

            return new HttpClient(handler.Object);
        }

        public static HttpResponseMessage CreateResponse(object data) =>
            new(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
    }
}
