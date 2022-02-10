using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TouchSlider touchSlider;
    [SerializeField] private Cube mainCube;
    [SerializeField] float cubeMaxPosX;
    [SerializeField] private float moveSpeed;
    public AudioSource audio;

    private Vector3 cubePos;
    bool isPointerDown;
    bool isCube = true;

    void Start()
    {
        SpawnCube();
        touchSlider.OnPointerUpEvent += OnPointerUp;
        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
    }
    void Update()
    {
        if (isPointerDown)
        {
            mainCube.transform.position = Vector3.Lerp(mainCube.transform.position, cubePos, moveSpeed * Time.deltaTime);
        }
    }
    private void SpawnCube()
    {
        mainCube = CubeSpawner.instance.SpawnRandom();
        mainCube.isMainCube = true;
        cubePos = mainCube.transform.position;
    }
    private void SpawnNewCube()
    {
        //mainCube.isMainCube = false;
        isCube = true;
        SpawnCube();
    }
    private void OnPointerUp()
    {
        if (isPointerDown && isCube)
        {
            isPointerDown = false;
            audio.Play();
            mainCube.cubeRigidbody.AddForce(Vector3.forward * 20f, ForceMode.Impulse);
            GameManager.Instance.AddScroe(mainCube.cubeNumber);
            isCube = false;
            mainCube.isMainCube = false;
            Invoke("SpawnNewCube", 0.3f);
        }
    }
    private void OnPointerDown()
    {
        isPointerDown = true;
    }
    private void OnPointerDrag(float xMove)
    {
        if (isPointerDown)
        {
            cubePos = mainCube.transform.position;
            cubePos.x = xMove * cubeMaxPosX;
        }
    }
    private void OnDestroy()
    {
        touchSlider.OnPointerUpEvent -= OnPointerUp;
        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerDragEvent -= OnPointerDrag;
    }
}
