using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
using UnityEngine.Networking;

public class HotFixScript : MonoBehaviour
{
    public static Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

    private LuaEnv luaEnv;

    private string path;

    private void Awake()
    {
        luaEnv = new LuaEnv();

        LoadLua();

        ExecuteLua();
    }

    private void LoadLua()
    {
        path = Application.streamingAssetsPath + "/Lua/";

        luaEnv.AddLoader(CustomLoader);
    }

    private void ExecuteLua()
    {
        luaEnv.DoString("require'fish'");
    }

    private byte[] MyLoader(ref string fileName)
    {
        string relativePath = path + fileName + ".lua.txt";

        if (!File.Exists(relativePath)) return null;

        string luaContent = File.ReadAllText(relativePath);

        return Encoding.UTF8.GetBytes(luaContent);
    }

    private void OnDisable()
    {
        luaEnv.DoString("require'dispose'");
    }

    private void OnDestroy()
    {
        luaEnv.Dispose();
    }

    [LuaCallCSharp]
    public void LoadResource(string resName, string filePath)
    {
        StartCoroutine(LoadResourceCorotine(resName, filePath));

    }

    IEnumerator LoadResourceCorotine(string resName, string filePath)
    {
        UnityWebRequest request = UnityWebRequest.GetAssetBundle(@"http://localhost/AssetBundles/" + filePath);
        yield return request.SendWebRequest();
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject gameObject = ab.LoadAsset<GameObject>(resName);
        prefabDict.Add(resName, gameObject);
    }

    [LuaCallCSharp]
    public static GameObject GetGameObject(string goName)
    {
        return prefabDict[goName];
    }
}
