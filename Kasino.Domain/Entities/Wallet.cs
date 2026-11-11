
namespace Kasino.Domain.Entities
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "CZK";
    }
}
