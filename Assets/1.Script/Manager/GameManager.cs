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
    private bool isExit;
    public static GameManager Instance;
    public int score;
    public int bestScore;
    public Text BestScoreText;
    public Text ScoreText;
    public GameObject overPannel;
    private int money;
    public int UserMoney{
        get {
            return money;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (BestScoreText)
        {
            bestScore = PlayerPrefs.GetInt("Best");
            tempBest = bestScore;
            BestScoreText.text = string.Format("BEST SCORE" + System.Environment.NewLine + "{0}", bestScore);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ExitGame());
        }
    }
    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }
    public IEnumerator ExitGame()
    {
        if (isExit)
        {
            Application.Quit();
        }
        else{
            isExit = true;
        }
        yield return new WaitForSeconds(0.5f);
        isExit = false;
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
        if (bestScore < score)
        {
            SaveBestScore();
            bestScore = score;
            BestScoreText.text = string.Format("BEST SCORE" + System.Environment.NewLine + "{0}", bestScore);
        }
    }
    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best", score);
    }
}