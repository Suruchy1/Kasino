
namespace Kasino.Domain.Entities
{
    public class BonusUsage
    {
        public int UsageId { get; set; }
        public int UserBonusId { get; set; }
        public int BetId { get; set; }
        public DateTime UsedAt { get; set; }
        public decimal AppliedValue { get; set; }
    }
}
