using Guide.Finance.Application.UseCases.Tradings.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Finance.Trading.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TradingsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public TradingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
  

    [HttpPost]
    [ProducesResponseType(typeof(CreateTradingOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateTradingInput category, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(category, cancellationToken);
        return CreatedAtAction(nameof(Post), new  {output.Id}, output);
    }
}