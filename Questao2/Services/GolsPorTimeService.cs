using Newtonsoft.Json;
using Questao2.DTOs;

namespace Questao2.Services;
public static class GolsPorTimeService
{
    private const string BaseUrl = "https://jsonmock.hackerrank.com/api/football_matches";

    public static int GetTotalScoredGoals(string team, int year)
    {
        using var httpClient = new HttpClient();
        return GetGoalsAsync(httpClient, team, year).GetAwaiter().GetResult();
    }

    public static async Task<int> GetGoalsAsync(HttpClient client, string team, int year)
    {
        int goals = 0;
        goals += await GetGoalsBySide(client, team, year, "team1", m => m.Team1 == team ? m.Team1goals : 0);
        goals += await GetGoalsBySide(client, team, year, "team2", m => m.Team2 == team ? m.Team2goals : 0);
        return goals;
    }

    private static async Task<int> GetGoalsBySide(HttpClient client, string team, int year, string teamParam, Func<MatchDatum, int> selector)
    {
        int totalGoals = 0;
        int page = 1;
        bool hasMorePages;

        do
        {
            var url = $"{BaseUrl}?year={year}&{teamParam}={Uri.EscapeDataString(team)}&page={page}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MatchApiResponse>(content);

            var matches = result?.Data ?? new List<MatchDatum>();
            foreach (var match in matches)
            {
                if (match != null)
                {
                    totalGoals += selector(match);
                }
            }

            hasMorePages = result != null && page < result.Total_Pages;
            page++;

        } while (hasMorePages);

        return totalGoals;
    }
}
