using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeSkin
{
    public string name;
    public int skinNumber;
    public int price;
    public bool isPurchase;
    public bool isEquip;
    public bool Locked{
        get{
            return (GameManager.Instance.UserInfo.money > price) && isPurchase;
        }
    }

}
