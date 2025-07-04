namespace BasicAspNetServerLibrary.UploadHelpers;
public record FileSaveContext(IFormFile File, string PropertyName, string OriginalFileName);
