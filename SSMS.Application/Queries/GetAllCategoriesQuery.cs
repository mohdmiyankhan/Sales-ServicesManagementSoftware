using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllCategoriesQuery() : IRequest<ApiResponseModel<IEnumerable<CategoryEntity>>>;

    public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        : IRequestHandler<GetAllCategoriesQuery, ApiResponseModel<IEnumerable<CategoryEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<CategoryEntity>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAllCategoriesAsync();
        }
    }
}
