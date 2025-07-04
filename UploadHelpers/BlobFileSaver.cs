namespace BasicAspNetServerLibrary.UploadHelpers;
public class BlobFileSaver(IBlobStorageService _blobStorageService) : IFileSaver
{
    async Task<string> IFileSaver.SaveAsync(FileSaveContext context)
    {
        if (context.File == null)
        {
            throw new CustomBasicException("No File");
        }

        // Use property name + original filename (or customize as needed)
        var fileName = Path.GetFileName(context.OriginalFileName ?? $"{Guid.NewGuid()}");

        // Generate a blob name; could prefix with property or folder
        var blobName = $"{context.PropertyName}/{fileName}";

        // Open the uploaded file stream
        await using var stream = context.File.OpenReadStream();

        // Upload to blob storage
        await _blobStorageService.UploadAsync(blobName, stream);

        // Return the blobName or maybe URI, depending on what you want to store
        return blobName;
    }
}