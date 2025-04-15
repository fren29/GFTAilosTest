namespace Questao2.DTOs
{
    public class MatchApiResponse
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<MatchDatum> Data { get; set; } = new();
    }
}
