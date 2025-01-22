using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddSubCategoryCommand(SubCategoryEntity SubCategory) : IRequest<ApiResponseModel<SubCategoryEntity>>;

    public class AddSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IPublisher publisher) 
        : IRequestHandler<AddSubCategoryCommand, ApiResponseModel<SubCategoryEntity>>
    {
        public async Task<ApiResponseModel<SubCategoryEntity>> Handle(AddSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await subCategoryRepository.AddSubCategoryAsync(request.SubCategory);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return category;
        }
    }
}
