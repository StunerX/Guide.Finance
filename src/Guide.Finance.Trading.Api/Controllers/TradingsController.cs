using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Application.UseCases.Tradings.Get;
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
    public async Task<IActionResult> Post([FromBody] CreateTradingInput trading, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(trading, cancellationToken);
        return CreatedAtAction(nameof(Post), new  {output.Id}, output);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(GetTradingPriceVariationOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(new GetTradingPriceVariationInput(), cancellationToken);
        return Ok(output);
    }
}