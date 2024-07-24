using Microsoft.AspNetCore.Mvc;
using OpenAI.Images;

namespace OpenAiDallE.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageGeneratorController(ILogger<ImageGeneratorController> logger) : ControllerBase
{
    private readonly ILogger<ImageGeneratorController> _logger = logger;

    [HttpPost(Name = "GenerateImage")]
    public async Task<IActionResult> GenerateImage(string userText)
    {
        var imageClient = new ImageClient("dall-e-3", "api-key");
        var imgOptions = new ImageGenerationOptions()
        {
            Quality = GeneratedImageQuality.High,
            Size = GeneratedImageSize.W256xH256,
            Style = GeneratedImageStyle.Natural,
            ResponseFormat = GeneratedImageFormat.Uri
        };
        var response = await imageClient.GenerateImageAsync(userText, imgOptions);
        return Ok(response.Value.ImageUri);
    }
}