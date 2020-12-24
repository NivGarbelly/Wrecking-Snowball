using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] bool gameIsWon;
    [SerializeField] bool gameIsLost;

    public GameObject objectCollectedText;
    public GameObject completeLevel;
    public GameObject player;
    public GameObject finishObjectCollectedText;

    public int finishObjectAmount;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameWon()
    {
        objectCollectedText.SetActive(false);
        
        Invoke("ShowWinText", 2f);
    }

    void ShowWinText()
    {

        completeLevel.SetActive(true);
        finishObjectCollectedText.SetActive(true);
        finishObjectCollectedText.GetComponent<Text>().text = "Score: " + finishObjectAmount.ToString();
    }
}
