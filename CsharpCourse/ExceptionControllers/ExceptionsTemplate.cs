public class ExceptionsTemplate : ConsoleFastMethods
{
    public override string Message => this.Description;
    private string eName = "";
    public virtual string Name
    {
        get
        {
            return eName;
        }
        set
        {
            LogChanges($"Name changed from {this.Name} to {value}");
            this.eName = value;
        }
    }
    private string excpDescription = "";
    public virtual string Description
    {
        get { return excpDescription; }
        set
        {
            LogChanges($"|{this.Name}>Description changed");
            excpDescription = value;
        }
    }

    public ExceptionsTemplate()
    {
        this.eName = this.GetType().Name;
    }
    public virtual void Throw()
    {
        WriteLineColorized(ConsoleColor.Red,
        $"Exception thrown from {this.Name}\n{this.Description}");
        throw this;
    }
}