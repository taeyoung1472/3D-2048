using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other);   
        CubeSpawner.instance.DestroyCube(other.gameObject.GetComponent<Cube>());
    }
}
