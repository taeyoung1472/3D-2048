using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    Vector3 originalPos;
    private float ShakeForce;
    [SerializeField] private float strong;
    public void Start()
    {
        originalPos = transform.position;
    }
    public void ShakeCamera(float force)
    {
        ShakeForce += force * strong;
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif
    }
    public void Update()
    {
        Shaking();
    }
    void Shaking()
    {
        transform.position = Random.insideUnitSphere * ShakeForce + originalPos;
        if (ShakeForce <= 0)
        {
            transform.position = originalPos;
        }
        else
        {
            ShakeForce -= Time.deltaTime * strong;
        }
    }
}