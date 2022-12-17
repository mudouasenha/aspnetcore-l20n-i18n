using aspnetcore_l20n_i18n.Api.DTOs;
using aspnetcore_l20n_i18n.Services.Football.Abstractions;
using aspnetcore_l20n_i18n.Services.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace aspnetcore_l20n_i18n.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CorinthiansFanController : ControllerBase
{
    private readonly ILogger<CorinthiansFanController> _logger;
    private IStringLocalizer<Messages> _localizer;
    private readonly ICorinthiansFanService _corinthiansFanService;

    public CorinthiansFanController(ILogger<CorinthiansFanController> logger, IStringLocalizer<Messages> localizer, ICorinthiansFanService corinthiansFanService)
    {
        _logger = logger;
        _localizer = localizer;
        _corinthiansFanService = corinthiansFanService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateCommandDTO inputModel)
    {
        var result = 1; //await user.create;
        return Ok(result);
    }

    [HttpGet()]
    public async Task<IActionResult> Get([FromBody] UserFilterQueryDTO inputModel)
    {
        var result = 1; //await user.create;
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = 1; //await user.create;
        return Ok(result);
    }
}