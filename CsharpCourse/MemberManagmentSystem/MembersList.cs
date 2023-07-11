public class MembersList : ConsoleFastMethods
{
    private Member[] members = new Member[] { };
    public Member[] GetMembers()
    {
        return members;
    }
    #region GetMember - Different Types
    public Member? GetMemberBy(int index)
    {
        if (index > members.Length)
        {
            return null;
        }
        else
        {
            return members[index];
        }
    }
    public Member? GetMemberBy(string name)
    {
        for (int i = 0; i < members.Length; i++)
        {
            if (members[i].Name == name)
            {
                return members[i];
            }
        }
        return null;
    }
    #endregion

    public void AddMember(Member member)
    {
        if (member == null)
        {
            WriteLineColorized(ConsoleColor.Red, "Member cant be null");
            return;
        }
        Member[] newMembers = new Member[members.Length + 1];
        for (int i = 0; i < this.members.Length; i++)
        {
            newMembers[i] = members[i];
        }
        newMembers[newMembers.Length - 1] = member;
        members = newMembers;
        
        LogChanges("Member added");
    }
    public void RemoveMember(Member member)
    {
        if (member != null && Contains(member))
        {
            Member[] newMembers = new Member[members.Length - 1];
            int ix = 0;
            for (int i = 0; i < this.members.Length; i++)
            {
                if (members[i] != member)
                {
                    newMembers[ix++] = members[i];
                }
            }
            members = newMembers;
            LogChanges("Member removed");
        }
        else
        {
            LogChanges("Cant remove item | not exists");
        }
    }
    public bool Contains(Member member)
    {
        bool result = false;
        foreach (var item in members)
        {
            if (item == member)
            {
                result = true;
                break;
            }
        }
        return result;
    }

    public void ShowList()
    {
        WriteLineColorized(ConsoleColor.Green, CreateStringLine("=", 10) + "Listing Members" + CreateStringLine("=", 10));
        for (int i = 0; i < members.Length; i++)
        {
            members[i].ListData(false);
            if (i + 1 < members.Length)
            {
                WriteLineColorized(ConsoleColor.Green, CreateStringLine("-", 20));
            }
        }
        WriteLineColorized(ConsoleColor.Green, CreateStringLine("=", 15));
    }
}