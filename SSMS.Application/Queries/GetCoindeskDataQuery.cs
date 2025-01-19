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
    public record GetCoindeskDataQuery() : IRequest<CoindeskDataModel>;

    public class GetCoindeskDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetCoindeskDataQuery, CoindeskDataModel>
    {
        public async Task<CoindeskDataModel> Handle(GetCoindeskDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetData();
        }
    }
}
