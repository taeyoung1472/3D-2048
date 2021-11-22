using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeSkinParent = null;

    private List<CubeSkinPanel> cubeSkinPanels = new List<CubeSkinPanel>();
    public void EquipSkin()
    {
        GameManager.Instance.UserInfo.gotCubeSkin.Sort();
        int index = 0;
        for (int i = 0; i < (int)CubeSkinState.LENGTH; i++)
        {
            if (i == (int)GameManager.Instance.UserInfo.skinState) continue;
            
            if (i == GameManager.Instance.UserInfo.gotCubeSkin[index])
            {
                cubeSkinPanels[index].OffisEquip();
            }
        }
    }
    #region 이벤트
    private void Start()
    {

    }
    #endregion
}
