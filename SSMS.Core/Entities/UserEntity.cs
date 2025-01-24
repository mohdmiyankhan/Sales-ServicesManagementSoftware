namespace SSMS.Core.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Password1 { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int IsActive { get; set; }
        public string HashEncryptionKey { get; set; }
        public DateTime? PasswordDate { get; set; }
        public DateTime? BlockedOn { get; set; }
        public int LoginAttempt { get; set; }
    }
}
