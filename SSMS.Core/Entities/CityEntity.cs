using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        [NotMapped]
        public string? Country { get; set; }
        public int CountryId { get; set; }
        public int DefaultSetting { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int IsActive { get; set; }
    }
}
