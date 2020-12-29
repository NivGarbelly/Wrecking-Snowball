using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;
using System.Collections.Generic;
using System.Linq;

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

    public List<int> nums = new List<int>();
    public void GameWon()
    {
       
        Invoke("ShowWinText", 3f);
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
        scoreText.text = score.ToString();
        highScoreText.text = "High Score: " + highScore;
        if (score>highScore)
        {
            highScore = score;
            SaveGame.Save<int>("highScore",highScore);
        }
    }

    void ShowWinText()
    {
        score = score * nums.Max();
        completeLevel.SetActive(true);
    }

    public void X2(int num)
    {
        nums.Add(num);
    }
    public void X3(int num)
    {
        nums.Add(num);
    }
    public void X4(int num)
    {
        nums.Add(num);
    }
    public void X5(int num)
    {
        nums.Add(num);
    }
    public void X6(int num)
    {
        nums.Add(num);
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
