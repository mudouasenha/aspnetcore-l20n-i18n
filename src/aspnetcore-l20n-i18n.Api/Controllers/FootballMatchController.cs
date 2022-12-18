//using aspnetcore_l20n_i18n.Api.DTOs;
//using aspnetcore_l20n_i18n.Services.Football.Abstractions;
//using aspnetcore_l20n_i18n.Services.Resources;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Localization;

//namespace aspnetcore_l20n_i18n.Api.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class FootballMatchController : ControllerBase
//{
//    private readonly ILogger<FootballMatchController> _logger;
//    private IStringLocalizer<Messages> _localizer;
//    private readonly IFootballMatchService _footballMatchService;

//    public FootballMatchController(ILogger<FootballMatchController> logger, IStringLocalizer<Messages> localizer, IFootballMatchService footballMatchService)
//    {
//        _logger = logger;
//        _localizer = localizer;
//        _footballMatchService = footballMatchService;
//    }

//    [HttpPost()]
//    public async Task<IActionResult> CreateMatch([FromBody] CreateMatchCommandDTO inputModel)
//    {
//        var result = 1; //await user.create;
//        return Ok(result);
//    }

//    [HttpGet()]
//    public async Task<IActionResult> GetMatches([FromBody] MatchFilterQueryDTO inputModel)
//    {
//        var result = 1; //await user.create;
//        return Ok(result);
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById([FromRoute] int id)
//    {
//        var result = 1; //await user.create;
//        return Ok(result);
//    }
//}