using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skin
{
    public string name;
    public int skinNumber;
    public int price;
    public bool isPurchase;
    public bool Locked{
        get{
            return (GameManager.Instance.UserMoney > price) && isPurchase;
        }
    }
}
