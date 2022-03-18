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
    public Text text, bestScoreText;
    bool isCubeSpawn;
    [SerializeField] private GameObject gameOverPanel, pausePanel;
    [SerializeField] private GameObject inputPanel;
    [SerializeField] private User user;
    [SerializeField] private ComboSystem comboSystem;
    [SerializeField] private BackgroundManager backgroundManager;
    [SerializeField] private AdManager adManager;
    public AdManager AdManager { get { return adManager; } }
    public GameObject GameOverPanel { get { return gameOverPanel; } }
    public ComboSystem ComboSystem { get { return comboSystem; } }
    public bool IsCubeSpawn { get { return isCubeSpawn; } set { isCubeSpawn = value; } }
    public User UserInfo
    {
        get
        {
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
        /*if (user.name == "" || user.name == null)
        {
            Inputname();
        }*/
        adManager.ToggleBannerAd(true);
    }
    //public void 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel)
            {
                pausePanel.SetActive(true);
                return;
            }
            Quit();
        }
    }
    public void GoGame()
    {
        SaveUser();
        //ModManager.Instance.SaveToJson();
        //ModManager.Instance.SetMode();
        adManager.ToggleBannerAd(true);
        SceneManager.LoadScene(1);
    }
    public void GoMain()
    {
        SaveUser();
        /*try
        {
            ModManager.Instance.SetMode();
        }
        catch { }*/
        adManager.ToggleBannerAd(true);
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        if (!isOver)
        {
            googleSheetManager.Call("Get", score);
            text.gameObject.SetActive(true);
            text.text = string.Format("TOP : {0}%", overString);
            bestScoreText.text = score.ToString();
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
    public void SetZingle(bool isZingle)
    {
        user.isZingle = isZingle;
        SaveUser();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void FrontAd()
    {
        int rand = Random.Range(0, 100);
        if(rand <= 25)
        {
            try
            {
                adManager.ShowFrontAd();
            }
            catch
            {
                print("Network Error");
            }
        }
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