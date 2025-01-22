using SSMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Interfaces
{
    public interface IExternalVendorRepository
    {
        Task<ApiResponseModel<CoindeskDataModel>> GetData();
        Task<ApiResponseModel<JokeModel>> GetJoke();
    }
}
