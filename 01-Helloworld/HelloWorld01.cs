using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloWorld01 : MonoBehaviour {

    private LuaEnv luaenv;
    // Use this for initialization
    void Start () {

        luaenv = new LuaEnv();

        //luaenv.DoString("print('Hello world!')"); 
        luaenv.DoString(" CS.UnityEngine.Debug.Log('Hello world') ");

        //luaenv.Dispose();

	}

    private void OnDestroy()
    {
        luaenv.Dispose();
    }
}
