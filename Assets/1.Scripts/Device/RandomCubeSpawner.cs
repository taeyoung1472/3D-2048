using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnDuration = 3f;

    [SerializeField]
    private Transform maxPos;
    [SerializeField]
    private Transform minPos;

    private void Start() {
        StartCoroutine(SpawnRandomCube());
    }

    private IEnumerator SpawnRandomCube(){
        while(true){
            Cube cube = CubeSpawner.instance.SpawnRandom();
            int random = (int)Mathf.Pow(2, Random.Range(1, CubeSpawner.instance.cubeMaxNumber));
            cube.SetNumber(random);
            cube.SetColor(CubeSpawner.instance.GetColor(random));
            cube.transform.position = new Vector3(Random.Range(minPos.position.x, maxPos.position.x) , transform.position.y , Random.Range(minPos.position.z, maxPos.position.z));
            yield return new WaitForSeconds(spawnDuration);
        }
    }
}
