private static async Task<List<string>> GetFolderLanguagesAsync(string directoryPath)
{
    // Check if the directory exists
    if (!Directory.Exists(directoryPath))
    {
        throw new DirectoryNotFoundException($"The directory at {directoryPath} does not exist.");
    }

    var languageList = new List<string>();
    try
    {
        // Get all file paths within the directory
        var fileEntries = Directory.GetFiles(directoryPath);

        foreach (var filePath in fileEntries)
        {
            // Extract the language from the file name or content
            var language = await ExtractLanguageFromFilePathAsync(filePath);
            if (!string.IsNullOrWhiteSpace(language) && !languageList.Contains(language))
            {
                languageList.Add(language);
            }
        }
    }
    catch (Exception ex)
    {
        // Log the exception (implementation depends on the logging framework used)
        LogException(ex);
        throw; // Re-throw the exception to handle it further up the call stack
    }

    return languageList;
}

// Dummy method to represent language extraction logic
private static async Task<string> ExtractLanguageFromFilePathAsync(string filePath)
{
    // Implement the actual logic to extract language from the file path or content
    // For example, parsing the file name or reading the file content to determine the language
    return await Task.FromResult("English"); // Placeholder return value
}

// Dummy method to represent exception logging
private static void LogException(Exception ex)
{
    // Implement the actual logging logic
    Console.WriteLine(ex.Message); // Placeholder logging
}
