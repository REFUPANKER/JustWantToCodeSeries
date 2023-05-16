public class InputNull : ExceptionsTemplate
{
    public override string Description
    {
        get => @"Input is not existing or values missing";
        set => base.Description = value;
    }
}