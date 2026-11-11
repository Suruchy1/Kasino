
namespace Kasino.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? Reference { get; set; }
    }
}
