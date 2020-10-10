using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Variables
    [Header("Score")]
    [SerializeField] private int score;
    [SerializeField] private int highScore;

    [Header("UI components")]
    [SerializeField] private Text liveScore;
    [SerializeField] private Text liveHighScore;
    [SerializeField] private GameObject pauseMenuUI;
    
    [Header("NPCs")]
    public GameObject[] characters;

    [Header("Spawn Points")]
    public Spawnpoint[] spawnPoints;
    [SerializeField] private float spawnRate, spawnRateDecreaseFactor;
    private int randomnumber;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        liveHighScore.text = highScore.ToString();        
    }

    public void BeginGame()
    {
        SpawnNPCs();
    }

    public void Score()
    {
        score++;
        liveScore.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            liveHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void MinusScore()
    {
        score--;
        liveScore.text = score.ToString();
    }
    
    private void SpawnNPCs()
    {
        randomnumber = Random.Range(0, spawnPoints.Length);
        spawnPoints[randomnumber].Spawn();
        StartCoroutine(SpawnMoreNPCs(spawnRate));
    }

    IEnumerator SpawnMoreNPCs(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnNPCs();
        if (spawnRate >= 0f)
        {
            spawnRate -= spawnRateDecreaseFactor;
        }
    }
    

    #region Pause Menu Methods

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
