using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GoogleSheetManager googleSheetManager;
    void Start()
    {
        googleSheetManager.Call("Find",0);
    }
    void Update()
    {
        
    }
}
