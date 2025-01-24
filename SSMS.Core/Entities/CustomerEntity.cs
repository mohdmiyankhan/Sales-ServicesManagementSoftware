namespace SSMS.Core.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int IsActive { get; set; }
    }
}
