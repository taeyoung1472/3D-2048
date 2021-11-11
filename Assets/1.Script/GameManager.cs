using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int tempBest;
    public Shaking shakeManager;
    public GameObject congachuRationObject;
    public bool isOver;
    public static GameManager Instance;
    public int score;
    public int bestScore;
    public Text BestScoreText;
    public Text ScoreText;
    public GameObject overPannel;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if(BestScoreText)
        {
            bestScore = PlayerPrefs.GetInt("Best");
            tempBest = bestScore;
            BestScoreText.text = string.Format("BEST SCORE" + System.Environment.NewLine + "{0}", bestScore);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitGame();
    }
    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        overPannel.SetActive(true);
        if (tempBest < bestScore)
        {
            CongachuRation();
        }
        isOver = true;
    }
    public void CongachuRation()
    {
        congachuRationObject.SetActive(true);
    }
    public void AddScroe(int _score)
    {
        score += _score;
        ScoreText.text = string.Format("SCORE : {0}", score);
        if(bestScore < score)
        {
            SaveBestScore();
            bestScore = score;
            BestScoreText.text = string.Format("BEST SCORE" + System.Environment.NewLine + "{0}", bestScore);
        }
    }
    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best",score);
    }
}