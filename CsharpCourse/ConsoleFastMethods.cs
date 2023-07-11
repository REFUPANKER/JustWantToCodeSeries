public class ConsoleFastMethods : Exception
{
    public static void cwl(Object msg)
    {
        System.Console.WriteLine(msg);
    }
    public static void cw(Object msg)
    {
        System.Console.Write(msg);
    }
    public void LogChanges(object msg)
    {
        WriteLineColorized(ConsoleColor.Yellow,
        $"[{DateTime.Now.ToShortTimeString() + $":{DateTime.Now.Second}"}]Log From {this.GetType().Name}>" + msg);
    }
    static ConsoleColor previousColor;
    public static void WriteLineColorized(ConsoleColor color, object msg)
    {
        previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        System.Console.WriteLine(msg);
        Console.ForegroundColor = previousColor;
    }
    public static void WriteColorized(ConsoleColor color, object msg)
    {
        previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        System.Console.Write(msg);
        Console.ForegroundColor = previousColor;
    }
    public static string CreateStringLine(string chr, int length)
    {
        string res = "";
        for (int i = 0; i < length; i++)
        {
            res += chr;
        }
        return res;
    }
    public static string StackTraceErrorLines(Exception excp)
    {
        string result = "";
        cwl(excp);
        // TODO : get the error line
        return result;
    }
    public Exception? TryToDo(Action act)
    {
        try
        {
            act.Invoke();
        }
        catch (Exception excp)
        {
            return excp;
        }
        return null;
    }
    public static Exception? sTryToDo(Action act)
    {
        try
        {
            act.Invoke();
        }
        catch (Exception excp)
        {
            return excp;
        }
        return null;
    }
}
