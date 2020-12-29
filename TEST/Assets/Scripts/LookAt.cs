using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAt : MonoBehaviour
{
    public Transform player;
    public float smooth = 1f;
    public Vector3 offset;
    public Text xText;
    public Text yText;
    public Text zText;
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;
    private void LateUpdate()
    {
        if (player != null)
        { 
         Vector3 desiredPos = player.position + offset;
         Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smooth);
         transform.position = smoothedPos;
         transform.LookAt(player.transform.position);
        }
    }

    private void Update()
    {
        offset.x = xSlider.value; 
        offset.y = ySlider.value;
        offset.z = zSlider.value;
        xText.text = offset.x.ToString();
        yText.text = offset.y.ToString();
        zText.text = offset.z.ToString();
    }

    public void ResetButton()
    {
        xSlider.value = 0;
        ySlider.value = 10;
        zSlider.value = -20;
    }
}