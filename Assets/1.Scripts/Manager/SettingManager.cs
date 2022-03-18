using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private Slider masterSoundSlider;
    [SerializeField] private Slider BackGroundSoundSlider;
    [SerializeField] private Slider effectSoundSlider;
    [SerializeField] private Button zingleButtonTrue, zingleButtonFalse;
    [SerializeField] private GameObject settingPannel;
    private void Start()
    {
        if (GameManager.Instance.UserInfo.isZingle)
        {
            zingleButtonTrue.image.color = Color.white;
            zingleButtonFalse.image.color = Color.gray;
        }
        else
        {
            zingleButtonTrue.image.color = Color.gray;
            zingleButtonFalse.image.color = Color.white;
        }
    }
    public void ShowSettingPanel(bool _bool)
    {
        settingPannel.SetActive(_bool);
    }
    public void ZingleSet()
    {
        if (GameManager.Instance.UserInfo.isZingle)
        {
            zingleButtonTrue.image.color = Color.white;
            zingleButtonFalse.image.color = Color.gray;
        }
        else
        {
            zingleButtonTrue.image.color = Color.gray;
            zingleButtonFalse.image.color = Color.white;
        }
    }
}