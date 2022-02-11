using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ModManager : MonoSingleton<ModManager>
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.json";

    public List<string> modString{ get; private set; } = new List<string>();

    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
    }
    public void SaveToJson()
    {
        if (SAVE_PATH == "") SAVE_PATH = Application.dataPath + "/Save";
        string json = JsonUtility.ToJson(modString, true);
        File.WriteAllText($"{SAVE_PATH} {SAVE_FILENAME}", json, System.Text.Encoding.UTF8);
    }
}
