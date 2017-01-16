using System;
using CsharpLua;

namespace CsharpLua
{
    class Program
    {
        private static string ScriptFile;

        static void Main(string[] args)
        {
            ILuaState lua = new LuaState();
            lua.L_OpenLibs();

            if(args.Length > 0) {
                ScriptFile = args[0];
            } else {
                throw new Exception("args is null");
            }

            ThreadStatus status = lua.L_DoFile(ScriptFile);
            if (status != ThreadStatus.LUA_OK) {
                throw new Exception(lua.ToString(-1));
            }
        }
    }
}
