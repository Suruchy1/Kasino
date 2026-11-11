
namespace Kasino.Domain.Entities
{
    public class IdentityVerification
    {
        public int VerificationId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? VerifiedAt { get; set; }
        public string VerificationMethod { get; set; } = string.Empty;
    }
}
