using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Infrastructure.Repositories
{
    public class ExternalVendorRepository(
        ICoindeskHttpClientService coindeskHttpClientService,
        IJokeHttpClientService jokeHttpClientService)
        : IExternalVendorRepository
    {
        public async Task<CoindeskDataModel> GetData()
        {
            return await coindeskHttpClientService.GetData();
        }

        public async Task<JokeModel> GetJoke()
        {
            return await jokeHttpClientService.GetData();
        }
    }
}
