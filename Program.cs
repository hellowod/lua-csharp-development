using System;

namespace CsharpLua
{
    class Program
    {
        private static string ScriptFile;

        static void Main(string[] args)
        {
            ILuaState L = new LuaState();
            L.L_OpenLibs();

            if(args.Length > 0) {
                ScriptFile = args[0];
            } else {
                throw new Exception("args is null");
            }

            ThreadStatus status = L.L_DoFile(ScriptFile);
            if (status != ThreadStatus.LUA_OK) {
                throw new Exception(L.ToString(-1));
            }
        }
    }
}
