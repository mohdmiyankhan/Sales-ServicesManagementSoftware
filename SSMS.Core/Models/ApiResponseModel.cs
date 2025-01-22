using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Models
{
    public class ApiResponseModel<T>
    {
        public string Message { get; set; } = null!;
        public int Status { get; set; }
        public T Data { get; set; }
    }
}
