namespace Store.Application.DTOs;
public record CategoryDto(
    Guid Id,
    string Name,
    Guid RootCategoryId,
    IReadOnlyCollection<CategoryDto> SubCategories);
