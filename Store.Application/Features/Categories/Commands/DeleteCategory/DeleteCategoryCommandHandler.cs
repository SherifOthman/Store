
using MediatR;
using Store.Application.Contracts.Persistence;
using Store.Application.Responses;
using Store.Application.Wrappers;

namespace Store.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid Id) : IRequestWrapper<Unit>;

public class DeleteCategoryCommandHandler : IHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<Response<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);

        if (category == null)
            return Response.NotFound<Unit>();

        await _categoryRepository.RemoveAsync(category);

        return Unit.Value;
    }
}
