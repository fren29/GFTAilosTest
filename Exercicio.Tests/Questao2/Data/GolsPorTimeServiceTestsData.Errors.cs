using System.Net.Http;
using Questao2.DTOs;
using Exercicio.Tests.Helpers;

namespace Exercicio.Tests.Questao2.Data
{
    public static partial class GolsPorTimeServiceData
    {
        public static HttpClient GetHttpClientWithInvalidGoalValue(string team, int year)
        {
            var match1 = new MatchDatum { Team1 = team, Team1goals = 2, Team2 = "A", Year = year };
            var match2 = new MatchDatum { Team1 = team, Team1goals = 0, Team2 = "A", Year = year };

            var response = new MatchApiResponse
            {
                Data = new List<MatchDatum> { match1, match2 },
                Page = 1,
                Total_Pages = 1
            };

            return HttpClientMockHelper.Create(
                ($"team1={Uri.EscapeDataString(team)}", Json(response))
            );
        }

        public static HttpClient GetHttpClientWithNoMatches()
        {
            var response = new MatchApiResponse
            {
                Data = [],
                Page = 1,
                Total_Pages = 1
            };

            return HttpClientMockHelper.Create(("irrelevant", Json(response)));
        }
    }
}
