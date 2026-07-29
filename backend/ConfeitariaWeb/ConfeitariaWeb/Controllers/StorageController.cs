using ConfeitariaWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/storage")]
public class StorageController : ControllerBase
{
    private readonly IImageStorageService _storageService;

    public StorageController(IImageStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPost("upload")]
    public async Task<ActionResult> Upload(IFormFile arquivo)
    {
        var url = await _storageService.UploadImageAsync(
            arquivo,
            "products");

        return Ok(new { Url = url });
    }
}