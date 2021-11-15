using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer = null;
    public AudioSource click;
    public void Click()
    {
        click.Play();
    }

    public void ChangeBGMVolume(float volume){
        if(volume <= -30f){
            audioMixer.SetFloat("BGM" , -80f);
        }
        else{
            audioMixer.SetFloat("BGM" , volume);
        }
    }
    public void ChangeMasterVolume(float volume){
        Debug.Log(volume);
        if(volume <= -30){
            audioMixer.SetFloat("Master", -80f);
        }
        else{
            audioMixer.SetFloat("Master", volume);
        }
    }
    public void ChangeSFXVolume(float volume){
        if(volume <= -30){
            audioMixer.SetFloat("SFX", -80f);
        }
        else{
            audioMixer.SetFloat("SFX", volume);
        }
    }
}