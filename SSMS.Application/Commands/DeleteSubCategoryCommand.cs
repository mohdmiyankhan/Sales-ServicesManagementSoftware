using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteSubCategoryCommand(int subCategoryId) : IRequest<ApiResponseModel<SubCategoryEntity>>;

    public class DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository) 
        : IRequestHandler<DeleteSubCategoryCommand, ApiResponseModel<SubCategoryEntity>>
    {
        public async Task<ApiResponseModel<SubCategoryEntity>> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            return await subCategoryRepository.DeleteSubCategoryAsync(request.subCategoryId);
        }
    }
}
