using Exercicio.Tests.Questao2.Data;
using FluentAssertions;
using Questao2.Services;
using Xunit;

namespace Exercicio.Tests.Questao2
{
    public class GolsPorTimeServiceTests
    {
        [Fact]
        public async Task Should_Calculate_Goals_From_Mock_Data()
        {
            var httpClient = GolsPorTimeServiceData.GetHttpClientOnlyTeam1("Chelsea", 2013);
            var httpClient2 = GolsPorTimeServiceData.GetHttpClientOnlyTeam2("Chelsea", 2013);

            var goals1 = await GolsPorTimeService.GetGoalsAsync(httpClient, "Chelsea", 2013);
            var goals2 = await GolsPorTimeService.GetGoalsAsync(httpClient2, "Chelsea", 2013);
            (goals1 + goals2).Should().Be(15);
        }

        [Fact]
        public async Task Should_Aggregate_Goals_From_Multiple_Pages()
        {
            var httpClient = GolsPorTimeServiceData.GetHttpClientWithPagination("Chelsea", 2014);
            var totalGoals = await GolsPorTimeService.GetGoalsAsync(httpClient, "Chelsea", 2014);
            totalGoals.Should().Be(9);
        }

        [Fact]
        public async Task Should_Skip_Invalid_Goals_Values()
        {
            var httpClient = GolsPorTimeServiceData.GetHttpClientWithInvalidGoalValue("TeamX", 2020);
            var httpClient2 = GolsPorTimeServiceData.GetHttpClientWithNoMatches();
            var goals1 = await GolsPorTimeService.GetGoalsAsync(httpClient, "TeamX", 2020);
            var goals2 = await GolsPorTimeService.GetGoalsAsync(httpClient2, "TeamX", 2020);
            (goals1 + goals2).Should().Be(2);
        }

        [Fact]
        public async Task Should_Return_Zero_If_No_Matches_Found()
        {
            var httpClient = GolsPorTimeServiceData.GetHttpClientWithNoMatches();
            var totalGoals = await GolsPorTimeService.GetGoalsAsync(httpClient, "NonExistent", 1999);
            totalGoals.Should().Be(0);
        }

        [Fact]
        public async Task Should_Handle_Only_Team1_Appearances()
        {
            var httpClient = GolsPorTimeServiceData.GetHttpClientOnlyTeam1("OnlyTeam1", 2022);
            var httpClient2 = GolsPorTimeServiceData.GetHttpClientWithNoMatches();

            var goals1 = await GolsPorTimeService.GetGoalsAsync(httpClient, "OnlyTeam1", 2022);
            var goals2 = await GolsPorTimeService.GetGoalsAsync(httpClient2, "OnlyTeam1", 2022);
            (goals1 + goals2).Should().Be(5);
        }

        [Fact]
        public async Task Should_Handle_Only_Team2_Appearances()
        {
            var httpClient = GolsPorTimeServiceData.GetHttpClientOnlyTeam2("OnlyTeam2", 2022);
            var httpClient2 = GolsPorTimeServiceData.GetHttpClientWithNoMatches();
            var goals1 = await GolsPorTimeService.GetGoalsAsync(httpClient, "OnlyTeam2", 2022);
            var goals2 = await GolsPorTimeService.GetGoalsAsync(httpClient2, "OnlyTeam2", 2022);
            (goals1 + goals2).Should().Be(10);
        }
    }
}
