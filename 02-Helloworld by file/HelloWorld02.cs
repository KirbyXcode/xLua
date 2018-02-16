using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public class HelloWorld02 : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //TextAsset ta = Resources.Load<TextAsset>("helloworld.lua"); //  helloworld.lua.txt

        LuaEnv env = new LuaEnv();
        //env.DoString(ta.text);

        env.DoString("require 'helloworld'");// helloworld.lua.txt
        env.Dispose();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
