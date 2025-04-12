using System.Text;

public static class LogHelper
{
    private static readonly string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "error-log.txt");

    public static void LogToFile(string message)
    {
        try
        {
            var logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            var logEntry = new StringBuilder();
            logEntry.AppendLine("========== HATA ==========");
            logEntry.AppendLine($"Zaman: {DateTime.Now}");
            logEntry.AppendLine($"Mesaj: {message}");
            logEntry.AppendLine("========== SON ==========\n");

            File.AppendAllText(logFilePath, logEntry.ToString());
        }
        catch
        {
            // Dosya erişim hatası vs. olursa sessiz geç
        }
    }
}
