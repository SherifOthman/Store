
using MapsterMapper;
using Store.Application.DTOs;
using Store.Application.Responses;
using Store.Application.Wrappers;
using Store.Domain.Abstractions.Repositories;
using Store.Domain.Entities.Products;

namespace Store.Application.Features.Categories.Commands.AddCategory;

public record AddCategoryCommand(
    string Name,
    Guid? RootCategoryId) : IRequestWrapper<CategoryDto>;

public class AddCategoryCommandHandler : IHandler<AddCategoryCommand, CategoryDto>
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public AddCategoryCommandHandler(IRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Response<CategoryDto>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.RootCategoryId != null)
            if (await _categoryRepository.GetAsync(request.RootCategoryId.Value) == null)
                return Response.Fail<CategoryDto>("RootId should be null or valid Id");


        var category = Category.Create(request.Name, request.RootCategoryId);
        await _categoryRepository.AddAsync(category);

        var categoryResponse = _mapper.Map<CategoryDto>(category);

        return categoryResponse;
    }
}
