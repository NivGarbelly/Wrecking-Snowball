using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

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
    }

    public void Update()
    {
        collectsMoney = SaveGame.Load<int>("collect");
        collectsText.text = "Collects: " + collectsMoney+player.collects.Count;
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

        if (player == null)
        {
            for (int i = 0; i == 1; i++)
            {
                collectsMoney = collectsMoney+player.collects.Count;
                SaveGame.Save<int>("collect", collectsMoney);
            }
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
}
