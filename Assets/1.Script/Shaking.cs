using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    Vector3 originalPos;
    [Header("Èçµé¸®´Â Èû")] [SerializeField] private float ShakeForce;
    public void Start()
    {
        originalPos = transform.position;
    }
    public void ShakeCamera(float force)
    {
        ShakeForce += force;
    }
    public void Update()
    {
        transform.position = Random.insideUnitSphere * ShakeForce + originalPos;
        if (ShakeForce <= 0)
        {
            transform.position = originalPos;
        }
        else
        {
            ShakeForce -= Time.deltaTime;
        }
    }
}
