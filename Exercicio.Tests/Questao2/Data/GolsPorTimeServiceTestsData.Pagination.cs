using System.Net.Http;
using Newtonsoft.Json;
using Questao2.DTOs;
using Exercicio.Tests.Helpers;

namespace Exercicio.Tests.Questao2.Data
{
    public static partial class GolsPorTimeServiceData
    {
        public static HttpClient GetHttpClientWithPagination(string team, int year)
        {
            var page1 = new MatchApiResponse
            {
                Page = 1,
                Per_Page = 1,
                Total = 2,
                Total_Pages = 2,
                Data = [new MatchDatum { Team1 = team, Team1goals = 4, Team2 = "A", Year = year }]
            };

            var page2 = new MatchApiResponse
            {
                Page = 2,
                Per_Page = 1,
                Total = 2,
                Total_Pages = 2,
                Data = [new MatchDatum { Team1 = team, Team1goals = 5, Team2 = "B", Year = year }]
            };

            return HttpClientMockHelper.Create(
                ($"year=2014&team1=Chelsea&page=1", Json(page1)),
                ($"year=2014&team1=Chelsea&page=2", Json(page2))
            );
        }

        internal static HttpResponseMessage Json(object obj) =>
            new(System.Net.HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(obj)) };
    }
}
