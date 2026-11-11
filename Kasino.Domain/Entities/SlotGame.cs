
namespace Kasino.Domain.Entities
{
    public class SlotGame
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public DateTime PlayedAt { get; set; }
        public string Result { get; set; } = string.Empty;
        public int? BonusId { get; set; }
    }
}
