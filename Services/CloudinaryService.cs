using CloudinaryDotNet;
using CloudinarySignedUploadWidgetDotnet.Models;

namespace CloudinarySignedUploadWidgetDotnet.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly CloudinarySettings _cloudinarySettings;
    private readonly Cloudinary _cloudinary;
    public CloudinaryService(IConfiguration configuration)
    {
        _cloudinarySettings = configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();

        Account account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);
        _cloudinary = new Cloudinary(account);
    }

    public SignatureResponse GenerateSignature()
    {
        IDictionary<string, object> parameters = new SortedDictionary<string, object>()
        {
            {"timestamp", DateTimeOffset.UtcNow.ToUnixTimeSeconds()},
            {"source", "uw"},
            {"upload_preset", _cloudinarySettings.UploadPreset}
        };

        string signature = _cloudinary.Api.SignParameters(parameters);

        return new SignatureResponse()
        {
            Signature = signature,
            Timestamp = (long)parameters["timestamp"],
            CloudName = _cloudinarySettings.CloudName,
            ApiKey = _cloudinarySettings.ApiKey,
            UploadPreset = _cloudinarySettings.UploadPreset
        };
    }
}