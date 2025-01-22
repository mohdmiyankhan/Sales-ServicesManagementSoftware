namespace SSMS.Core.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public string? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public string? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }
        public int IsActive { get; set; }
    }
}
