using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateSubCategoryCommand(int subCategoryId, SubCategoryEntity SubCategory) : IRequest<ApiResponseModel<SubCategoryEntity>>;

    public class UpdateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository) 
        : IRequestHandler<UpdateSubCategoryCommand, ApiResponseModel<SubCategoryEntity>>
    {
        public async Task<ApiResponseModel<SubCategoryEntity>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            return await subCategoryRepository.UpdateSubCategoryAsync(request.subCategoryId, request.SubCategory);
        }
    }
}
