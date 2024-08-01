using CloudinarySignedUploadWidgetDotnet.Models;

namespace CloudinarySignedUploadWidgetDotnet.Services;

public interface ICloudinaryService
{
    public SignatureResponse GenerateSignature();
    public Task<bool> TryDeleteImageAsync(string publicId);
}