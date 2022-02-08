using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    int combo;
    public void ComboUpdate()
    {
        combo++;
    }
    public void ComboReset()
    {
        combo = 0;
    }
}