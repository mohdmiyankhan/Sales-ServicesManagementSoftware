using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Application.Queries
{
    public record GetCoindeskDataQuery() : IRequest<ApiResponseModel<CoindeskDataModel>>;

    public class GetCoindeskDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetCoindeskDataQuery, ApiResponseModel<CoindeskDataModel>>
    {
        public async Task<ApiResponseModel<CoindeskDataModel>> Handle(GetCoindeskDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetData();
        }
    }
}
