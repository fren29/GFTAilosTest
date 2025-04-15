using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Questao2.DTOs;

namespace Exercicio.Tests.Helpers
{
    public static class HttpClientMockFootballHelper
    {
        public static HttpClient CreateMockForTeamGoals(string team, int year, int team1Goals, int team2Goals)
        {
            var team1Match = new MatchDatum
            {
                Team1 = team,
                Team1goals = team1Goals,
                Team2 = "Rival1",
                Team2goals = 0,
                Year = year
            };

            var team2Match = new MatchDatum
            {
                Team1 = "Rival2",
                Team1goals = 0,
                Team2 = team,
                Team2goals = team2Goals,
                Year = year
            };

            var team1Response = new MatchApiResponse
            {
                Page = 1,
                Per_Page = 10,
                Total = 1,
                Total_Pages = 1,
                Data = new List<MatchDatum> { team1Match }
            };

            var team2Response = new MatchApiResponse
            {
                Page = 1,
                Per_Page = 10,
                Total = 1,
                Total_Pages = 1,
                Data = new List<MatchDatum> { team2Match }
            };

            var handler = new Mock<HttpMessageHandler>();

            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri!.ToString().Contains($"team1={Uri.EscapeDataString(team)}")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(CreateResponse(team1Response));

            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.RequestUri!.ToString().Contains($"team2={Uri.EscapeDataString(team)}")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(CreateResponse(team2Response));

            return new HttpClient(handler.Object);
        }

        private static HttpResponseMessage CreateResponse(object data)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data))
            };
        }
    }
}
