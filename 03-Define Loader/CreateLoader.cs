using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
public class CreateLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaEnv env = new LuaEnv();

        env.AddLoader(MyLoader);

        env.DoString("require 'test007'");

        env.Dispose();
	}
	
    private byte[] MyLoader(ref string filePath)
    {
        //print(filePath);
        //string s = "print(123)";
        //print(Application.streamingAssetsPath);
        string absPath = Application.streamingAssetsPath + "/" + filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }

	// Update is called once per frame
	void Update () {
		
	}
}
