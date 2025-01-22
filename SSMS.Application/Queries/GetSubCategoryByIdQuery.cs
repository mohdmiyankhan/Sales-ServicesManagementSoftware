using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetSubCategoryByIdQuery(int subCategoryId) : IRequest<ApiResponseModel<SubCategoryEntity>>;

    public class GetSubCategoryByIdQueryHandler(ISubCategoryRepository subCategoryRepository)
        : IRequestHandler<GetSubCategoryByIdQuery, ApiResponseModel<SubCategoryEntity>>
    {
        public async Task<ApiResponseModel<SubCategoryEntity>> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await subCategoryRepository.GetSubCategoryByIdAsync(request.subCategoryId);
        }
    }
}
