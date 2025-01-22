using SSMS.Core.Entities;
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
    public class ExternalVendorRepository(ICoindeskHttpClientService coindeskHttpClientService,
        IJokeHttpClientService jokeHttpClientService)
        : IExternalVendorRepository
    {
        public async Task<ApiResponseModel<CoindeskDataModel>> GetData()
        {
            var coindesk = await coindeskHttpClientService.GetData();
            if (coindesk is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<CoindeskDataModel>
                {
                    Message = "Coindesk data fetched successfully.",
                    Status = 200,
                    Data = coindesk
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CoindeskDataModel>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<JokeModel>> GetJoke()
        {
            var joke = await jokeHttpClientService.GetData();
            if (joke is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<JokeModel>
                {
                    Message = "Joke data fetched successfully.",
                    Status = 200,
                    Data = joke
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<JokeModel>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }
    }
}
