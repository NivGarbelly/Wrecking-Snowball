using System;
using UnityEngine;

public class Collects : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="X2")
        {
            gameManager.X2();
        }
        if (other.gameObject.name=="X3")
        {
            gameManager.X3();
        }
        if (other.gameObject.name=="X4")
        {
            gameManager.X4();
        }
        if (other.gameObject.name=="X5")
        {
            gameManager.X5();
        }
        if (other.gameObject.name=="X6")
        {
            gameManager.X6();
        }
    }
}
