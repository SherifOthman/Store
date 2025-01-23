using MapsterMapper;
using Store.Application.Contracts.Persistence;
using Store.Application.DTOs;
using Store.Application.Responses;
using Store.Application.Wrappers;
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Products;

namespace Store.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryQuery(Guid categoryId) : IRequestWrapper<CategoryDto>;
public class GetCategoryQueryHandler : IHandler<GetCategoryQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Response<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetWithSubCategoriesAsync(request.categoryId);
        if (category is null)
            return Response.NotFound<CategoryDto>();

        return _mapper.Map<CategoryDto>(category);
    }
}
