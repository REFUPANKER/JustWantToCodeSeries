namespace CsharpCourse
{
    class Program : ConsoleFastMethods
    {
        static MemberManager memberManager = new MemberManager();
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                cwl("Application started\n");
                SetEvents();
                CheckArgs(args);
                ReadInputs();
            }
            catch (Exception excp)
            {
                WriteLineColorized(ConsoleColor.Red, excp.StackTrace + "");
                Console.ReadKey();
            }
            finally
            {
                cwl("\nApplication ended");
            }
        }
        static void SetEvents()
        {
            memberManager.OnMemberAdded += MemberAdded;
            memberManager.OnMemberRemoved += MemberRemoved;
        }
        static void ReadInputs()
        {
#pragma warning disable
            string input = "";
            while (input.StartsWith("exit") != true)
            {
                Console.Clear();
                IntroOperations();
                cw(">");
                input = Console.ReadLine();
                CheckInputTarget(input.Replace(" ", ""));
            }
        }

        ///<summary>
        /// requires
        ///<param name="input"><seealso cref="string">input</seealso></param>
        ///<br></br><value>Gets input and compares with possible selections</value>
        ///</summary>
        static void CheckInputTarget(string input)
        {
            try
            {
                switch (input.ToLower())
                {
                    case "add":
                        memberManager.AddMember(memberManager.GetMemberVariablesFromInput());
                        break;
                    case "remove":
                        memberManager.RemoveMember(memberManager.GetMemberFromID());
                        break;
                    case "get":
                        memberManager.GetMemberFromID(true);
                        break;
                    case "list":
                        memberManager.ListMembers();
                        break;
                }
            }
            catch { }
        }

        static string[,] AvailableOperations = new string[,]{
        {"Add","adds member","Might throw error"},
        {"Get","gets member","Might return null"},
        {"Remove","removes member","Might throw error"},
        {"List","lists all members","requires members to list"},
        {"Exists","searchs member by id or name","returns true/false"},
        {"Exit","ends app","Not works in nested set events"}
       };
        static void IntroOperations()
        {
            WriteLineColorized(ConsoleColor.White, CreateStringLine("=", 10) + "Available operations" + CreateStringLine("=", 10));
            for (int i = 0; i < AvailableOperations.GetLength(0); i++)
            {
                WriteColorized(ConsoleColor.Green, ">" + AvailableOperations[i, 0]);
                WriteColorized(ConsoleColor.White, " : " + AvailableOperations[i, 1]);
                WriteLineColorized(ConsoleColor.Yellow, " [!] " + AvailableOperations[i, 2]);
            }
            WriteLineColorized(ConsoleColor.White, CreateStringLine("=", 40));
        }

        static void CheckArgs(string[] args)
        {
            if (args.Length > 0)
            {
                WriteLineColorized(ConsoleColor.DarkYellow, $"App started with {args.Length} arguments ");
                WriteLineColorized(ConsoleColor.Green, $"Searching action for argument : {args[0]} ");
                if (ActionArgMatches(args[0]))
                {
                    WriteLineColorized(ConsoleColor.Yellow, "Press enter to continue");
                    Console.ReadKey();
                    CheckInputTarget(args[0]);
                }
            }
        }
        static bool ActionArgMatches(string arg)
        {
            if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
            {
                WriteLineColorized(ConsoleColor.Red, "[-] argument not valid");
                return false;
            }
            bool result = false;
            if (sTryToDo(() =>
            {
                arg = arg.ToLower();
            }) != null)
            {
                WriteLineColorized(ConsoleColor.Red, "[-] act arg match argument type issue");
                return false;
            }
            for (int i = 0; i < AvailableOperations.GetLength(0); i++)
            {
                if (AvailableOperations[0, 0].ToLower() == arg)
                {
                    WriteLineColorized(ConsoleColor.Green, $"Argument matched action => {AvailableOperations[0, 0]}");
                    return true;
                }
            }
            return result;
        }
        #region Events

        public static void MemberAdded()
        {
            WriteLineColorized(ConsoleColor.White, "[!] Member added event called");
        }
        public static void MemberRemoved()
        {
            WriteLineColorized(ConsoleColor.White, "[!] Member remove event called");
        }

        #endregion
    }
}