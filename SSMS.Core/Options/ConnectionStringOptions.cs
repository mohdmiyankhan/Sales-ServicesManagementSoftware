using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Options
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string SSMS_ConnectionString { get; set; } = null!;
    }
}
