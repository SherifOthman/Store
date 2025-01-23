using MediatR;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Application.Wrappers;

namespace Store.Application.Features.Categories.Commands.UpdateCategory;


public record UpdateCategoryCommand(
    Guid Id,
    string Name) : IRequestWrapper<Unit>;

public class UpdateCategoryCommandHandler : IHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Response<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);

        if (category is null)
            return Response.NotFound<Unit>();

        category.UpdateName(request.Name);

        await _categoryRepository.UpdateAsync(category);

        return Unit.Value;
    }
}
