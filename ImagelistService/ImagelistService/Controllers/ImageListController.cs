using Microsoft.AspNetCore.Mvc;

namespace ImagelistService.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageListController : ControllerBase
{
    private string _imagePath = string.Empty;
    private readonly ILogger<ImageListController> _logger;
    public ImageListController(ILogger<ImageListController> logger,
    IConfiguration configuration)
    {
    _logger = logger;
    _imagePath = configuration["ImagePath"] ?? String.Empty;
    }

    [HttpGet("listImages")]
    public IActionResult ListImages()
    {
    List<Uri> images = new List<Uri>();
    if(Directory.Exists(_imagePath))
    {
    string [] fileEntries = Directory.GetFiles(_imagePath);
    foreach( var file in fileEntries)
    {
    var imageURI = new Uri(file, UriKind.RelativeOrAbsolute);
    images.Add(imageURI);
    }
    }
    return Ok(images);
    }

}
