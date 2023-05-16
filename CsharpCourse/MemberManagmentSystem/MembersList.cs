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
            if (members[i].Name==name)
            {
                return members[i];
            }
        }
        return null;
    }
    #endregion
    public void AddMember(Member member)
    {
        Member[] newMembers = new Member[members.Length + 1];
        for (int i = 0; i < this.members.Length; i++)
        {
            newMembers[i] = members[i];
        }
        newMembers[newMembers.Length - 1] = member;
        members = newMembers;
    }
    public void RemoveMember(Member member)
    {
        if (Contains(member))
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
        LogChanges("Listing Members");
        foreach (var item in members)
        {
            cwl(item.Name);
        }
    }
}