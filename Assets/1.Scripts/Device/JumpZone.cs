using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    [SerializeField]
    private float force = 5f;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private AudioSource audioSource;

    private void OnCollisionEnter(Collision other) {
        IJumpable jumpable = other.gameObject.GetComponent<IJumpable>();

        if(jumpable == null)return;
        audioSource.PlayOneShot(audioClip);
        jumpable.Jump(this,force, transform.up);
    }
}
