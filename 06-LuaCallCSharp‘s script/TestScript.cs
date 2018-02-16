using UnityEngine;
using XLua;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        LuaEnv lua = new LuaEnv();

        lua.DoString("require 'LuaCallCSharp1'");

        lua.Dispose();
    }

    public void Debuger()
    {
        print("CSharp Function Invoked by Lua");
    }
}

