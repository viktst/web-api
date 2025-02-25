namespace WebAPI;

class CodeFix
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\YourDirectoryPath";
        
        List<string> txtFiles = FileProcessor.GetTxtFiles(directoryPath);
        txtFiles.ForEach(file => FileProcessor.AppendTxtToFile(file, "ASPEKT"));
    }
}

public static class FileProcessor
{
    public static List<string> GetTxtFiles(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath, "*.txt").ToList();

        var subdirectoryFiles = Directory.GetDirectories(directoryPath)
                                         .SelectMany(GetTxtFiles);

        files.AddRange(subdirectoryFiles);
        return files;
    }

    public static void AppendTxtToFile(string filePath, string textToAppend)
    {
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(textToAppend);
        }
    }
}