using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    [SerializeField] private ParticleSystem cubeExplosionFX;

    ParticleSystem.MainModule cubeExplosionFM;

    public static FX Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cubeExplosionFM = cubeExplosionFX.main;
    }
    public void PlayCubeExplosionFX(Vector3 position, Color color)
    {
        cubeExplosionFM.startColor = new ParticleSystem.MinMaxGradient(new Color(color.r,color.g,color.b,255f));
        cubeExplosionFX.transform.position = position;
        cubeExplosionFX.Play();
    }
}
