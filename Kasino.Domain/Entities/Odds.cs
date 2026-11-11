
namespace Kasino.Domain.Entities
{
    public class Odds
    {
        public int OddsId { get; set; }
        public int EventId { get; set; }
        public string Outcome { get; set; } = string.Empty;
        public decimal OddsValue { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int CreatedBy { get; set; }
    }
}
