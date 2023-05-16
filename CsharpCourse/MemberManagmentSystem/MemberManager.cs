public class MemberManager : ConsoleFastMethods
{
    MembersList members = new MembersList();

    ///<summary>
    /// member syntax : name id value
    /// spaces not allowed
    ///<summary>
    public void AddMember(Member member)
    {
        members.AddMember(member);
        LogChanges("Member added");
    }

    public Member GetMemberVariablesFromInput()
    {
        Member nmem = new Member();
        WriteLineColorized(ConsoleColor.Yellow, "[!]Creating member locks reading input while getting values");
        WriteColorized(ConsoleColor.Green, "Id :");
        if(TryToDo(() =>
        {
            nmem.ID = Convert.ToInt32(Console.ReadLine());
        })!=null){
            WriteLineColorized(ConsoleColor.Red,"Exception thrown at get/set memberID");
        }
        WriteColorized(ConsoleColor.Green, "Name :");
        nmem.Name = "" + Console.ReadLine();
        WriteColorized(ConsoleColor.Green, "Surname :");
        nmem.Surname = "" + Console.ReadLine();
        return nmem;
    }
}