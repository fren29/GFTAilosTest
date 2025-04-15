using System.Net.Http;
using Questao2.DTOs;
using Exercicio.Tests.Helpers;

namespace Exercicio.Tests.Questao2.Data
{
    public static partial class GolsPorTimeServiceData
    {
        public static HttpClient GetHttpClientOnlyTeam1(string team, int year)
        {
            var response = new MatchApiResponse
            {
                Data =
                [
                    new MatchDatum { Team1 = team, Team1goals = 5, Team2 = "A", Team2goals = 0, Year = year }
                ],
                Page = 1,
                Total_Pages = 1
            };

            return HttpClientMockHelper.Create(
                ($"year={year}&team1={Uri.EscapeDataString(team)}&page=1", Json(response))
            );
        }

        public static HttpClient GetHttpClientOnlyTeam2(string team, int year)
        {
            var response = new MatchApiResponse
            {
                Data = new List<MatchDatum>
                {
                    new MatchDatum { Team2 = team, Team2goals = 10, Team1 = "B", Team1goals = 0, Year = year }
                },
                Page = 1,
                Total_Pages = 1
            };

            return HttpClientMockHelper.Create(
                ($"year={year}&team2={Uri.EscapeDataString(team)}&page=1", Json(response))
            );
        }
    }
}