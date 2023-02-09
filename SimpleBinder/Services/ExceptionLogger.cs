namespace SimpleBinder;

public static class ExceptionLogger
{
    public static void LogExceptionToFile(string exceptionMessage, string exceptionStackTrace, string exceptionSource)
    {
        var pathToLog = $@"{Application.StartupPath}\logs";
        if (!Directory.Exists(pathToLog))
        {
            Directory.CreateDirectory(pathToLog);
        }
        var allText =
            $"If something doesn't work, you can contact developer via https://github.com/Andruxxa7 in SimpleBinder repo\n" +
            $"Exception source is {exceptionSource}\n" +
            $"Exception message: {exceptionMessage}\n" +
            $"Exception stack trace:\n {exceptionStackTrace}";
        File.WriteAllText(pathToLog + $@"\exceptionLog_{DateTime.Now:HH_mm_MM_dd_yyyy}.log", allText);
    }
}