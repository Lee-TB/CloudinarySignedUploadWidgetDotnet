## Run from command line

Set Cloudinary account settings using one of the following:

- in [appsettings.Development.json](appsettings.Development.json), `CloudinarySettings` section;

- or by using app secrets (see [docs for more details](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0):

  ```
  dotnet user-secrets set "CloudinarySettings:CloudName" "your_value_here"
  dotnet user-secrets set "CloudinarySettings:ApiKey" "your_value_here"
  dotnet user-secrets set "CloudinarySettings:ApiSecret" "your_value_here"
  dotnet user-secrets set "CloudinarySettings:UploadPreset" "your_value_here"
  ```
