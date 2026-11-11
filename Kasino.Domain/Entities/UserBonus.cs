
namespace Kasino.Domain.Entities
{
    public class UserBonus
    {
        public int UserBonusId { get; set; }
        public int UserId { get; set; }
        public int BonusId { get; set; }
        public int? GameId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime ObtainedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
