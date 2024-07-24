using Microsoft.AspNetCore.Mvc;
using OpenAiChatGPT.Services;

namespace OpenAiChatGPT.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : Controller
{
    private readonly ILogger<OpenAiController> _logger;

    public readonly IOpenAiService _OpenAiService;

    // GET
    public OpenAiController(ILogger<OpenAiController> logger,
        IOpenAiService OpenAiService)
    {
        _logger = logger;
        _OpenAiService = OpenAiService;
    }
    [HttpPost]
    [Route("CompleteSentence")]
    public async Task<IActionResult> CompleteSentence(string text)
    {
        var result = await _OpenAiService.CompleteSentence(text);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("CompleteAdvanceSentence")]
    public async Task<IActionResult> CompleteSentenceAdvance(string text)
    {
        var result = await _OpenAiService.CompleteSentenceAdvance(text);
        return Ok(result);
    }
    [HttpPost]
    [Route("AskQuestion")]
    public async Task<IActionResult> CheckProgrammingLanguage(string text)
    {
        var result = await _OpenAiService.CheckProgrammingLanguage(text);
        return Ok(result);
    }
}