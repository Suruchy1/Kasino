
namespace Kasino.Domain.Entities
{
    public class BetSelection
    {
        public int SelectionId { get; set; }
        public int BetId { get; set; }
        public int EventId { get; set; }
        public int OddsId { get; set; }
        public string SelectedOutcome { get; set; } = string.Empty;
        public decimal OddsValue { get; set; }
    }
}
