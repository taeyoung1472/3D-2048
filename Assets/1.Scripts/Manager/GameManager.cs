using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int tempBest;
    public string overString;
    public bool isCube;
    public ShakeManager shakeManager;
    public GameObject congachuRationObject;
    public GoogleSheetManager googleSheetManager;
    public bool isOver;
    private bool isExit;
    public static GameManager Instance;
    public int score;
    public int bestScore;
    public TextMesh BestScoreText;
    public TextMesh ScoreText;
    public GameObject overPannel;
    public Text text;
    bool isCubeSpawn;
    [SerializeField] private User user;
    [SerializeField] private ComboSystem comboSystem;
    public ComboSystem ComboSystem { get { return comboSystem; } }
    public bool IsCubeSpawn { get { return isCubeSpawn; } set { isCubeSpawn = value; } }
    public User UserInfo{
        get{
            return user;
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
            BestScoreText.text = string.Format("BestScore : " + "{0}", bestScore);
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
        if (!isOver)
        {
            googleSheetManager.Call("Get", score);
            text.gameObject.SetActive(true);
            text.text = string.Format("TOP : {0}%", overString);
            overPannel.SetActive(true);
            if (tempBest < bestScore)
            {
                text.gameObject.SetActive(false);
                googleSheetManager.Call("Set", score);
                CongachuRation();
            }
            isOver = true;
        }
    }
    public void CongachuRation()
    {
        congachuRationObject.SetActive(true);
    }
    public void AddScroe(int _score)
    {
        score += _score;
        ScoreText.text = string.Format("Score     : {0}", score);
        if (bestScore < score)
        {
            SaveBestScore();
            bestScore = score;
            BestScoreText.text = string.Format("BestScore : " + "{0}", bestScore);
        }
    }
    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("Best", score);
    }
}