using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float[] yPos;
    [SerializeField] private BackGroundElements[] element;
    [SerializeField] private int[] scoreTier;
    float tempY;
    [SerializeField] int backgroundTier;
    [SerializeField] Color[] backgroundColors;
    [SerializeField] Camera camera;
    public void CheckTier(int _score)
    {
        if(scoreTier[backgroundTier] < _score)
        {
            backgroundTier++;
        }
    }
    void Start()
    {
        StartCoroutine(SpawnElements());
    }
    void Update()
    {
        tempY = Mathf.Lerp(tempY, yPos[backgroundTier], Time.deltaTime);
        camera.backgroundColor = Color.Lerp(camera.backgroundColor, backgroundColors[backgroundTier], Time.deltaTime);
        transform.position = new Vector3(20, tempY, 0);
    }
    IEnumerator SpawnElements()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f * UnityEngine.Random.Range(1f,2f));
            Instantiate(element[backgroundTier].elements[UnityEngine.Random.Range(0, element[backgroundTier].elements.Length)], transform);
        }
    }
}
[Serializable]
public class BackGroundElements {
    public GameObject[] elements;
}
