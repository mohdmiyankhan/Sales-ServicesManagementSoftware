using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateCategoryCommand(int categoryId, CategoryEntity Category) : IRequest<ApiResponseModel<CategoryEntity>>;

    public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) 
        : IRequestHandler<UpdateCategoryCommand, ApiResponseModel<CategoryEntity>>
    {
        public async Task<ApiResponseModel<CategoryEntity>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await categoryRepository.UpdateCategoryAsync(request.categoryId, request.Category);
        }
    }
}
