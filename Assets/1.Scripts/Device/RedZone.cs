using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RedZone : MonoBehaviour
{
    bool isTrigger = false;
    private void OnTriggerStay(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();
        if (cube != null)
        {
            if (!cube.isMainCube && cube.cubeRigidbody.velocity.magnitude < .1f)
            {
                if(GameManager.Instance.isOver == false && !isTrigger)
                {
                    isTrigger = true;
                    GameManager.Instance.GameOverPanel.SetActive(true);
                    GameManager.Instance.googleSheetManager.Call("Get",GameManager.Instance.score);
                }
            }
        }
    }
}