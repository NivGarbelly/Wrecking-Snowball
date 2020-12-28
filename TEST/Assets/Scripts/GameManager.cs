using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevel;
    public int score;
    public int highScore;
    public int collect;
    public SnowBall player;
    public Text scoreText;
    public Text highScoreText;
    public Text collectsText;
    public int collectsMoney;
    public void GameWon()
    {
        Invoke("ShowWinText", 2f);
    }

    private void Awake()
    {
        highScore = SaveGame.Load<int>("highScore");
        collectsMoney = SaveGame.Load<int>("collect");
    }

    public void Update()
    {
        collectsText.text = "Collects: " + (collectsMoney + player.collects.Count).ToString();
        if (player!=null)
        {
            score = (int) player.speed;
        }
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
        if (score>highScore)
        {
            highScore = score;
            SaveGame.Save<int>("highScore",highScore);
        }
    }

    void ShowWinText()
    {
        completeLevel.SetActive(true);
    }

    public void X2()
    {
        score = score * 2;
    }
    public void X3()
    {
        score = score * 3;
    }
    public void X4()
    {
        score = score * 4;
    }
    public void X5()
    {
        score = score * 5;
    }
    public void X6()
    {
        score = score * 6;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveCollect()
    {
        collectsMoney = player.collects.Count + collectsMoney;
        SaveGame.Save<int>("collect", collectsMoney);
    }
}
