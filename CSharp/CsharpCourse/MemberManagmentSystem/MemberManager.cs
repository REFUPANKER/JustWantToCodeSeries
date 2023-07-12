public class MemberManager : ConsoleFastMethods
{
    private MembersList members = new MembersList();

    #region Events
    public delegate void MemberEvents();
    public event MemberEvents? OnMemberAdded;
    public event MemberEvents? OnMemberRemoved;
    #endregion

    ///<summary>
    /// member syntax : name id value
    /// spaces not allowed
    ///</summary>
    public void AddMember(Member member)
    {
        members.AddMember(member, () =>
        {
            OnMemberAdded?.Invoke();
        });
        WriteLineColorized(ConsoleColor.Yellow, "Press enter to continue");
        Console.ReadKey();
    }

    ///<summary>
    /// requires member data to remove from list<br></br>
    /// recommended : 
    ///<see cref="MemberManager.GetMemberFromID(bool)"></see>
    ///</summary>
    public void RemoveMember(Member member)
    {
        members.RemoveMember(member, () =>
        {
            OnMemberRemoved?.Invoke();
        });
        WriteLineColorized(ConsoleColor.Yellow, "Press enter to continue");
        Console.ReadKey();
    }

    public void ListMembers()
    {
        Console.Clear();
        members.ShowList();
        WriteLineColorized(ConsoleColor.Yellow, "Press enter to continue");
        Console.ReadKey();
    }

    ///<summary>
    /// Gets member data from input<br/>
    /// returns <see cref="Member?"></see><br></br>
    /// <u>return value might be null</u>
    ///</summary>
    public Member? GetMemberVariablesFromInput()
    {
        Member? nmem = new Member();
        WriteLineColorized(ConsoleColor.Yellow, "[!]Creating member locks reading input while getting values");
        WriteColorized(ConsoleColor.Green, "Id :");
        if (TryToDo(() =>
        {
            nmem.ID = Convert.ToInt32(Console.ReadLine());
            while (nmem.ID < 1)
            {
                WriteColorized(ConsoleColor.Red, "Id must be higher than 0 :");
                nmem.ID = Convert.ToInt32(Console.ReadLine());
            }
        }) != null)
        {
            WriteLineColorized(ConsoleColor.Red, "Exception thrown at get/set memberID");
            return null;
        }
        else
        {
            WriteColorized(ConsoleColor.Green, "Name :");
            nmem.Name = "" + Console.ReadLine();
            while (string.IsNullOrEmpty(nmem.Name) == true)
            {
                WriteColorized(ConsoleColor.DarkRed, "[!] Name :");
                nmem.Name = "" + Console.ReadLine();
            }

            WriteColorized(ConsoleColor.Green, "Surame :");
            nmem.Surname = "" + Console.ReadLine();
            while (string.IsNullOrEmpty(nmem.Surname) == true)
            {
                WriteColorized(ConsoleColor.DarkRed, "[!] Surname :");
                nmem.Surname = "" + Console.ReadLine();
            }
        }
        return nmem;
    }

    public Member? GetMemberFromID(bool showMember = false)
    {
        Member? foundMember = null;
        WriteLineColorized(ConsoleColor.Yellow, "[!]Getting Member from id locks reading input");
        int entry = -1;
        if (TryToDo(() =>
        {
            WriteColorized(ConsoleColor.Green, "Member ID: ");
            entry = Convert.ToInt32(Console.ReadLine());
            foreach (var item in members.GetMembers())
            {
                if (item.ID == entry)
                {
                    foundMember = item;
                }
            }
        }) != null)
        {
            WriteLineColorized(ConsoleColor.Red, "Exception thrown at get member with ID");
        }
        if (showMember && foundMember != null)
        {
            foundMember.ListData(true);
            WriteLineColorized(ConsoleColor.Yellow, "Press enter to continue");
            Console.ReadKey();
        }
        if (foundMember == null)
        {
            WriteLineColorized(ConsoleColor.Red, $"Cant find member with this id : {entry}");
            WriteLineColorized(ConsoleColor.Yellow, "Press enter to continue");
            Console.ReadKey();
        }
        return foundMember;
    }

}