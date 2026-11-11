
namespace Kasino.Domain.Entities
{
    public class Bet
    {
        public int BetId { get; set; }
        public int UserId { get; set; }
        public decimal StakeAmount { get; set; }
        public decimal PotentialPayout { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime PlacedAt { get; set; }
        public DateTime? SettledAt { get; set; }
    }
}
