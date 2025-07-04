namespace BasicAspNetServerLibrary.UploadHelpers;
public interface IFileSaver
{
    /// <summary>
    /// returns what a person using this would save as.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    Task<string> SaveAsync(FileSaveContext context);
}