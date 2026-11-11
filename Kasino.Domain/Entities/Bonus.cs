
namespace Kasino.Domain.Entities
{
    public class Bonus
    {
        public int BonusId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ValidityDays { get; set; }
    }
}
