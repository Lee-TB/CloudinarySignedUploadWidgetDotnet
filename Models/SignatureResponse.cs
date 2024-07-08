namespace CloudinarySignedUploadWidgetDotnet.Models;

public class SignatureResponse
{
    public string Signature { get; set; }
    public string CloudName { get; set; }
    public string ApiKey { get; set; }
    public long Timestamp { get; set; }
    public string UploadPreset { get; set; }
}