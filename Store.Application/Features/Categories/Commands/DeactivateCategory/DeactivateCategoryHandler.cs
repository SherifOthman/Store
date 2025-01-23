
using MediatR;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Application.Wrappers;

namespace Store.Application.Features.Categories.Commands.DeactivateCategory;

public record DeactivateCategoryCommand(Guid Id) : IRequestWrapper<Unit>;

public class DeactivateCategoryHandler : IHandler<DeactivateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeactivateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Response<Unit>> Handle(DeactivateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);
        if (category == null)
            return Response.NotFound<Unit>();

        category.Deactivate();
        await _categoryRepository.UpdateAsync(category);

        return Unit.Value;
    }
}
