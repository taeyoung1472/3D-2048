using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour
{
    [SerializeField] private Vector3 rotVec;
    [SerializeField] private Vector3 movVec;
    [SerializeField] private Vector2 limitXPos;
    [SerializeField] private float shakeForce = 0.02f;
    public void Set()
    {
        if (Random.Range(0, 2) == 0)
        {
            movVec.x *= -1;
        }
    }
    public void Update()
    {
        transform.Rotate(rotVec * Time.deltaTime);
        transform.Translate(movVec * Time.deltaTime);
        if(transform.position.x > limitXPos.y)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < limitXPos.x)
        {
            Destroy(gameObject);
        }
        transform.position += Random.insideUnitSphere * shakeForce;
    }
}