using ConfeitariaWeb.Models.Settings;
using ConfeitariaWeb.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace ConfeitariaWeb.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly StorageSettings _storageSettings;

        public ImageStorageService(HttpClient httpClient,
            IOptions<StorageSettings> storageOptions)
        {
            _httpClient = httpClient;
            _storageSettings = storageOptions.Value;
        }

        private const long MaxFileSize = 5 * 1024 * 1024;

        private static readonly string[] AllowedExtensions =
        [
            ".jpg",
            ".jpeg",
            ".png",
            ".webp"
        ];

        private static readonly string[] AllowedContentTypes =
        [
            "image/jpeg",
            "image/png",
            "image/webp"
        ];

        public async Task<string> UploadImageAsync(IFormFile arquivo, string pasta)
        {
            ArgumentNullException.ThrowIfNull(arquivo);

            if (arquivo.Length == 0)
            {
                throw new ArgumentException("Nenhum arquivo foi enviado.");
            }

            if (arquivo.Length > MaxFileSize)
            {
                throw new ArgumentException("A imagem não pode ser maior que 5 MB.");
            }

            var extensao = Path.GetExtension(arquivo.FileName).ToLowerInvariant();

            if (!AllowedExtensions.Contains(extensao))
            {
                throw new ArgumentException("Formato de imagem inválido.");
            }

            if (!AllowedContentTypes.Contains(arquivo.ContentType))
            {
                throw new ArgumentException("Tipo de arquivo inválido.");
            }

            var nomeArquivo = $"{pasta}/{Guid.NewGuid():N}{extensao}";

            using var stream = new MemoryStream();

            await arquivo.CopyToAsync(stream);

            stream.Position = 0;

            var url =$"{_storageSettings.ProjectUrl}/storage/v1/object/{_storageSettings.Bucket}/{nomeArquivo}";

            var content = new StreamContent(stream);

            content.Headers.ContentType =
                new MediaTypeHeaderValue(arquivo.ContentType);

            var request = new HttpRequestMessage(HttpMethod.Put, url);

            request.Headers.Add("apikey", _storageSettings.ApiKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _storageSettings.ApiKey);

            request.Content = content;

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException($"Erro ao enviar imagem: {erro}");
            }

            return $"{_storageSettings.ProjectUrl}/storage/v1/object/public/{_storageSettings.Bucket}/{nomeArquivo}";
        }

        public async Task DeleteImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return;
            }

            var prefix =
                $"{_storageSettings.ProjectUrl}/storage/v1/object/public/{_storageSettings.Bucket}/";

            var caminhoArquivo = imageUrl.Replace(prefix, "");

            var url =
                $"{_storageSettings.ProjectUrl}/storage/v1/object/{_storageSettings.Bucket}/{caminhoArquivo}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            request.Headers.Add("apikey", _storageSettings.ApiKey);

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _storageSettings.ApiKey);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new InvalidOperationException(
                    $"Erro ao excluir imagem: {erro}");
            }
        }

    }
}