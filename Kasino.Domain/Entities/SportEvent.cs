
namespace Kasino.Domain.Entities
{
    public class SportEvent
    {
        public int EventId { get; set; }
        public int SportId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Participant1 { get; set; } = string.Empty;
        public string Participant2 { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Result { get; set; }
        public int CreatedBy { get; set; }
    }
}
