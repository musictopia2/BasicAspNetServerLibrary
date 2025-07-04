namespace BasicAspNetServerLibrary.UploadHelpers;
public class LocalFileSaver : IFileSaver
{
    private readonly IConfiguration _configuration = bb1.Configuration ?? throw new CustomBasicException("Needs IConfiguration Registered");
    async Task<string> IFileSaver.SaveAsync(FileSaveContext context)
    {
        string basePath = _configuration.GetUploadSavePath();
        // Sanitize filename or generate fallback
        string safeFileName = Path.GetFileName(context.OriginalFileName ?? Guid.NewGuid().ToString());

        string fullPath = Path.Combine(basePath, safeFileName);

        // Save the file stream to disk
        await using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await context.File.CopyToAsync(stream);

        return fullPath;
    }
}