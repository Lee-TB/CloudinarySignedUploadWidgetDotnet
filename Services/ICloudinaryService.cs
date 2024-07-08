using CloudinarySignedUploadWidgetDotnet.Models;

namespace CloudinarySignedUploadWidgetDotnet.Services;

public interface ICloudinaryService
{
    public SignatureResponse GenerateSignature();
}