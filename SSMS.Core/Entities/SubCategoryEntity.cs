namespace SSMS.Core.Entities
{
    public class SubCategoryEntity
    {
        public int Id { get; set; }
        public string SubCategory { get; set; } = null!;
        public int CategoryId { get; set; }
        public string Description { get; set; } = null!;
        public string? CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; } = null!;
        public string? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; } = null!;
        public DateTime? DeletedDate { get; set; }
        public int IsActive { get; set; }
    }
}
