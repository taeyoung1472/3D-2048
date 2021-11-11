using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource click;
    public void Click()
    {
        click.Play();
    }
}