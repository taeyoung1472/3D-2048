using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEffect : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 limitPos;
    void Update()
    {
        rect.position = new Vector3(rect.position.x + Time.deltaTime * speed, rect.position.y, rect.position.z);
        if (rect.position.x > limitPos.y)
        {
            rect.position = new Vector3(limitPos.x, rect.position.y, rect.position.z);
        }
    }
}
