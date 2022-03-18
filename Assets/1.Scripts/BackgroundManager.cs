using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float[] yPos;
    [SerializeField] private BackGroundElements[] element;
    [SerializeField] private int[] scoreTier;
    float tempY;
    [SerializeField] int backgroundTier;
    [SerializeField] Color[] backgroundColors;
    public void CheckTier(int _score)
    {
        if (backgroundTier < scoreTier.Length)
        {
            if (scoreTier[backgroundTier] < _score)
            {
                backgroundTier++;
            }
        }
    }
    void Start()
    {
        StartCoroutine(SpawnElements());
    }
    void Update()
    {
        tempY = Mathf.Lerp(tempY, yPos[backgroundTier], Time.deltaTime);
        MainCam.backgroundColor = Color.Lerp(MainCam.backgroundColor, backgroundColors[backgroundTier], Time.deltaTime);
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
