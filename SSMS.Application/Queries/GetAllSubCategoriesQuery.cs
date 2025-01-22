using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllSubCategoriesQuery() : IRequest<ApiResponseModel<IEnumerable<SubCategoryEntity>>>;

    public class GetAllSubCategoriesQueryHandler(ISubCategoryRepository subCategoryRepository)
        : IRequestHandler<GetAllSubCategoriesQuery, ApiResponseModel<IEnumerable<SubCategoryEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<SubCategoryEntity>>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await subCategoryRepository.GetAllSubCategoriesAsync();
        }
    }
}
