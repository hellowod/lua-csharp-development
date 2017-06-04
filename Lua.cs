using System;

/***
 * Lua.cs
 * 
 * @author abaojin
 */
namespace LuaCsharp
{
    /// <summary>
    /// lua 启动程序入口，目前可以直接传入lua文件的路径
    /// </summary>
    public class Lua
    {
        private static string ScriptFile;

        static void Main(string[] args)
        {
            // 初始化lua状态机
            ILuaState lstate = new LuaState();
            // 加载lua库
            lstate.L_OpenLibs();

            if(args.Length > 0) {
                ScriptFile = args[0];
            } else {
                throw new Exception("args is null");
            }

            // 执行lua脚本
            ThreadStatus status = lstate.L_DoFile(ScriptFile);
            if (status != ThreadStatus.LUA_OK) {
                throw new Exception(lstate.ToString(-1));
            }
        }
    }
}
