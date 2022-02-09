using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject inputPanel;
    [SerializeField] private User user;
    [SerializeField] private ComboSystem comboSystem;
    [SerializeField] private BackgroundManager backgroundManager;
    public GameObject GameOverPanel { get { return gameOverPanel; } }
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
        LoadUser();
        SaveUser();
    }
    private void Start()
    {
        if (BestScoreText)
        {
            bestScore = user.bestScore;
            tempBest = bestScore;
            BestScoreText.text = string.Format("BestScore : " + "{0}", bestScore);
        }
        if(user.name == "" || user.name == null)
        {
            Inputname();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
    public void GoGame()
    {
        SaveUser();
        SceneManager.LoadScene(1);
    }
    public void GoMain()
    {
        SaveUser();
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        if (!isOver)
        {
            googleSheetManager.Call("Get", score);
            text.gameObject.SetActive(true);
            text.text = string.Format("TOP : {0}%", overString);
            gameOverPanel.SetActive(false);
            overPannel.SetActive(true);
            if (tempBest < bestScore)
            {
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
            user.bestScore = score;
            bestScore = score;
            BestScoreText.text = string.Format("BestScore : " + "{0}", bestScore);
        }
        backgroundManager.CheckTier(score);
    }
    public void Inputname()
    {
        inputPanel.SetActive(true);
    }
    public void EndInpuut()
    {
        inputPanel.SetActive(false);
    }
    public void OnApplicationQuit()
    {
        SaveUser();
    }
    public void Quit()
    {
        Application.Quit();
    }
    [ContextMenu("저장하기")]
    public void SaveUser()
    {
        print("저장");
        string jsonData = JsonUtility.ToJson(user, true);
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("불러오기")]
    public void LoadUser()
    {
        print("불러오기");
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");
        string jsonData = File.ReadAllText(path);
        user = JsonUtility.FromJson<User>(jsonData);
    }
}