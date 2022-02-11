using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModSpawner : MonoBehaviour
{
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.json";


    [SerializeField]
    private GameObject iceGround;
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject jumpZone;
    [SerializeField]
    private GameObject meteor;


    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
        ModVO vo = JsonUtility.FromJson<ModVO>(json);

        for (int i = 0; i < vo.modString.Count; i++)
        {
            switch (vo.modString[i])
            {
                case "Ice":
                    ground.SetActive(false);
                    iceGround.SetActive(true);
                    break;
                case "JumpZone":
                    Instantiate(jumpZone);
                    break;
                case "Meteor":
                    Instantiate(meteor);
                    break;
                default: break;
            }
        }
    }
}
