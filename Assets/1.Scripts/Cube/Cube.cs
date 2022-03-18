using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Cube : MonoBehaviour
{
    public AudioSource cubeAudio;
    public AudioSource audio2;
    static int staticID = 0;
    [HideInInspector] public int cubeID;

    [SerializeField] private TMP_Text[] numberText;
    [HideInInspector] public int cubeNumber;
    [HideInInspector] public Color cubeColor;
    [HideInInspector] public Rigidbody cubeRigidbody;
    [HideInInspector] public bool isMainCube;
    private MeshRenderer cubeMeshRenderer;
    private void Awake()
    {
        cubeID = staticID++;
        cubeRigidbody = GetComponent<Rigidbody>();
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color)
    {
        cubeColor = color;
        cubeMeshRenderer.material.color = cubeColor;
    }

    public void SetNumber(int number)
    {
        cubeNumber = number;
        for (int i = 0; i < 6; i++)
        {
            numberText[i].text = cubeNumber.ToString();
        }
    }

}
