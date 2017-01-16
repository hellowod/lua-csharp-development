using System;
using UniLua;

namespace CsharpLua
{
    class Program
    {
        public static string Script = "test.lua";

        static void Main(string[] args)
        {
            ILuaState lua = new LuaState();
            lua.L_OpenLibs();

            if(args.Length > 0) {
                Script = args[0];
            }

            ThreadStatus status = lua.L_DoFile(Script);
            if (status != ThreadStatus.LUA_OK) {
                throw new Exception(lua.ToString(-1));
            }
        }
    }
}
