using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    [SerializeField]
    private TextMesh tm;
    public void OnEnable()
    {
        tm.color = new Vector4(tm.color.r, tm.color.g, tm.color.b, 1);
        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeOut()
    {
        float alpha = 1;
        while(tm.color.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            alpha -= 0.1f;
            tm.color = new Vector4(tm.color.r, tm.color.g, tm.color.b, alpha);
        }
        Destroy(gameObject);
    }
    public void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}