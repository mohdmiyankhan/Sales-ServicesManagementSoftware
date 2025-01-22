using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteCategoryCommand(int categoryId) : IRequest<ApiResponseModel<CategoryEntity>>;

    public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) 
        : IRequestHandler<DeleteCategoryCommand, ApiResponseModel<CategoryEntity>>
    {
        public async Task<ApiResponseModel<CategoryEntity>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await categoryRepository.DeleteCategoryAsync(request.categoryId);
        }
    }
}
