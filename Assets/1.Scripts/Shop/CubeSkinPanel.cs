using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSkinPanel : MonoBehaviour
{
    [SerializeField]
    private Button purchaseButton;
    [SerializeField]
    private Text skinNameText;
    [SerializeField]
    private Text skinPriceText;
    [SerializeField]
    private Image skinImage;
    [SerializeField]
    private Sprite[] cubeSkinSprites;

    private CubeSkin cubeSkin;
    public void SetValue(CubeSkin cubeSkin)
    {
        cubeSkin = this.cubeSkin;
        UpdateUI();
    }
    public void UpdateUI()
    {
        skinNameText.text = cubeSkin.name;
        skinPriceText.text = string.Format("{0}", cubeSkin.price);
        skinImage.sprite = cubeSkinSprites[cubeSkin.skinNumber];
    }
    public void OnClickPurchase()
    {
        if (cubeSkin.Locked) return;
        purchaseButton.enabled = false;
        cubeSkin.isPurchase = true;
    }
}
