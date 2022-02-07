using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField]
    private GameObject[] blocks;

    [SerializeField]
    private float[] zPoses;
    [SerializeField]
    private float firstPos;

    [ContextMenu("블럭 소환")]
    private void SummonBlocks()
    {

        // int i = 0;
        // int xCount = 0;
        // for (int j = 0; j < blocks.Length; j++)
        // {

        //     if (xCount == 4)
        //     {
        //         i++;
        //         xCount = 0;
        //     }
        //     blocks[j].transform.localPosition = new Vector3(firstXPos + xCount * 2, 0f, zPoses[i]);
        //     xCount++;
        // }
        for (int i = 1; i <= blocks.Length; i++){
            blocks[i].transform.localPosition = new Vector3(-12f , 0f , firstPos - (i*2f));
        }
    }
    [ContextMenu("블럭 리셋")]
    private void ResetBlocks(){
        for (int i = 0; i < blocks.Length; i++){
            blocks[i].transform.localPosition = new Vector3(10, 0f, 0f);
        }
    }
}
