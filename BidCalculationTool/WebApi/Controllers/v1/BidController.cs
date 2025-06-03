using Application.Abstractions;
using Application.Features.CalculateTotalCost;
using Domain.Vehicles.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BidController : ControllerBase
{
    private readonly IQueryHandler<CalculateTotalCostQuery, CalculateTotalCostResult> _handler;

    public BidController(
        IQueryHandler<CalculateTotalCostQuery, CalculateTotalCostResult> handler)
    {
        _handler = handler;
    }

    [HttpPost("calculate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<CalculateTotalCostResult> Calculate(
        [FromBody] CalculateTotalCostQuery query)
    {
        try
        {
            var result = _handler.Handle(query);
            return Ok(result);
        }
        catch (InvalidPriceException ex)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Invalid input",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }
    }
}