using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private int page;
    public void NextPage()
    {
        pages[page].SetActive(false);
        page++;
        pages[page].SetActive(true);
    }
    public void PrePage()
    {
        pages[page].SetActive(false);
        page--;
        pages[page].SetActive(true);
    }
}