using System;

namespace UniLua.Tools
{
	public class ULDebug
	{
		public static System.Action<object> Log = NoAction;
		public static System.Action<object> LogError = NoAction;

		private static void NoAction(object msg) { }

		static ULDebug()
		{
            Log = LogMessage;
            LogError = ErrorMessage;
        }

        private static void LogMessage(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void ErrorMessage(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}

