using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddCategoryCommand(CategoryEntity Category) : IRequest<ApiResponseModel<CategoryEntity>>;

    public class AddCategoryCommandHandler(ICategoryRepository categoryRepository, IPublisher publisher) 
        : IRequestHandler<AddCategoryCommand, ApiResponseModel<CategoryEntity>>
    {
        public async Task<ApiResponseModel<CategoryEntity>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.AddCategoryAsync(request.Category);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return category;
        }
    }
}
