using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
            {"source", "uw"}, // uw = upload widget
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

    public async Task<bool> TryDeleteImageAsync(string publicId)
    {
        var result = await _cloudinary.DeleteResourcesAsync(ResourceType.Image, [publicId]);
        System.Console.WriteLine(result.Deleted);
        return result.StatusCode == HttpStatusCode.OK;
    }
}