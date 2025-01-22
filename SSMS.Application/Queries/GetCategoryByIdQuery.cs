using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetCategoryByIdQuery(int categoryId) : IRequest<ApiResponseModel<CategoryEntity>>;

    public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        : IRequestHandler<GetCategoryByIdQuery, ApiResponseModel<CategoryEntity>>
    {
        public async Task<ApiResponseModel<CategoryEntity>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetCategoryByIdAsync(request.categoryId);
        }
    }
}
