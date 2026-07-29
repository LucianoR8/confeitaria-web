namespace ConfeitariaWeb.Services.Interfaces
{
    public interface IImageStorageService
    {
        Task<string> UploadImageAsync(IFormFile arquivo, string pasta);
        Task DeleteImageAsync(string imageUrl);
    }
}