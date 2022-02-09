using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner instance;

    Queue<Cube> cubesQueue = new Queue<Cube>();
    [SerializeField] private int cubesQueueCapacity = 20;

    [HideInInspector] public int maxCubeNumber;//4096
    [SerializeField] private GameObject cubePrefabs;
    [SerializeField] private Color[] cubeColors;
    [SerializeField] private TextMesh nextNumberText;
    [SerializeField] private int[] cubeNumberTemp;
    private int maxPower = 12;
    private Vector3 defaultSpawnPos;

    public int cubeMaxNumber = 2;

    private void Awake()
    {
        instance = this;
        maxCubeNumber = (int)Mathf.Pow(2, maxPower);
        defaultSpawnPos = transform.position;
        InitializeCubeQueue();
    }
    void InitializeCubeQueue()
    {
        for (int i = 0; i < cubesQueueCapacity; i++)
        {
            AddCubeToQueue();
        }
    }
    void AddCubeToQueue()
    {
        Cube cube = Instantiate(cubePrefabs, defaultSpawnPos, Quaternion.identity, transform).GetComponent<Cube>();
        cube.gameObject.SetActive(false);
        cube.isMainCube = false;
        cubesQueue.Enqueue(cube);
    }
    public Cube Spawn(int number, Vector3 position)
    {
        if (cubesQueue.Count == 0)
        {
            AddCubeToQueue();
        }
        if(number == 0)
        {
            cubeNumberTemp[0] = cubeNumberTemp[1];
            number = cubeNumberTemp[0];
            GenerateRandomNumber();
            nextNumberText.text = string.Format("NextCube  : {0}", cubeNumberTemp[1].ToString());
        }
        Cube cube = cubesQueue.Dequeue();
        cube.transform.position = position;
        cube.SetNumber(number);
        cube.SetColor(GetColor(number));
        cube.gameObject.SetActive(true);
        return cube;
    }
    public Cube SpawnRandom()
    {
        GameManager.Instance.IsCubeSpawn = true;
        return Spawn(0, defaultSpawnPos);
    }
    public void GenerateRandomNumber()
    {
        cubeNumberTemp[1] = (int)Mathf.Pow(2, Random.Range(1, cubeMaxNumber));
    }
    public void PlusCubeMaxNumber()
    {
        if (cubeMaxNumber >= 7)
        {
            return;
        }
        cubeMaxNumber++;
    }
    public Color GetColor(int number)
    {
        return cubeColors[(int)(Mathf.Log(number) / Mathf.Log(2)) - 1];
    }
    public void DestroyCube(Cube cube)
    {
        cube.GetComponent<CubeCollision>().DestroyCubeCollision();
        cube.cubeRigidbody.velocity = Vector3.zero;
        cube.cubeRigidbody.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.isMainCube = false;
        cube.gameObject.SetActive(false);
        cubesQueue.Enqueue(cube);
    }
}