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


    // private void Awake()
    // {
    //     SAVE_PATH = Application.persistentDataPath + "/Save";
    //     string json = File.ReadAllText($"{SAVE_PATH} {SAVE_FILENAME}");
    //     ModVO vo = JsonUtility.FromJson<ModVO>(json);
    //     Debug.Log(vo);
    //     Debug.Log(json);



    //     if (vo.isIce)
    //     {
    //         ground.SetActive(false);
    //         iceGround.SetActive(true);
    //     }
    //     if (vo.isJumpzone)
    //     {
    //         Instantiate(jumpZone);
    //     }
    //     if (vo.isMeteor)
    //     {
    //         Instantiate(meteor);
    //     }
    // }

    // private void Awake()
    // {
    //     int mod = PlayerPrefs.GetInt("MOD", 0);
    //     Debug.Log(mod);
    //     switch (mod)
    //     {
    //         case 1:
    //             ground.SetActive(false);
    //             iceGround.SetActive(true);
    //             break;
    //         case 2:
    //             Instantiate(jumpZone);
    //             break;
    //         case 3:
    //             Instantiate(meteor);
    //             break;
    //         case 4:
    //             ground.SetActive(false);
    //             iceGround.SetActive(true);
    //             Instantiate(meteor);
    //             break;
    //         case 5:
    //             Instantiate(jumpZone);
    //             Instantiate(meteor);
    //             break;
    //         case 6:
    //             ground.SetActive(false);
    //             iceGround.SetActive(true);
    //             Instantiate(meteor);
    //             Instantiate(jumpZone);
    //             break;
    //         default:
    //             break;
    //     }
    // }
}
