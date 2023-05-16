namespace CsharpCourse
{
    class Program : ConsoleFastMethods
    {
        static MemberManager? memberManager;
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                cwl("Application started\n");
                InitClasses();
                IntroOperations();
                ReadInputs();
            }
            catch (Exception excp)
            {
                WriteLineColorized(ConsoleColor.Red, StackTraceErrorLines(excp));
            }
            finally
            {
                cwl("\nApplication ended");
            }
        }

        static void InitClasses()
        {
            memberManager = new MemberManager();
        }

        static void ReadInputs()
        {
#pragma warning disable
            string input = "";
            while (input.StartsWith("exit") != true)
            {
                input = Console.ReadLine();
                CheckInput(input);
            }
        }

        static string[,] AvailableOperations = new string[,]{
        {"Add","adds member","Might throw error"},
        {"Get","gets member","Might return null"},
        {"Remove","removes member","Might throw error"},
        {"Contains","searchs member by id or name","returns true/false"},
        {"Exit","ends app","Not works in value set events"}
       };
        static void IntroOperations()
        {
            cwl("Available operations");
            for (int i = 0; i < AvailableOperations.GetLength(0); i++)
            {
                WriteLineColorized(ConsoleColor.Green, ">" + AvailableOperations[i, 0]);
                WriteLineColorized(ConsoleColor.White, "->" + AvailableOperations[i, 1]);
                WriteLineColorized(ConsoleColor.Yellow, "[!]" + AvailableOperations[i, 2]);
            }
        }

        ///<summary>
        /// requires
        ///<param name="input"><seealso cref="string">input</seealso></param>
        ///<br></br><value>Gets input and compares with possible selections</value>
        ///</summary>
        static void CheckInput(string input)
        {
            try
            {
                switch (input.ToLower())
                {
                    case "add":
                        memberManager.AddMember(memberManager.GetMemberVariablesFromInput());
                        break;
                }
            }
            catch { }
        }
    }
}