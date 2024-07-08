using CloudinarySignedUploadWidgetDotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudinarySignedUploadWidgetDotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CloudinaryController : ControllerBase
{
  ICloudinaryService _cloudinaryService;

  public CloudinaryController(ICloudinaryService cloudinaryService)
  {
    _cloudinaryService = cloudinaryService;
  }

  [HttpGet("generate-signature")]
  public IActionResult GenerateSignature()
  {
    return Ok(_cloudinaryService.GenerateSignature());
  }
}