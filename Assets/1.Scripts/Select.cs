using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Select : MonoBehaviour
{
    [SerializeField] private Image checkImage;
    [SerializeField] private Sprite checkSprite;
    bool isCheck;
    public void Check()
    {
        if (isCheck)
        {
            checkImage.color = new Vector4(0, 0, 0, 0);
            checkImage.sprite = null;
            isCheck = false;
        }
        else
        {
            checkImage.color = new Vector4(0, 1, 0, 1);
            checkImage.sprite = checkSprite;
            isCheck = true;
        }
    }
}