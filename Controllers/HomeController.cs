using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CloudinarySignedUploadWidgetDotnet.Models;
using CloudinarySignedUploadWidgetDotnet.Services;

namespace CloudinarySignedUploadWidgetDotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICloudinaryService _cloudinaryService;

    public HomeController(ILogger<HomeController> logger, ICloudinaryService cloudinaryService)
    {
        _logger = logger;
        _cloudinaryService = cloudinaryService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public async Task<string> DeleteImage(string publicId)
    {
        if (string.IsNullOrWhiteSpace(publicId))
        {
            return "PublicId is required!";
        }
        if (await _cloudinaryService.TryDeleteImageAsync(publicId))
        {
            return $"Delete image {publicId} successful!";
        }
        else
        {
            return "Delete failed!";
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
