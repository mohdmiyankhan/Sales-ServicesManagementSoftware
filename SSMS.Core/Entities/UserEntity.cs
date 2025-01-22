namespace SSMS.Core.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Password1 { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public int RoleId { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public string? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }
        public int IsActive { get; set; }
        public string HashEncryptionKey { get; set; } = null!;
        public DateTime? PasswordDate { get; set; }
        public DateTime? BlockedOn { get; set; }
        public int LoginAttempt { get; set; }
    }
}
