using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CubeCollision : MonoBehaviour
{
    Cube cube;
    private void Awake()
    {
        cube = GetComponent<Cube>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Cube otherCube = collision.gameObject.GetComponent<Cube>();
        if (otherCube != null && cube.cubeID > otherCube.cubeID)
        {
            if (cube.cubeNumber == otherCube.cubeNumber)
            {
                Vector3 contactPoint = collision.contacts[0].point;
                if (otherCube.cubeNumber <= CubeSpawner.instance.maxCubeNumber)
                {
                    Cube newCube = CubeSpawner.instance.Spawn(cube.cubeNumber * 2, contactPoint + Vector3.up * 1.5f);
                    float pushForce = 2.5f;
                    newCube.cubeRigidbody.AddForce(new Vector3(0, 0.3f, 1f) * pushForce, ForceMode.Impulse);

                    float randomValue = Random.Range(-20f, 20f);
                    Vector3 randomDir = Vector3.one * randomValue;
                    newCube.cubeRigidbody.AddTorque(randomDir);
                    newCube.audio.Play();
                    if ((Mathf.Log(cube.cubeNumber) / Mathf.Log(2)) >= CubeSpawner.instance.cubeMaxNumber + 1)
                    {
                        CubeSpawner.instance.PlusCubeMaxNumber();
                    }
                    GameManager.Instance.shakeManager.ShakeCamera(0.1f);
                    //Debug.Log( " Log : " +(Mathf.Log(cube.cubeNumber) / Mathf.Log(2)));
                    //Debug.Log( "cube : " +CubeSpawner.instance.cubeMaxNumber);
                }
                GameManager.Instance.AddScroe(cube.cubeNumber * 2);
                Collider[] surroundedCubes = Physics.OverlapSphere(transform.position, 2f);
                float explosionForce = 500f;
                float explosionRadius = 1.3f;
                foreach (Collider coll in surroundedCubes)
                {
                    if (coll.attachedRigidbody != null)
                    {
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                    }
                }

                FX.Instance.PlayCubeExplosionFX(contactPoint, cube.cubeColor);

                CubeSpawner.instance.DestroyCube(cube);
                CubeSpawner.instance.DestroyCube(otherCube);
            }
        }
        else
        {
            if (!cube.isMainCube && cube.cubeRigidbody.velocity.magnitude > 1f)
            {
                cube.audio2.Play();
            }
        }
    }
}
