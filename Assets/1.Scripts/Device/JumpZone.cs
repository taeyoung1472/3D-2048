using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    [SerializeField]
    private float force = 5f;


    private void OnCollisionEnter(Collision other) {
        IJumpable jumpable = other.gameObject.GetComponent<IJumpable>();

        if(jumpable == null)return;
        jumpable.Jump(this,force);
    }
}
