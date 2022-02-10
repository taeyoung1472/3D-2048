using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveFoothole : MonoBehaviour
{
    [SerializeField]
    private LayerMask obstacleLayer;
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private bool isLeft;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        rb.velocity = (isLeft) ? transform.right * -1f : transform.right * speed;
        //transform.Translate(((isLeft) ? transform.right * -1f : transform.right) * speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if ((1 << other.gameObject.layer & obstacleLayer) > 0)
        {
            isLeft = !isLeft;
        }
    }

}
