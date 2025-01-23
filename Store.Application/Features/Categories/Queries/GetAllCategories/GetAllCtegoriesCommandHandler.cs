using MapsterMapper;
using Store.Application.Contracts.Persistence;
using Store.Application.DTOs;
using Store.Application.Responses;
using Store.Application.Wrappers;

namespace Store.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesCommand : IRequestWrapper<IEnumerable<CategoryDto>>;

public class GetAllCtegoriesCommandHandler : IHandler<GetAllCategoriesCommand, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCtegoriesCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}
