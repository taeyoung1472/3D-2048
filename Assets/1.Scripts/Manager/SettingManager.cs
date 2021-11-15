using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    int isZingle;
    [SerializeField] private Slider masterSoundSlider;
    [SerializeField] private Slider BackGroundSoundSlider;
    [SerializeField] private Slider effectSoundSlider;
    [SerializeField] private Button zingleBurron;
    [SerializeField] private GameObject settingPannel;
    public void Awake()
    {
        isZingle = PlayerPrefs.GetInt("Zingle",0);
    }
    private void Start()
    {
        if (isZingle == 0)
        {
            zingleBurron.image.color = Color.gray;
        }
        else
        {
            zingleBurron.image.color = Color.white;
        }
    }
    public void ShowSettingPanel(bool _bool)
    {
        settingPannel.SetActive(_bool);
    }
    public void ZingleSet()
    {
        if (isZingle == 1)
        {
            zingleBurron.image.color = Color.gray;
            isZingle = 0;
        }
        else
        {
            zingleBurron.image.color = Color.white;
            isZingle = 1;
        }
    }
}