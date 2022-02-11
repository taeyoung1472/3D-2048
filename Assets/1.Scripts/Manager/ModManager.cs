using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ModManager : MonoSingleton<ModManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.json";

    // public List<string> modString = new List<string>();

    //private StringBuilder stringBuilder = new StringBuilder();

    public static int mods;

    public void SetMode(){
        PlayerPrefs.SetInt("MOD", mods);
    }
    // public static bool isJumpzone;
    // public static bool isMeteor;

    // private void Awake()
    // {
    //     SAVE_PATH = Application.persistentDataPath + "/Save";
    //     if (!Directory.Exists(SAVE_PATH))
    //     {
    //         Directory.CreateDirectory(SAVE_PATH);
    //     }
    // }
    // public void SaveToJson()
    // {
    //     if (SAVE_PATH == "") SAVE_PATH = Application.persistentDataPath + "/Save";
    //     for (int i = 0; i < modString.Count; i++){
    //         stringBuilder.Append(modString[i]);
    //     }
    //     Debug.Log(JsonUtility.ToJson(stringBuilder.ToString(), true));
    //     File.WriteAllText($"{SAVE_PATH} {SAVE_FILENAME}", JsonUtility.ToJson(stringBuilder.ToString(), true), System.Text.Encoding.UTF8);
    // }
}
