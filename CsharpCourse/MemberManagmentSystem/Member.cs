public class Member : ConsoleFastMethods
{
#pragma warning disable
    public long ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public void ListData(bool addSeperaters = false)
    {
        if (addSeperaters)
        { WriteLineColorized(ConsoleColor.Green, CreateStringLine("=", 20)); }
        WriteLineColorized(ConsoleColor.Cyan,
        "ID :" + this.ID +
        "\nName :" + this.Name +
        "\nSurname :" + this.Surname
        );
        if (addSeperaters)
        { WriteLineColorized(ConsoleColor.Green, CreateStringLine("=", 20)); }
    }
}