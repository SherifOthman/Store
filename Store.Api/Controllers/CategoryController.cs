using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs;
using Store.Application.Features.Categories.Commands.AddCategory;
using Store.Application.Features.Categories.Commands.DeactivateCategory;
using Store.Application.Features.Categories.Commands.DeleteCategory;
using Store.Application.Features.Categories.Commands.UpdateCategory;
using Store.Application.Features.Categories.Queries.GetAllCategories;
using Store.Application.Features.Categories.Queries.GetCategoryById;
using Store.Application.Responses;

namespace Store.Api.Controllers;

[ApiController]
[Route("api/Category")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<CategoryDto>>> GetAllCategories()
    {
        var response = await _mediator.Send(new GetAllCategoriesCommand());

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response<CategoryDto>>> GetCategoryById(Guid id)
    {
        var response = await _mediator.Send(new GetCategoryQuery(id));
        if (response.Error)
            return NotFound();

        return Ok(response);

    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response<CategoryDto>>> AddCategory(
        [FromBody] AddCategoryCommand request)
    {
        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (response.Error)
            return BadRequest(response);

        return CreatedAtAction(nameof(GetCategoryById),
            new { response.Data!.Id },
            response);
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory(Guid id,
       [FromBody] UpdateCategoryCommand request)
    {
        if (id != request.Id)
            return BadRequest("Id mismatch");

        var response = await _mediator.Send(request, HttpContext.RequestAborted);

        if (response.Error)
            return NotFound();


        return NoContent();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DelteCategory(Guid id)
    {
        var response = await _mediator.Send(new DeleteCategoryCommand(id));

        if (response.Error)
            return NotFound();

        return NoContent();
    }


    [Authorize(Roles = "Admin")]
    [HttpPut("deactivate/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeactivateCategory(Guid id)
    {
        var response = await _mediator.Send(new DeactivateCategoryCommand(id));

        if (response.Error)
            return NotFound();

        return NoContent();
    }

}
