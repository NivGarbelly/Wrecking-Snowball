using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressDistanceBar : MonoBehaviour
{
    [SerializeField] private GameObject startingPoint;
    [SerializeField] private GameObject endingPoint;
    [SerializeField] float distance = 100;
    [SerializeField] private float progress;
    [SerializeField] private float totalDistanss;
    public static bool won = false;


    [SerializeField] public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        Invoke("TotalDistanss", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Math.Abs(startingPoint.transform.position.x - endingPoint.transform.position.x);

        PrograssBar();
        Won();
    }

    void PrograssBar()
    {
        if (won == false)
        {
            progress = (totalDistanss - distance) / totalDistanss;
            slider.value = progress;
        }

    }
   
    void Won()
    {
        if(distance <= 0.1f)
        {
            won = true;
            slider.value = 1f;
        }
    }
    public void TotalDistanss()
    {
        totalDistanss = distance;
    }

}
