using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float[] yPos;
    [SerializeField] private BackGroundElements[] element;
    float tempY;
    [SerializeField] int backgroundTier;
    void Start()
    {
        StartCoroutine(SpawnElements());
    }
    void Update()
    {
        tempY = Mathf.Lerp(tempY, yPos[backgroundTier], Time.deltaTime);
        transform.position = new Vector3(20, tempY, 0);
    }
    IEnumerator SpawnElements()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(element[backgroundTier].elements[UnityEngine.Random.Range(0, element[backgroundTier].elements.Length)], transform);
        }
    }
}
[Serializable]
public class BackGroundElements {
    public GameObject[] elements;
}
